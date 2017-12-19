using Anotar.Log4Net;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Windows.Forms;

namespace TibiaHighscoreApp
{
    public partial class TibiaHighscoreTopPlayersWindow : Form
    {
        private readonly string _urlGetCharacter = "https://secure.tibia.com/community/?subtopic=characters&name=";
        public TibiaHighscoreTopPlayersWindow(object characterName)
        {
            InitializeComponent();
            InitializeValues(characterName);
        }

        private void InitializeValues(object character)
        {
            try
            {
                var res = new HttpWebService(_urlGetCharacter + character);
                //res.getNode("//div[contains(@class, 'Border_3')]");

                // TODO: Can find xpath but not child elements inside.
                HtmlNodeCollection temp = res.getNodes("//div[contains(@class, 'BoxContent')]");
                Console.Out.WriteLine(temp.ToString());
            }
            catch (WebException ex)
            {
                HttpWebResponse eResponse = ex.Response as HttpWebResponse;
                if (eResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    LogTo.Debug("Http statuscode 403 was received while requesting charactername.");
                }
            }
        }

        private void TibiaHighscoreTopPlayers_Load(object sender, EventArgs e)
        {
            // TODO: Stuff before window is showed.
        }
    }
}
