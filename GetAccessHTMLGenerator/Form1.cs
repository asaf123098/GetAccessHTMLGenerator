using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GetAccessHTMLGenerator
{
    public partial class Form1 : Form
    {

        private bool productNameHasValue = false;
        private bool imageLinkHasValue = false;
        private bool descriptionHasValue = false;

        private string rowHeaderValue;
        private string imageLinkValue;
        private string descriptionValue;

        private HtmlAgilityPack.HtmlDocument document;
        private const string HtmlFileName = @"html.html";

        private const string rowXpath = "//div[contains(@class, 'row')]";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ParseHTML();
            List<string[]> rows = this.ParseRowsFromHtml();
            this.AddItemsToList(rows);
            this.SetGenerateHtmlButtonState();
        }

        private void generateHtmlButton_Click(object sender, EventArgs e)
        { 
            this.UpdateHtml();
            this.CopyHTMLToClipboard();
        }

        private void ParseHTML()
        {
            try
            {
                this.document = new HtmlAgilityPack.HtmlDocument();
                this.document.Load(HtmlFileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                this.RaiseAlert($"Failed to find '{HtmlFileName}' in the directory!!!");
                this.Close();
            }
        }

        private List<string[]> ParseRowsFromHtml()
        {
            List<string[]> rows = new List<string[]> { };

            HtmlNodeCollection nodes = this.FindNodes(rowXpath);
            HtmlNodeCollection images = this.FindNodes($"{rowXpath}/img");
            HtmlNodeCollection headers = this.FindNodes($"{rowXpath}//span[contains(@class, 'header')]");
            HtmlNodeCollection paragraphs = this.FindNodes($"{rowXpath}//span[contains(@class, 'paragraph')]");

            foreach (int i in Enumerable.Range(0, nodes.Count))
            {
                string imageLink = images[i].Attributes.First().Value;
                string header = headers[i].InnerText;
                string paragraph = paragraphs[i].InnerText;


                rows.Add(new string[] { imageLink, header, this.NormalizeString(paragraph) });
            }

            return rows;
        }

        private void AddItemsToList(List<string[]> rows)
        {
            foreach (int i in Enumerable.Range(0, rows.Count))
            {
                string[] detailes = rows[i];

                this.AddItemToList(detailes[0], detailes[1], detailes[2]);
            }
        }
        private void AddItemToList(string ImageLink, string RowHeader, string Description)
        {
            ListViewItem item = new ListViewItem(ImageLink);
            item.SubItems.Add(RowHeader);
            item.SubItems.Add(Description);
            this.rowsList.Items.Add(item);
        }

        private void UpdateHtml()
        {
            HtmlNode productNameTag = this.FindNodes("//h2[@id='productName']").First();
            productNameTag.InnerHtml = this.rowHeaderValue;

            HtmlNode imgTag = this.FindNodes("//img[@id='productImage']").First();
            imgTag.SetAttributeValue("src", this.imageLinkValue);

            HtmlNode descriptionTag = this.FindNodes("//p[@id='description']").First();
            descriptionTag.InnerHtml = this.descriptionValue.Replace("\r\n", "<br>\r\n");

            this.document.Save(HtmlFileName);
        }

        private void CopyHTMLToClipboard()
        { 
            string newHtml = this.document.DocumentNode.WriteTo();
            Clipboard.SetText(this.NormalizeString(newHtml));
        }

        private HtmlNodeCollection FindNodes(string xpath)
        {
            HtmlNodeCollection nodes = this.document.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
                return nodes;
            else
            {
                this.RaiseAlert($"Failed to find xpath: '{xpath}'");
                Application.Exit();
                return null;
            }

        }

        private string NormalizeString(string stringToNormalize)
        {
            stringToNormalize = stringToNormalize.Replace("\t", "");
            stringToNormalize = stringToNormalize.Replace("    ", "");
            return stringToNormalize;
        }
        private void ProductName_TextChanged(object sender, EventArgs e)
        {
            this.UpdateVarValue(varToUpdate: out this.rowHeaderValue, flagToUpdate: out this.productNameHasValue, value: productName.Text);
            this.SetAddRowButtonState();
        }

        private void ImageLink_TextChanged(object sender, EventArgs e)
        { 
            this.UpdateVarValue(varToUpdate: out this.imageLinkValue, flagToUpdate: out this.imageLinkHasValue, value:imageLink.Text);
            this.SetAddRowButtonState();
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            this.UpdateVarValue(varToUpdate: out this.descriptionValue, flagToUpdate: out this.descriptionHasValue, value: description.Text);
            this.SetAddRowButtonState();
        }

        private void UpdateVarValue(out string varToUpdate, out bool flagToUpdate, string value)
        {
            
            if (String.IsNullOrEmpty(value))
            {
                flagToUpdate = false;
                varToUpdate = value;
            }
            else
            {
                flagToUpdate = true;
                varToUpdate = value;
            }
        }

        private void SetAddRowButtonState()
        {
            addRowButton.Enabled = this.descriptionHasValue && this.imageLinkHasValue && this.productNameHasValue;
        }

        private void RaiseAlert(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            this.AddItemToList(this.imageLinkValue, this.rowHeaderValue, this.descriptionValue);
            this.SetGenerateHtmlButtonState();
        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        { 
            foreach (int index in this.rowsList.SelectedIndices)
            {
                this.rowsList.Items[index].Remove();
            }
            this.SetGenerateHtmlButtonState();
        }

        private void SetGenerateHtmlButtonState()
        {
            this.generateHtmlButton.Enabled = this.rowsList.Items.Count > 0;
        }

        private void RowsList_Leave(object sender, EventArgs e)
        {
            
            this.removeSelectedButton.Enabled = this.FindFocusedControl(this) == this.removeSelectedButton;
        }

        private void RowsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.removeSelectedButton.Enabled = e.IsSelected;
        }

        private Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }
    }
}
