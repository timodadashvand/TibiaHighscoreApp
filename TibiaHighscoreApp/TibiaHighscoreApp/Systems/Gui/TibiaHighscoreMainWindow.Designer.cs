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
            this.btnTopPlayers = new System.Windows.Forms.Button();
            this.btnPlayerSearch = new System.Windows.Forms.Button();
            this.lbMainWindow = new System.Windows.Forms.ListBox();
            this.tbPlayerSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTopPlayers
            // 
            this.btnTopPlayers.Location = new System.Drawing.Point(13, 39);
            this.btnTopPlayers.Name = "btnTopPlayers";
            this.btnTopPlayers.Size = new System.Drawing.Size(242, 23);
            this.btnTopPlayers.TabIndex = 1;
            this.btnTopPlayers.Text = "Top Players";
            this.btnTopPlayers.UseVisualStyleBackColor = true;
            this.btnTopPlayers.Click += new System.EventHandler(this.BtnTopPlayers_Click);
            // 
            // btnPlayerSearch
            // 
            this.btnPlayerSearch.Location = new System.Drawing.Point(180, 12);
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
            this.lbMainWindow.Location = new System.Drawing.Point(13, 69);
            this.lbMainWindow.Name = "lbMainWindow";
            this.lbMainWindow.Size = new System.Drawing.Size(242, 225);
            this.lbMainWindow.TabIndex = 3;
            this.lbMainWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbMainWindow_MouseDoubleClick);
            // 
            // tbPlayerSearch
            // 
            this.tbPlayerSearch.Location = new System.Drawing.Point(13, 13);
            this.tbPlayerSearch.Name = "tbPlayerSearch";
            this.tbPlayerSearch.Size = new System.Drawing.Size(161, 20);
            this.tbPlayerSearch.TabIndex = 4;
            this.tbPlayerSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPlayerSearch_Keydown);
            // 
            // TibiaHighscoreMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 306);
            this.Controls.Add(this.tbPlayerSearch);
            this.Controls.Add(this.lbMainWindow);
            this.Controls.Add(this.btnPlayerSearch);
            this.Controls.Add(this.btnTopPlayers);
            this.Name = "TibiaHighscoreMainWindow";
            this.Text = "Tibia Highscore";
            this.Load += new System.EventHandler(this.TibiaHighscoreMainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTopPlayers;
        private System.Windows.Forms.Button btnPlayerSearch;
        private System.Windows.Forms.ListBox lbMainWindow;
        private System.Windows.Forms.TextBox tbPlayerSearch;
    }
}

