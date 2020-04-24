using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using HtmlAgilityPack;
using GeneralUtilities;

namespace GetAccessHTMLGenerator
{
    public partial class DescriptionGenerator : Form
    {
        private HtmlNode rowsContainer;
        private HtmlAgilityPack.HtmlDocument document;
        
        public const string htmlTemplatesDirPath = @".\DescriptionHtmlTemplates";
        private readonly string htmlFilePath = Path.Combine(htmlTemplatesDirPath, "Description.html");
        
        private const string rowXpath = "//div[@class='rows_container']/div[contains(@class, 'row')]";


        public DescriptionGenerator()
        {
            InitializeComponent();
            //InitSuppliersWarranties();
            ParseHTML();
        }

        //private void InitSuppliersWarranties()
        //{
        //    string[] dirNames = Directory.GetDirectories(this.warrantyAndReturnsTemplatesPath);
        //    foreach (string dirPath in dirNames)
        //    {
        //        string dirName = Path.GetFileName(dirPath);
        //        this.suppliersWarranties.Items.Add(dirName);
        //    }
        //}

        private void ParseHTML()
        {
            try
            {
                this.document = new HtmlAgilityPack.HtmlDocument();
                this.document.Load(htmlFilePath);
                FormShouldShow();           
            }
            catch (FileNotFoundException)
            {
                Utilities.RaiseAlert($"Failed to find '{htmlFilePath}' in the directory!!!");
                Close();
            }
        }

        private void FormShouldShow()
        {
            List<string[]> rows = ParseRowsFromHtml();
            AddItemsToList(rows);
            SetGenerateHtmlButtonState();
            this.rowsContainer = Utilities.FindNodes(this.document, "//div[contains(@class, 'rows_container')]").First();
        }

        private List<string[]> ParseRowsFromHtml()
        {
            List<string[]> rows = new List<string[]> { };

            HtmlNodeCollection nodes = Utilities.FindNodes(this.document, rowXpath, false);
            HtmlNodeCollection images = Utilities.FindNodes(this.document, $"{rowXpath}/img", false);
            HtmlNodeCollection headers = Utilities.FindNodes(this.document, $"{rowXpath}//span[contains(@class, 'header')]", false);
            HtmlNodeCollection descriptions = Utilities.FindNodes(this.document, $"{rowXpath}//span[contains(@class, 'paragraph')]", false);

            if (!(nodes == null))
            {
                foreach (int i in Enumerable.Range(0, nodes.Count))
                {
                    string imageLink = images[i].Attributes.First().Value;
                    string header = headers[i].InnerText;
                    string description = descriptions[i].InnerText;


                    rows.Add(new string[] { imageLink, header, NormalizeString(description) });
                }
            }

            return rows;
        }

        private void AddItemsToList(List<string[]> rows)
        {
            foreach (int i in Enumerable.Range(0, rows.Count))
            {
                string[] detailes = rows[i];

                AddItemToList(detailes[0], detailes[1], detailes[2]);
            }
        }
        private void AddItemToList(string ImageLink, string RowHeader, string Description)
        {
            ListViewItem item = new ListViewItem(ImageLink);
            item.SubItems.Add(RowHeader);
            item.SubItems.Add(Description.Replace("\r\n", "\r\n "));
            this.rowsList.Items.Add(item);
        }

        private void GenerateHtmlButton_Click(object sender, EventArgs e)
        {
            UpdateHtml();
            CopyHTMLToClipboard();
        }

        private void UpdateHtml()
        {
            bool addWrrantyAndReturns = AddWarrantyAndReturnsToHtml();
            DialogResult result;

            if (!addWrrantyAndReturns)
            {
                result = MessageBox.Show(
                    text: "Are you sure you don't want to add a warranty and returns policy?",
                    caption: "Warning!",
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Warning,
                    defaultButton: MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                    return;                    
            }
            AddRowsToHtml();
            this.document.Save(htmlFilePath);
        }

        private bool AddWarrantyAndReturnsToHtml()
        {
            WarrantyAndReturnsGenerator generator = new WarrantyAndReturnsGenerator();

            HtmlNode warrantyAndReturnsDiv = Utilities.FindNodes(this.document, "//div[@id='warranty-and-returns']", raiseException: false)[0];
            CheckedListBox.CheckedItemCollection checkedSupplier = this.suppliersWarranties.CheckedItems;
            if (checkedSupplier.Count == 0)
            {
                warrantyAndReturnsDiv.SetAttributeValue(name: "style", value: "display:none");
                return false;
            }
            else
            {
                warrantyAndReturnsDiv.SetAttributeValue(name: "style", value: "display:block");

                HtmlNode returnsSpan = Utilities.FindNodes(this.document, "//span[contains(@class, 'returns') and contains(@class, 'header')]")[0];
                returnsSpan.RemoveAllChildren();
                returnsSpan.AppendChild(generator.GetReturns());

                HtmlNode warrantySpan = Utilities.FindNodes(this.document, "//span[contains(@class, 'warranty') and contains(@class, 'header')]")[0];
                warrantySpan.RemoveAllChildren();
                warrantySpan.AppendChild(generator.GetWarranty());

                return true;
            }
        }

        private void AddRowsToHtml()
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
            Clipboard.SetText(NormalizeString(newHtml));
        }

        private string NormalizeString(string stringToNormalize, bool deleteNewLines = false)
        {
            stringToNormalize = stringToNormalize.Replace("\t", "");
            stringToNormalize = stringToNormalize.Replace("    ", "");
            if (deleteNewLines)
                stringToNormalize = stringToNormalize.Replace("\r\n", "");
            return stringToNormalize;
        }

        private void ProductName_TextChanged(object sender, EventArgs e) => SetAddRowButtonState();

        private void ImageLink_TextChanged(object sender, EventArgs e) => SetAddRowButtonState();

        private void Description_TextChanged(object sender, EventArgs e) => SetAddRowButtonState();

        private void SetAddRowButtonState()
        {
            addRowButton.Enabled = 
                !String.IsNullOrEmpty(this.description.Text) && 
                !String.IsNullOrEmpty(this.imageLink.Text) &&
                !String.IsNullOrEmpty(this.lineHeader.Text);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            AddItemToList(this.imageLink.Text, this.lineHeader.Text, this.description.Text);
            SetGenerateHtmlButtonState();

            this.imageLink.ResetText();
            this.lineHeader.ResetText();
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
            
            SetGenerateHtmlButtonState();
        }

        private void SetGenerateHtmlButtonState()
        {
            this.generateHtmlButton.Enabled = this.rowsList.Items.Count > 0;
        }

        private void RowsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.rowsList.GetItemAt(e.X, e.Y);
            this.imageLink.Text = item.Text;
            this.lineHeader.Text = item.SubItems[1].Text;
            this.description.Text = item.SubItems[2].Text;
        }
    }
}
