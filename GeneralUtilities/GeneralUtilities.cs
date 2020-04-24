using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GeneralUtilities
{

    public class Utilities
    {
        public static void RaiseAlert(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static HtmlNodeCollection FindNodes(HtmlAgilityPack.HtmlDocument document, string xpath, bool raiseException = true)
        {
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(xpath);

            if (nodes == null && raiseException)
            {
                RaiseAlert($"Failed to find xpath: '{xpath}'");
                Application.Exit();
            }
            return nodes;
        }

        public static void OpenLink(string link)
        {
            System.Diagnostics.Process.Start(link);
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
    
}

