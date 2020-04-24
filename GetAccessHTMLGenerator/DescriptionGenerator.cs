using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GetAccessHTMLGenerator
{
    public partial class DescriptionGenerator : Form
    {

        private bool productNameHasValue = false;
        private bool imageLinkHasValue = false;
        private bool descriptionHasValue = false;

        private string rowHeaderValue;
        private string imageLinkValue;
        private string descriptionValue;

        private HtmlAgilityPack.HtmlDocument document;
        private const string HtmlFileName = @"description.html";

        private const string rowXpath = "//div[@class='rows_container']/div[contains(@class, 'row')]";
        HtmlNode rowsContainer;


        public DescriptionGenerator()
        {
            InitializeComponent();
        }

        private void DescriptionGenerator_Load(object sender, EventArgs e)
        {
            this.ParseHTML();
        }

        private void ParseHTML()
        {
            try
            {
                this.document = new HtmlAgilityPack.HtmlDocument();
                this.document.Load(HtmlFileName);
                this.ShouldShow();           
            }
            catch (System.IO.FileNotFoundException)
            {
                this.RaiseAlert($"Failed to find '{HtmlFileName}' in the directory!!!");
                this.Close();
            }
        }

        private void ShouldShow()
        {
            List<string[]> rows = this.ParseRowsFromHtml();
            this.AddItemsToList(rows);
            this.SetGenerateHtmlButtonState();
            this.rowsContainer = this.FindNodes("//div[contains(@class, 'rows_container')]").First();
        }

        private List<string[]> ParseRowsFromHtml()
        {
            List<string[]> rows = new List<string[]> { };

            HtmlNodeCollection nodes = this.FindNodes(rowXpath, false);
            HtmlNodeCollection images = this.FindNodes($"{rowXpath}/img", false);
            HtmlNodeCollection headers = this.FindNodes($"{rowXpath}//span[contains(@class, 'header')]", false);
            HtmlNodeCollection descriptions = this.FindNodes($"{rowXpath}//span[contains(@class, 'paragraph')]", false);

            if (!(nodes == null))
            {
                foreach (int i in Enumerable.Range(0, nodes.Count))
                {
                    string imageLink = images[i].Attributes.First().Value;
                    string header = headers[i].InnerText;
                    string description = descriptions[i].InnerText;


                    rows.Add(new string[] { imageLink, header, this.NormalizeString(description) });
                }
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
            item.SubItems.Add(Description.Replace("\r\n", "\r\n "));
            this.rowsList.Items.Add(item);
        }

        private void generateHtmlButton_Click(object sender, EventArgs e)
        {
            this.UpdateHtml();
            this.CopyHTMLToClipboard();
        }

        private void UpdateHtml()
        {
            this.rowsContainer.RemoveAllChildren();

            ListView.ListViewItemCollection rows = this.rowsList.Items;

            foreach (int i in Enumerable.Range(0, this.rowsList.Items.Count))
            {
                string color = i % 2 == 0 ? "gray" : "white";
                ListViewItem row = rows[i];
                string imageLink = row.SubItems[0].Text;
                string header = row.SubItems[1].Text;
                string paragraph = row.SubItems[2].Text;
                paragraph = paragraph.Replace("\r\n", "<br>\r\n");

                this.rowsContainer.AppendChild(this.GetNewRowElement(color, imageLink, header, paragraph));

            }
            this.document.Save(HtmlFileName);
        }

        private HtmlNode GetNewRowElement(string rowColor, string imageLink, string header, string paragraph)
        {
            HtmlNode row = HtmlNode.CreateNode($"<div class='{rowColor} row'></div>");
            HtmlNode img = HtmlNode.CreateNode($"<img src='{imageLink}'>");
            HtmlNode textContainer = HtmlNode.CreateNode($"<div class='text_container'></div>");
            HtmlNode headerNode = HtmlNode.CreateNode($"<span class='header'>{header}</span>");
            HtmlNode br = HtmlNode.CreateNode($"<br>");
            HtmlNode paragraphNode = HtmlNode.CreateNode($"<span class='paragraph'>{paragraph}</span>");

            row.AppendChild(img);

            textContainer.AppendChild(headerNode);
            textContainer.AppendChild(br);
            textContainer.AppendChild(paragraphNode);
            row.AppendChild(textContainer);

            return row;
        }

        private void CopyHTMLToClipboard()
        { 
            string newHtml = this.document.DocumentNode.WriteTo();
            Clipboard.SetText(this.NormalizeString(newHtml));
        }

        private HtmlNodeCollection FindNodes(string xpath, bool raiseException = true)
        {
            HtmlNodeCollection nodes = this.document.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
                return nodes;
            else if (raiseException)
            { 
                this.RaiseAlert($"Failed to find xpath: '{xpath}'");
                Application.Exit();
            }
            return null;
        }

        private string NormalizeString(string stringToNormalize, bool deleteNewLines = false)
        {
            stringToNormalize = stringToNormalize.Replace("\t", "");
            stringToNormalize = stringToNormalize.Replace("    ", "");
            if (deleteNewLines)
                stringToNormalize = stringToNormalize.Replace("\r\n", "");
            return stringToNormalize;
        }

        private void ProductName_TextChanged(object sender, EventArgs e) => this.SetAddRowButtonState();

        private void ImageLink_TextChanged(object sender, EventArgs e) => this.SetAddRowButtonState();

        private void Description_TextChanged(object sender, EventArgs e) => this.SetAddRowButtonState();

        private void SetAddRowButtonState()
        {
            addRowButton.Enabled = 
                !String.IsNullOrEmpty(this.description.Text) && 
                !String.IsNullOrEmpty(this.imageLink.Text) &&
                !String.IsNullOrEmpty(this.productName.Text);
        }

        private void RaiseAlert(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            this.AddItemToList(this.imageLinkValue, this.rowHeaderValue, this.descriptionValue);
            this.SetGenerateHtmlButtonState();

            this.imageLink.ResetText();
            this.productName.ResetText();
            this.description.ResetText();
        }

        private void ListedItemsList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.rowsList.FocusedItem.Bounds.Contains(e.Location))
                {
                    this.rowsListContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection focusedItems = this.rowsList.SelectedItems;
            
            foreach (ListViewItem focusedItem in focusedItems)
            {
                this.rowsList.Items.Remove(focusedItem);
            }
            
            this.SetGenerateHtmlButtonState();
        }

        private void SetGenerateHtmlButtonState()
        {
            this.generateHtmlButton.Enabled = this.rowsList.Items.Count > 0;
        }

        private void RowsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.rowsList.GetItemAt(e.X, e.Y);
            this.imageLink.Text = item.Text;
            this.productName.Text = item.SubItems[1].Text;
            this.description.Text = item.SubItems[2].Text;
        }
    }
}
