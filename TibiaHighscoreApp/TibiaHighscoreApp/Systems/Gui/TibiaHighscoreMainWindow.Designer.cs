namespace TibiaHighscoreApp
{
    partial class TibiaHighscoreMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TibiaHighscoreMainWindow));
            this.btnTopPlayers = new System.Windows.Forms.Button();
            this.btnPlayerSearch = new System.Windows.Forms.Button();
            this.lbMainWindow = new System.Windows.Forms.ListBox();
            this.tbPlayerSearch = new System.Windows.Forms.TextBox();
            this.gbCharacterSearch = new System.Windows.Forms.GroupBox();
            this.gpTopPlayers = new System.Windows.Forms.GroupBox();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.btnShowWorld = new System.Windows.Forms.Button();
            this.cbWorlds = new System.Windows.Forms.ComboBox();
            this.gbCharacterSearch.SuspendLayout();
            this.gpTopPlayers.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTopPlayers
            // 
            this.btnTopPlayers.Location = new System.Drawing.Point(6, 19);
            this.btnTopPlayers.Name = "btnTopPlayers";
            this.btnTopPlayers.Size = new System.Drawing.Size(242, 23);
            this.btnTopPlayers.TabIndex = 1;
            this.btnTopPlayers.Text = "Top Players";
            this.btnTopPlayers.UseVisualStyleBackColor = true;
            this.btnTopPlayers.Click += new System.EventHandler(this.BtnTopPlayers_Click);
            // 
            // btnPlayerSearch
            // 
            this.btnPlayerSearch.Location = new System.Drawing.Point(173, 16);
            this.btnPlayerSearch.Name = "btnPlayerSearch";
            this.btnPlayerSearch.Size = new System.Drawing.Size(75, 23);
            this.btnPlayerSearch.TabIndex = 2;
            this.btnPlayerSearch.Text = "Search";
            this.btnPlayerSearch.UseVisualStyleBackColor = true;
            this.btnPlayerSearch.Click += new System.EventHandler(this.BtnPlayerSearch_Click);
            // 
            // lbMainWindow
            // 
            this.lbMainWindow.FormattingEnabled = true;
            this.lbMainWindow.Location = new System.Drawing.Point(6, 19);
            this.lbMainWindow.Name = "lbMainWindow";
            this.lbMainWindow.Size = new System.Drawing.Size(230, 212);
            this.lbMainWindow.TabIndex = 3;
            this.lbMainWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbMainWindow_MouseDoubleClick);
            // 
            // tbPlayerSearch
            // 
            this.tbPlayerSearch.Location = new System.Drawing.Point(6, 16);
            this.tbPlayerSearch.Name = "tbPlayerSearch";
            this.tbPlayerSearch.Size = new System.Drawing.Size(161, 20);
            this.tbPlayerSearch.TabIndex = 4;
            this.tbPlayerSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPlayerSearch_Keydown);
            // 
            // gbCharacterSearch
            // 
            this.gbCharacterSearch.Controls.Add(this.tbPlayerSearch);
            this.gbCharacterSearch.Controls.Add(this.btnPlayerSearch);
            this.gbCharacterSearch.Location = new System.Drawing.Point(0, 0);
            this.gbCharacterSearch.Name = "gbCharacterSearch";
            this.gbCharacterSearch.Size = new System.Drawing.Size(255, 47);
            this.gbCharacterSearch.TabIndex = 5;
            this.gbCharacterSearch.TabStop = false;
            this.gbCharacterSearch.Text = "Character search";
            // 
            // gpTopPlayers
            // 
            this.gpTopPlayers.Controls.Add(this.gbResult);
            this.gpTopPlayers.Controls.Add(this.btnShowWorld);
            this.gpTopPlayers.Controls.Add(this.cbWorlds);
            this.gpTopPlayers.Controls.Add(this.btnTopPlayers);
            this.gpTopPlayers.Location = new System.Drawing.Point(0, 53);
            this.gpTopPlayers.Name = "gpTopPlayers";
            this.gpTopPlayers.Size = new System.Drawing.Size(255, 323);
            this.gpTopPlayers.TabIndex = 6;
            this.gpTopPlayers.TabStop = false;
            this.gpTopPlayers.Text = "Highscore";
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.lbMainWindow);
            this.gbResult.Location = new System.Drawing.Point(6, 78);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(242, 238);
            this.gbResult.TabIndex = 7;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // btnShowWorld
            // 
            this.btnShowWorld.Location = new System.Drawing.Point(173, 49);
            this.btnShowWorld.Name = "btnShowWorld";
            this.btnShowWorld.Size = new System.Drawing.Size(75, 23);
            this.btnShowWorld.TabIndex = 5;
            this.btnShowWorld.Text = "Show";
            this.btnShowWorld.UseVisualStyleBackColor = true;
            this.btnShowWorld.Click += new System.EventHandler(this.BtnShowWorld_Click);
            // 
            // cbWorlds
            // 
            this.cbWorlds.BackColor = System.Drawing.SystemColors.Window;
            this.cbWorlds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorlds.FormattingEnabled = true;
            this.cbWorlds.Location = new System.Drawing.Point(7, 49);
            this.cbWorlds.Name = "cbWorlds";
            this.cbWorlds.Size = new System.Drawing.Size(160, 21);
            this.cbWorlds.TabIndex = 4;
            // 
            // TibiaHighscoreMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 373);
            this.Controls.Add(this.gpTopPlayers);
            this.Controls.Add(this.gbCharacterSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TibiaHighscoreMainWindow";
            this.Text = "Tibia Highscore";
            this.gbCharacterSearch.ResumeLayout(false);
            this.gbCharacterSearch.PerformLayout();
            this.gpTopPlayers.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTopPlayers;
        private System.Windows.Forms.Button btnPlayerSearch;
        private System.Windows.Forms.ListBox lbMainWindow;
        private System.Windows.Forms.TextBox tbPlayerSearch;
        private System.Windows.Forms.GroupBox gbCharacterSearch;
        private System.Windows.Forms.GroupBox gpTopPlayers;
        private System.Windows.Forms.Button btnShowWorld;
        private System.Windows.Forms.ComboBox cbWorlds;
        private System.Windows.Forms.GroupBox gbResult;
    }
}

