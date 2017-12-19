using Anotar.Log4Net;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TibiaHighscoreApp
{
    public partial class TibiaHighscoreMainWindow : Form
    {
        private readonly string _urlWorlds = "http://www.tibia.com/community/?subtopic=worlds";
        private readonly string _urlTopPlayers = "https://secure.tibia.com/community/?subtopic=highscores&world=";
        private HtmlNodeCollection _worlds;
        private TibiaHighscoreTopPlayersWindow _topPlayersWindow;


        public TibiaHighscoreMainWindow()
        {
            InitializeComponent();
        }

        private void TibiaHighscoreMainWindow_Load(object sender, EventArgs e)
        {
            var res = new HttpWebService(_urlWorlds);
            _worlds = res.getNodes("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=worlds&world=')]");
        }

        private bool CheckIfLBLoaded()
        {
            if (lbWorlds.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to re-load the listbox?",
                    "ListBox Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lbWorlds.Items.Clear();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void BtnLoadWorlds_Click(object sender, EventArgs e)
        {
            if (CheckIfLBLoaded())
            {
                LoadListBox(_worlds);
            }
        }

        private void BtnTopPlayers_Click(object sender, EventArgs e)
        {
            // TODO:    Load top players for each world in mainwindow, 
            //          select first index and display info in new topplayerswindow.
            if (CheckIfLBLoaded())
            {
                HtmlNodeCollection temp = new HtmlNodeCollection(null);
                foreach (var node in _worlds)
                {
                    try
                    {
                        var res = new HttpWebService(_urlTopPlayers + node.InnerText);
                        temp.Add(res.getNode("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=characters&name=')]"));
                    }
                    catch(WebException ex)
                    {
                        HttpWebResponse eResponse = ex.Response as HttpWebResponse;
                        if (eResponse.StatusCode == HttpStatusCode.Forbidden)
                        {
                            LogTo.Debug("Http statuscode 403 was received while requesting charactername.");
                        }
                    }
                }
                LoadListBox(temp);
                _topPlayersWindow = new TibiaHighscoreTopPlayersWindow(lbWorlds.SelectedItem);
                _topPlayersWindow.Show();
            }
        }

        private void LoadListBox(HtmlNodeCollection list)
        {
            foreach (var node in list)
            {
                var item = new ListBoxItem
                {
                    Content = node.InnerText
                };
                lbWorlds.Items.Add(item.Content);
            }
            lbWorlds.SelectedIndex = 0;
        }

        private void LbWorlds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
