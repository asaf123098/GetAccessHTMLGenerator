using System;
using System.IO;
using HtmlAgilityPack;
using GeneralUtilities;


namespace GetAccessHTMLGenerator
{
    class WarrantyAndReturnsGenerator
    {
        private HtmlNode warrantyNode;
        private HtmlNode returnsNode;

        private readonly string warrantyAndReturnsTemplatesPath =
            Path.Combine(DescriptionGenerator.htmlTemplatesDirPath, "WarrantyAndRefundTemplates", "CreationWatchesTemplates");

        public WarrantyAndReturnsGenerator()
        {
           
        }

        public HtmlNode GetWarranty()
        {
            this.warrantyNode = GetPage(@"https://www.creationwatches.com/warranty.html");
            VerifyMatchesExpected(templateFileName: "WarrantyToCompare.html", type: "warranty", compareTo: this.warrantyNode);

            int[] neededNodes = new int[] { 1, 13, 15, 17, 19, 21, 23, 25 };

            HtmlNode list = ChangeNodeToList(this.warrantyNode, neededNodes);

            list.ChildNodes[3].ChildNodes[5].InnerHtml = list.ChildNodes[3].ChildNodes[5].InnerHtml.Replace("an email", "a message");
            list.ChildNodes[1].InnerHtml = list.ChildNodes[1].InnerHtml.Split(new string[] { " In such cases," }, StringSplitOptions.None)[0];
            list.LastChild.InnerHtml = list.LastChild.InnerHtml.Split(new string[] { "Also" }, StringSplitOptions.None)[0];
            return list;
        }

        public HtmlNode GetReturns()
        {
            this.returnsNode = GetPage(@"https://www.creationwatches.com/returns.html");
            VerifyMatchesExpected(templateFileName: "ReturnsToCompare.html", type: "returns", compareTo: this.returnsNode);


            int[] neededNodes = new int[] {1, 3, 5, 7, 9, 11, };

            HtmlNode list = ChangeNodeToList(this.returnsNode.SelectSingleNode("//td"), neededNodes);

            list.ChildNodes[3].InnerHtml = list.ChildNodes[3].InnerHtml.Split(new string[] { "at contact@creationwatches.com" }, StringSplitOptions.None)[0];
            list.RemoveChild(list.ChildNodes[5]);

            return list;
        }

        private HtmlNode GetPage(string url)
        {
            string response = Utilities.Get(url);
            HtmlAgilityPack.HtmlDocument returnsDoc = new HtmlAgilityPack.HtmlDocument();
            returnsDoc.LoadHtml(response);
            return Utilities.FindNodes(returnsDoc, "//div[@class='section']")[0];
        }

        private void VerifyMatchesExpected(string templateFileName, string type, HtmlNode compareTo)
        {
            string TemplatePath = Path.Combine(this.warrantyAndReturnsTemplatesPath, templateFileName);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(TemplatePath);
            string htmlAsStringFromTemplate = doc.Text.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            string htmlAsStringToCompare = compareTo.WriteTo().Replace("\r", "").Replace("\n", "").Replace("\t", "");

            if (htmlAsStringFromTemplate != htmlAsStringToCompare)
            {
                Utilities.RaiseAlert($"It seems that the {type} document was changed by the supplier!! " +
                    $"Please verify the changes compared to the template ({TemplatePath})");
            }
        }


        private HtmlNode ChangeNodeToList(HtmlNode node, int [] neededNodes)
        {
            HtmlNode listNode = HtmlNode.CreateNode("<ul></ul>");

            foreach (int index in neededNodes)
            {
                listNode.AppendChild(node.ChildNodes[index]);
            }
            return listNode;
        }
    }
}
