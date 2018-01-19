using HtmlAgilityPack;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TibiaHighscoreApp
{
    public partial class TibiaHighscoreTopPlayersWindow : Form
    {
        private readonly string _urlGetCharacter = "https://secure.tibia.com/community/?subtopic=characters&name=";
        private readonly string _urlGetWorldHighscore = "https://secure.tibia.com/community/?subtopic=highscores&world=";
        private HttpWebService _webService = new HttpWebService();

        public TibiaHighscoreTopPlayersWindow()
        {
            InitializeComponent();
        }

        public void ShowPlayerInfo(object character)
        {
            try
            {
                var res = _webService.SendRequest(_urlGetCharacter + character);
                HtmlNodeCollection temp = res.DocumentNode.SelectNodes("//div[contains(@class, 'BoxContent')]/table[1]");
                lblFormerNamesVar.Text = "None";
                lblFormerWorldVar.Text = "None";
                lblGuildVar.Text = "None";
                foreach (var node in temp.Nodes())
                {
                    if (node.FirstChild.InnerText.Equals("Name:"))
                    {
                        lblNameVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Former Names:"))
                    {
                        lblFormerNamesVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Sex:"))
                    {
                        lblSexVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Vocation:"))
                    {
                        lblVocationVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Level:"))
                    {
                        lblLevelVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Achievement Points:"))
                    {
                        lblAchPointsVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("World:"))
                    {
                        lblWorldVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Former World:"))
                    {
                        lblFormerWorldVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Residence:"))
                    {
                        lblResidenceVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Guild&#160;Membership:"))
                    {
                        lblGuildVar.Text = node.LastChild.InnerText.Replace("&#160;"," ").TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Last Login:"))
                    {
                        lblLastLoginVar.Text = node.LastChild.InnerText.Replace("&#160;", " ").TrimEnd();
                    }
                    else if (node.FirstChild.InnerText.Equals("Account&#160;Status:"))
                    {
                        lblAccountStatusVar.Text = node.LastChild.InnerText.TrimEnd();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                //Log this in logger
                Console.Out.WriteLine("NullReferenceException caught while setting labels:\n" + e.Message);
            }
        }

        public void LoadWorldHighscore(string world, string player)
        {
            var res = _webService.SendRequest(_urlGetWorldHighscore + world);
            this.Text = "Top Players - " + world;
            var temp = res.DocumentNode.SelectNodes("//table[contains(@class, 'TableContent')]");
            foreach (var node in temp.Nodes())
            {
                if (node.InnerHtml.Contains("https://secure.tibia.com/community/?subtopic=characters&name="))
                {
                    var item = new ListBoxItem
                    {
                        Content = node.ChildNodes[3].InnerText + ": " + node.ChildNodes[1].InnerText
                    };
                    lbTopPlayers.Items.Add(item.Content);
                }
            }
            ShowPlayerInfo(player);
        }

        public void LoadOtherCharacters(string player)
        {
            var res = _webService.SendRequest(_urlGetCharacter + player);
            this.Text = "Character Info: " + player;
            var temp = res.DocumentNode.SelectNodes("//div[contains(@class, 'BoxContent')]/table[5]");
            if (!(temp == null))
            {
                foreach (var node in temp.Nodes())
                {
                    if (node.FirstChild.InnerText.Contains("."))
                    {
                        var item = new ListBoxItem
                        {
                            Content = node.FirstChild.InnerText.Replace("&#160;", " ").Substring(node.FirstChild.InnerText.IndexOf(".") + 1).TrimStart().TrimEnd()
                        };
                        lbTopPlayers.Items.Add(item.Content);
                    }
                }
            }
            else
            {
                var item = new ListBoxItem
                {
                    Content = "No other characters"
                };
                lbTopPlayers.Items.Add(item.Content);
            }
            ShowPlayerInfo(player);
        }

        private void LbTopPlayers_MouseDoubleClick(object sender, EventArgs e)
        {
            if (!lbTopPlayers.SelectedItem.Equals("No other characters"))
            {
                var player = lbTopPlayers.SelectedItem.ToString().Substring(lbTopPlayers.SelectedItem.ToString().IndexOf(":") + 1).TrimStart();
                ShowPlayerInfo(player);
            }
        }

            private void TibiaHighscoreTopPlayers_Load(object sender, EventArgs e)
        {
            // TODO: Stuff before window is showed.
        }
    }
}
