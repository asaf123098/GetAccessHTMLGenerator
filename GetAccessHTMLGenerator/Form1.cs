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

        public Form1()
        {
            InitializeComponent();
        }

        private void generateHtmlButton_Click(object sender, EventArgs e)
        {
            this.parseHTML();
            this.copyHTMLToClipboard();
        }

        private void parseHTML()
        {
            string htmlFileName = @"html.html";
            try
            {
                document = new HtmlAgilityPack.HtmlDocument();
                document.Load(htmlFileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                this.raiseAlert($"Failed to find '{htmlFileName}' in the directory!!!");
                Load += (s, e) => Close();
            }
        }

        private void copyHTMLToClipboard()
        {
            HtmlNode productNameTag = this.findNode("//h1[@id='productName']");
            productNameTag.InnerHtml = this.productNameValue;

            HtmlNode imgTag = this.findNode("//img[@id='productImage']");
            imgTag.SetAttributeValue("src", this.imageLinkValue);

            HtmlNode descriptionTag = this.findNode("//p[@id='description']");
            descriptionTag.InnerHtml = this.descriptionValue;

            Clipboard.SetText(this.document.DocumentNode.WriteTo());
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

        private void productName_TextChanged(object sender, EventArgs e)
        {
            this.updateVarValue(varToUpdate: out this.productNameValue, flagToUpdate: out this.productNameHasValue, value: productName.Text);
            this.setGenerateHTMLButtonState();
        }

        private void imageLink_TextChanged(object sender, EventArgs e)
        { 
            this.updateVarValue(varToUpdate: out this.imageLinkValue, flagToUpdate: out this.imageLinkHasValue, value:imageLink.Text);
            this.setGenerateHTMLButtonState();
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            this.updateVarValue(varToUpdate: out this.descriptionValue, flagToUpdate: out this.descriptionHasValue, value: description.Text);
            this.setGenerateHTMLButtonState();
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

        private void setGenerateHTMLButtonState()
        {
            generateHtmlButton.Enabled = this.descriptionHasValue && this.imageLinkHasValue && this.productNameHasValue;
        }

        private void raiseAlert(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
