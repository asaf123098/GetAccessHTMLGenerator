using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GetAccessHTMLGenerator
{
    public partial class Form1 : Form
    {

        private bool productNameHasValue = false;
        private bool imageLinkHasValue = false;
        private bool descriptionHasValue = false;

        private string productNameValue;
        private string imageLinkValue;
        private string descriptionValue;

        private HtmlAgilityPack.HtmlDocument document;
        private const string HtmlFileName = @"html.html";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.setAddRowButtonState();
        }

        private void generateHtmlButton_Click(object sender, EventArgs e)
        {
            this.parseHTML();
            this.updateHtml();
            this.copyHTMLToClipboard();
        }

        private void parseHTML()
        {
            try
            {
                document = new HtmlAgilityPack.HtmlDocument();
                document.Load(HtmlFileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                this.raiseAlert($"Failed to find '{HtmlFileName}' in the directory!!!");
                Load += (s, e) => Close();
            }
        }

        private void updateHtml()
        {
            HtmlNode productNameTag = this.findNode("//h2[@id='productName']");
            productNameTag.InnerHtml = this.productNameValue;

            HtmlNode imgTag = this.findNode("//img[@id='productImage']");
            imgTag.SetAttributeValue("src", this.imageLinkValue);

            HtmlNode descriptionTag = this.findNode("//p[@id='description']");
            descriptionTag.InnerHtml = this.descriptionValue.Replace("\r\n", "<br>\r\n");

            this.document.Save(HtmlFileName);
        }

        private void copyHTMLToClipboard()
        { 
            string newHtml = this.document.DocumentNode.WriteTo();
            Clipboard.SetText(this.normalizeString(newHtml));
        }

        private HtmlNode findNode(string xpath)
        {
            HtmlNodeCollection nodes = this.document.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
                return nodes.First();
            else
            {
                this.raiseAlert($"Failed to find xpath: '{xpath}'");
                Application.Exit();
                return null;
            }

        }

        private string normalizeString(string stringToNormalize)
        {
            stringToNormalize = stringToNormalize.Replace("\t", "");
            stringToNormalize = stringToNormalize.Replace("    ", "");
            return stringToNormalize;
        }
        private void productName_TextChanged(object sender, EventArgs e)
        {
            this.updateVarValue(varToUpdate: out this.productNameValue, flagToUpdate: out this.productNameHasValue, value: productName.Text);
            this.setAddRowButtonState();
        }

        private void imageLink_TextChanged(object sender, EventArgs e)
        { 
            this.updateVarValue(varToUpdate: out this.imageLinkValue, flagToUpdate: out this.imageLinkHasValue, value:imageLink.Text);
            this.setAddRowButtonState();
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            this.updateVarValue(varToUpdate: out this.descriptionValue, flagToUpdate: out this.descriptionHasValue, value: description.Text);
            this.setAddRowButtonState();
        }

        private void updateVarValue(out string varToUpdate, out bool flagToUpdate, string value)
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

        private void setAddRowButtonState()
        {
            addRowButton.Enabled = this.descriptionHasValue && this.imageLinkHasValue && this.productNameHasValue;
        }

        private void raiseAlert(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            generateHtmlButton.Enabled = rowsList.Items.Count > 0;
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            generateHtmlButton.Enabled = rowsList.Items.Count > 0;
        }
    }
}
