
using System.Windows.Forms;

namespace MS539_Assignment3._1_RyanBachman
{
    partial class MTGScout
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            RandomLB = new CheckedListBox();
            randomPB = new PictureBox();
            randomBtn = new Button();
            searchTB = new TextBox();
            searchPB = new PictureBox();
            searchBtn = new Button();
            CardDetailLB = new ListBox();
            searchTT = new ToolTip(components);
            randomTT = new ToolTip(components);
            menuStrip = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            exitApplicationToolStripMenuItem = new ToolStripMenuItem();
            windowsToolStripMenuItem = new ToolStripMenuItem();
            top10PricesSetToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)randomPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchPB).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // RandomLB
            // 
            RandomLB.BackColor = System.Drawing.SystemColors.ControlDark;
            RandomLB.CheckOnClick = true;
            RandomLB.FormattingEnabled = true;
            RandomLB.Items.AddRange(new object[] { "Black", "White", "Green", "Blue", "Red" });
            RandomLB.Location = new System.Drawing.Point(12, 86);
            RandomLB.Name = "RandomLB";
            RandomLB.Size = new System.Drawing.Size(93, 94);
            RandomLB.TabIndex = 0;
            // 
            // randomPB
            // 
            randomPB.BackColor = System.Drawing.Color.SeaShell;
            randomPB.Location = new System.Drawing.Point(12, 220);
            randomPB.Name = "randomPB";
            randomPB.Size = new System.Drawing.Size(323, 429);
            randomPB.SizeMode = PictureBoxSizeMode.StretchImage;
            randomPB.TabIndex = 1;
            randomPB.TabStop = false;
            randomPB.Visible = false;
            // 
            // randomBtn
            // 
            randomBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            randomBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            randomBtn.Location = new System.Drawing.Point(111, 61);
            randomBtn.Name = "randomBtn";
            randomBtn.Size = new System.Drawing.Size(224, 153);
            randomBtn.TabIndex = 2;
            randomBtn.Text = "Find a Random Card!";
            randomTT.SetToolTip(randomBtn, "If desired, select filters on the left and click this button to get a random card!");
            randomBtn.UseVisualStyleBackColor = false;
            randomBtn.Click += randomBtn_Click;
            // 
            // searchTB
            // 
            searchTB.Location = new System.Drawing.Point(849, 32);
            searchTB.Name = "searchTB";
            searchTB.PlaceholderText = "Search a Card Name here!";
            searchTB.Size = new System.Drawing.Size(323, 23);
            searchTB.TabIndex = 3;
            searchTB.KeyDown += searchTB_KeyDown;
            // 
            // searchPB
            // 
            searchPB.BackColor = System.Drawing.Color.SeaShell;
            searchPB.Location = new System.Drawing.Point(849, 220);
            searchPB.Name = "searchPB";
            searchPB.Size = new System.Drawing.Size(323, 429);
            searchPB.SizeMode = PictureBoxSizeMode.StretchImage;
            searchPB.TabIndex = 4;
            searchPB.TabStop = false;
            searchPB.Visible = false;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            searchBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            searchBtn.Location = new System.Drawing.Point(849, 61);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new System.Drawing.Size(323, 153);
            searchBtn.TabIndex = 5;
            searchBtn.Text = "Search for Card!";
            searchTT.SetToolTip(searchBtn, "Search for a magic card using the textbox above. Once typed, press enter or this button to search!");
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // CardDetailLB
            // 
            CardDetailLB.BackColor = System.Drawing.SystemColors.InactiveCaption;
            CardDetailLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            CardDetailLB.FormattingEnabled = true;
            CardDetailLB.HorizontalExtent = 1200;
            CardDetailLB.HorizontalScrollbar = true;
            CardDetailLB.ItemHeight = 21;
            CardDetailLB.Location = new System.Drawing.Point(341, 220);
            CardDetailLB.Name = "CardDetailLB";
            CardDetailLB.Size = new System.Drawing.Size(502, 424);
            CardDetailLB.TabIndex = 6;
            // 
            // searchTT
            // 
            searchTT.ShowAlways = true;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, windowsToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(1184, 24);
            menuStrip.TabIndex = 7;
            menuStrip.Text = "Menu";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitApplicationToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // exitApplicationToolStripMenuItem
            // 
            exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitApplicationToolStripMenuItem.Text = "Exit Application";
            exitApplicationToolStripMenuItem.Click += exitApplicationToolStripMenuItem_Click;
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { top10PricesSetToolStripMenuItem });
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            windowsToolStripMenuItem.Text = "Windows";
            // 
            // top10PricesSetToolStripMenuItem
            // 
            top10PricesSetToolStripMenuItem.Name = "top10PricesSetToolStripMenuItem";
            top10PricesSetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            top10PricesSetToolStripMenuItem.Text = "Top 10 Prices (Set)";
            top10PricesSetToolStripMenuItem.Click += top10PricesSetToolStripMenuItem_Click;
            // 
            // MTGScout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = System.Drawing.Color.Tan;
            BackgroundImage = Properties.Resources.en_articles_archive_feature_ultimate_masters_art_descriptions_2018_12_04_meta_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1184, 661);
            Controls.Add(CardDetailLB);
            Controls.Add(searchBtn);
            Controls.Add(searchPB);
            Controls.Add(searchTB);
            Controls.Add(randomBtn);
            Controls.Add(randomPB);
            Controls.Add(RandomLB);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MaximumSize = new System.Drawing.Size(1200, 700);
            MinimumSize = new System.Drawing.Size(1200, 700);
            Name = "MTGScout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MTG Scout";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)randomPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchPB).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckedListBox RandomLB;
        private System.Windows.Forms.PictureBox randomPB;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.PictureBox searchPB;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ListBox CardDetailLB;
        private ToolTip searchTT;
        private ToolTip randomTT;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem exitApplicationToolStripMenuItem;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem top10PricesSetToolStripMenuItem;
    }
}

