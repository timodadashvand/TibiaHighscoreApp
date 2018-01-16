﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TibiaHighscoreApp
{
    public partial class TibiaHighscoreMainWindow : Form
    {
        private readonly string _urlWorlds = "http://www.tibia.com/community/?subtopic=worlds";
        private readonly string _urlTopPlayers = "https://secure.tibia.com/community/?subtopic=highscores&world=";
        private readonly string _urlPlayerSearch = "https://secure.tibia.com/community/?subtopic=characters&name=";
        private HtmlNodeCollection _worlds;
        private TibiaHighscoreTopPlayersWindow _topPlayersWindow;


        public TibiaHighscoreMainWindow()
        {
            InitializeComponent();
            CheckTopPlayersWindowDisposed();
        }

        private void TibiaHighscoreMainWindow_Load(object sender, EventArgs e)
        {
            var res = new HttpWebService(_urlWorlds);
            _worlds = res.getNodes("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=worlds&world=')]");
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
                LoadTopPlayers();
            }
        }

        private void LoadTopPlayers()
        {
            System.Threading.Tasks.Task.Run(() => MessageBox.Show(
                    "This might take a minute to load..",
                    "Information"));
            var temp = new Dictionary<HtmlNode, HtmlNode>();
            foreach (var node in _worlds)
            {
                while (true)
                {
                    var res = new HttpWebService(_urlTopPlayers + node.InnerText);
                    temp.Add(node, res.getNode("//a[contains(@href, 'https://secure.tibia.com/community/?subtopic=characters&name=')]"));
                    break;
                }
            }
            LoadListBox(temp);
        }

        private void LbMainWindow_MouseDoubleClick(object sender, EventArgs e)
        {
            CheckTopPlayersWindowDisposed();
            var player = lbMainWindow.SelectedItem.ToString().Substring(lbMainWindow.SelectedItem.ToString().IndexOf(":") + 1).TrimStart();
            var world = lbMainWindow.SelectedItem.ToString().Substring(0, lbMainWindow.SelectedItem.ToString().IndexOf(":")).TrimEnd();
            _topPlayersWindow.LoadWorldHighscore(world, player);
            _topPlayersWindow.Show();
        }

        private void LoadListBox(Dictionary<HtmlNode, HtmlNode> list)
        {
            try
            {
                foreach (var node in list)
                {
                    var item = new ListBoxItem
                    {
                        Content = node.Key.InnerText + ": " + node.Value.InnerText
                    };
                    lbMainWindow.Items.Add(item.Content);
                }
                lbMainWindow.SelectedIndex = 0;
            }
            catch (NullReferenceException e)
            {
                //Log this with logger
                Console.Out.WriteLine("NullReferenceException caught while loading listbox:\n" + e.Message);
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
                var res = new HttpWebService(_urlPlayerSearch + player);
                var boxContent = res.getNode("//div[contains(@class, 'BoxContent')]/table[1]");
                string name = "";
                if (boxContent.InnerText.Contains("Could not find character"))
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
    }
}