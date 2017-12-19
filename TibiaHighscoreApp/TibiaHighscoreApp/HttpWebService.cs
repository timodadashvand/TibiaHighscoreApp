using Anotar.Log4Net;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text;

namespace TibiaHighscoreApp
{
    class HttpWebService
    {
        private HtmlDocument _document;

        public HttpWebService(string url)
        {
            _document = new HtmlDocument();
            HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            _document.OptionWriteEmptyNodes = true;

            try
            {
                var webRequest = HttpWebRequest.Create(url);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                _document.Load(stream);
                stream.Close();
            }
            catch (System.UriFormatException uex)
            {
                LogTo.Fatal("There was an error in the format of the url: " + url, uex);
                throw;
            }
            catch (System.Net.WebException wex)
            {
                LogTo.Fatal("There was an error connecting to the url: " + url, wex);
                throw;
            }
        }

        public HtmlNode getNode(string xpath)
        {
            return _document.DocumentNode.SelectSingleNode(xpath);
        }

        public HtmlNodeCollection getNodes(string xpath)
        {
            var nodes = _document.DocumentNode.SelectNodes(xpath);
            return nodes;
        }
    }
}
