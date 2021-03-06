﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TibiaHighscoreApp
{
    public partial class TibiaHighscoreMainWindow : Form
    {
        private readonly string _urlWorlds = "http://www.tibia.com/community/?subtopic=worlds";
        private readonly string _urlTopPlayers = "https://secure.tibia.com/community/?subtopic=highscores&world=";
        private readonly string _urlPlayerSearch = "https://secure.tibia.com/community/?subtopic=characters&name=";
        private readonly string _gbDisplayAllTopPlayers = "All top players";
        private readonly string _gbDisplayWorldTopPlayers = "World highscore: ";
        private HttpWebService _webService = new HttpWebService();
        private HtmlNodeCollection _worlds;
        private TibiaHighscoreTopPlayersWindow _topPlayersWindow;


        public TibiaHighscoreMainWindow()
        {
            InitializeComponent();
            CheckTopPlayersWindowDisposed();
            LoadWorlds();
        }

        private void LoadWorlds()
        {
            var res = _webService.SendRequest(_urlWorlds);
            _worlds = res.DocumentNode.SelectNodes("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=worlds&world=')]");
            foreach (var node in _worlds)
            {
                cbWorlds.Items.Add(node.InnerText);
            }
        }

        private void CheckTopPlayersWindowDisposed()
        {
            if (_topPlayersWindow == null)
            {
                _topPlayersWindow = new TibiaHighscoreTopPlayersWindow();
            }
            else
            {
                _topPlayersWindow.Close();
                _topPlayersWindow = new TibiaHighscoreTopPlayersWindow();
            }
        }

        private bool CheckIfLBLoaded()
        {
            if (lbMainWindow.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to re-load the listbox?",
                    "ListBox Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lbMainWindow.Items.Clear();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void BtnTopPlayers_Click(object sender, EventArgs e)
        {
            if (CheckIfLBLoaded())
            {
                CheckTopPlayersWindowDisposed();
                cbWorlds.SelectedIndex = -1;
                gbResult.Text = _gbDisplayAllTopPlayers;
                LoadTopPlayers();
            }
        }

        private void LoadTopPlayers()
        {
            System.Threading.Tasks.Task.Run(() => MessageBox.Show(
                    "This might take a minute to load..",
                    "Information"));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var temp = new Dictionary<HtmlNode, HtmlNode>();
            foreach (var node in _worlds)
            {
                while (true)
                {
                    var res = _webService.SendRequest(_urlTopPlayers + node.InnerText);
                    var item = new ListBoxItem
                    {
                        Content = node.InnerText + ": " + res.DocumentNode.SelectSingleNode("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=characters&name=')]").InnerText
                    };
                    lbMainWindow.Items.Add(item.Content);
                    break;
                }
            }
            lbMainWindow.SelectedIndex = 0;
            stopwatch.Stop();
            System.Threading.Tasks.Task.Run(() => MessageBox.Show(
                    "Elapsed time = " + stopwatch.Elapsed,
                    "Time"));
        }

        private void LbMainWindow_MouseDoubleClick(object sender, EventArgs e)
        {
            CheckTopPlayersWindowDisposed();
            var firstValue = lbMainWindow.SelectedItem.ToString().Substring(0, lbMainWindow.SelectedItem.ToString().IndexOf(":")).TrimEnd();
            var player = lbMainWindow.SelectedItem.ToString().Substring(lbMainWindow.SelectedItem.ToString().IndexOf(":") + 1).TrimStart();
            if (firstValue.Any(char.IsDigit))
            {
                SearchPlayer(player);
            }
            else
            {
                var world = firstValue;
                _topPlayersWindow.LoadWorldHighscore(world, player);
                _topPlayersWindow.Show();
            }
        }

        private void BtnPlayerSearch_Click(object sender, EventArgs e)
        {
            SearchPlayer(tbPlayerSearch.Text);
        }

        private void SearchPlayer(string player)
        {
            try
            {
                CheckTopPlayersWindowDisposed();
                var res = _webService.SendRequest(_urlPlayerSearch + player);
                var boxContent = res.DocumentNode.SelectSingleNode("//div[contains(@class, 'BoxContent')]/table[1]");
                string name = "";
                if (boxContent.ChildNodes[1].InnerText.Contains("Could not find character"))
                {
                    MessageBox.Show(
                        "No character with name: " +
                        tbPlayerSearch.Text +
                        " was found.\nPlease try again.",
                        "Could not find character");
                }
                else
                {
                    for (int i = 0; i < boxContent.ChildNodes.Count; i++)
                    {
                        if (boxContent.ChildNodes[i].InnerText.Contains("Name:"))
                        {
                            name = boxContent.ChildNodes[i].LastChild.InnerText.ToString().Trim();
                        }
                    }
                    _topPlayersWindow.LoadOtherCharacters(name);
                    _topPlayersWindow.Show();
                }
            }
            catch (NullReferenceException e2)
            {
                //Log this
                Console.Out.WriteLine("NullReferenceException caught while searching for player:\n" + e2.Message);
            }
        }

        private void TbPlayerSearch_Keydown(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)13) && (!tbPlayerSearch.Text.Equals("")))
            {
                SearchPlayer(tbPlayerSearch.Text);
            }
        }

        private void BtnShowWorld_Click(object sender, EventArgs e)
        {
            if (!(cbWorlds.Text == "") && !(cbWorlds.Text == null))
            {
                lbMainWindow.Items.Clear();
                gbResult.Text = _gbDisplayWorldTopPlayers + cbWorlds.Text;
                var res = _webService.SendRequest(_urlTopPlayers + cbWorlds.Text);
                var temp = res.DocumentNode.SelectNodes("//table[contains(@class, 'TableContent')]");
                foreach (var node in temp.Nodes())
                {
                    if (node.InnerHtml.Contains("https://secure.tibia.com/community/?subtopic=characters&name="))
                    {
                        var item = new ListBoxItem
                        {
                            Content = node.ChildNodes[0].InnerText + ". [" + node.ChildNodes[3].InnerText + "]: " + node.ChildNodes[1].InnerText
                        };
                        lbMainWindow.Items.Add(item.Content);
                    }
                }
            }
        }
    }
}
