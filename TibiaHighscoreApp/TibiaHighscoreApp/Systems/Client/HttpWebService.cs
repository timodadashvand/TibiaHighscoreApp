using HtmlAgilityPack;
using System.IO;
using System.Net;

namespace TibiaHighscoreApp
{
    class HttpWebService
    {
        private HtmlDocument _document;

        public HtmlDocument SendRequest(string url)
        {
            _document = new HtmlDocument();
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Empty;
            _document.OptionWriteEmptyNodes = true;

            while (true)
            {
                try
                {
                    var webRequest = HttpWebRequest.Create(url);
                    Stream stream = webRequest.GetResponse().GetResponseStream();
                    _document.Load(stream);
                    stream.Close();
                    break;
                }
                catch (System.UriFormatException uex)
                {
                    //LogTo.Fatal("There was an error in the format of the url: " + url, uex);
                    System.Console.Out.WriteLine("UriFormatException caught while making HttpWebRequest:\n" + uex.Message);
                }
                catch (WebException wex)
                {
                    //LogTo.Fatal("There was an error connecting to the url: " + url, wex);
                    System.Console.Out.WriteLine("WebException caught while making HttpWebRequest:\n" + wex.Message);
                }
            }
            return this._document;
        }
    }
}
