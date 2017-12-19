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
            this.btnLoadWorlds = new System.Windows.Forms.Button();
            this.btnTopPlayers = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbWorlds = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLoadWorlds
            // 
            this.btnLoadWorlds.Location = new System.Drawing.Point(13, 13);
            this.btnLoadWorlds.Name = "btnLoadWorlds";
            this.btnLoadWorlds.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWorlds.TabIndex = 0;
            this.btnLoadWorlds.Text = "Load Worlds";
            this.btnLoadWorlds.UseVisualStyleBackColor = true;
            this.btnLoadWorlds.Click += new System.EventHandler(this.BtnLoadWorlds_Click);
            // 
            // btnTopPlayers
            // 
            this.btnTopPlayers.Location = new System.Drawing.Point(95, 13);
            this.btnTopPlayers.Name = "btnTopPlayers";
            this.btnTopPlayers.Size = new System.Drawing.Size(75, 23);
            this.btnTopPlayers.TabIndex = 1;
            this.btnTopPlayers.Text = "Top Players";
            this.btnTopPlayers.UseVisualStyleBackColor = true;
            this.btnTopPlayers.Click += new System.EventHandler(this.BtnTopPlayers_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(177, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lbWorlds
            // 
            this.lbWorlds.FormattingEnabled = true;
            this.lbWorlds.Location = new System.Drawing.Point(13, 43);
            this.lbWorlds.Name = "lbWorlds";
            this.lbWorlds.Size = new System.Drawing.Size(242, 212);
            this.lbWorlds.TabIndex = 3;
            this.lbWorlds.SelectedIndexChanged += new System.EventHandler(this.LbWorlds_SelectedIndexChanged);
            // 
            // TibiaHighscoreWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 261);
            this.Controls.Add(this.lbWorlds);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTopPlayers);
            this.Controls.Add(this.btnLoadWorlds);
            this.Name = "TibiaHighscoreWindow";
            this.Text = "Tibia Highscore";
            this.Load += new System.EventHandler(this.TibiaHighscoreMainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadWorlds;
        private System.Windows.Forms.Button btnTopPlayers;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox lbWorlds;
    }
}

