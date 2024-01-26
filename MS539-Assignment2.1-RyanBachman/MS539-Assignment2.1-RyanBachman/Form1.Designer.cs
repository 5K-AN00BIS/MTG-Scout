
using System.Windows.Forms;

namespace MS539_Assignment2._1_RyanBachman
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
            futureLabel1 = new Label();
            label1 = new Label();
            label2 = new Label();
            searchTT = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)randomPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchPB).BeginInit();
            SuspendLayout();
            // 
            // RandomLB
            // 
            RandomLB.BackColor = System.Drawing.SystemColors.ControlDark;
            RandomLB.FormattingEnabled = true;
            RandomLB.Items.AddRange(new object[] { "Black", "White", "Green", "Blue", "Red", "Colorless", "Cost (1)", "Cost (2)", "Cost (3)", "Cost (4)", "Cost (5+)" });
            RandomLB.Location = new System.Drawing.Point(12, 12);
            RandomLB.Name = "RandomLB";
            RandomLB.Size = new System.Drawing.Size(93, 202);
            RandomLB.TabIndex = 0;
            RandomLB.SelectedIndexChanged += RandomLB_SelectedIndexChanged;
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
            // 
            // randomBtn
            // 
            randomBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            randomBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            randomBtn.Location = new System.Drawing.Point(111, 12);
            randomBtn.Name = "randomBtn";
            randomBtn.Size = new System.Drawing.Size(224, 202);
            randomBtn.TabIndex = 2;
            randomBtn.Text = "Find a Random Card!";
            randomBtn.UseVisualStyleBackColor = false;
            randomBtn.Click += randomBtn_Click;
            // 
            // searchTB
            // 
            searchTB.Location = new System.Drawing.Point(849, 12);
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
            // 
            // searchBtn
            // 
            searchBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            searchBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            searchBtn.Location = new System.Drawing.Point(849, 41);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new System.Drawing.Size(323, 173);
            searchBtn.TabIndex = 5;
            searchBtn.Text = "Search for Card!";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            searchTT.ShowAlways = true;
            searchTT.SetToolTip(searchBtn, "Search for a magic card using the textbox above. Once typed, press enter or this button to search!");
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
            // futureLabel1
            // 
            futureLabel1.AutoSize = true;
            futureLabel1.BackColor = System.Drawing.Color.Crimson;
            futureLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            futureLabel1.ForeColor = System.Drawing.SystemColors.Control;
            futureLabel1.Location = new System.Drawing.Point(159, 41);
            futureLabel1.Name = "futureLabel1";
            futureLabel1.Size = new System.Drawing.Size(118, 21);
            futureLabel1.TabIndex = 7;
            futureLabel1.Text = "Future Addition";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Crimson;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(111, 409);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 21);
            label1.TabIndex = 8;
            label1.Text = "Future Addition";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Crimson;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(2, 84);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(118, 21);
            label2.TabIndex = 9;
            label2.Text = "Future Addition";
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
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(futureLabel1);
            Controls.Add(CardDetailLB);
            Controls.Add(searchBtn);
            Controls.Add(searchPB);
            Controls.Add(searchTB);
            Controls.Add(randomBtn);
            Controls.Add(randomPB);
            Controls.Add(RandomLB);
            MaximumSize = new System.Drawing.Size(1200, 700);
            MinimumSize = new System.Drawing.Size(1200, 700);
            Name = "MTGScout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MTG Scout";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)randomPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchPB).EndInit();
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
        private Label futureLabel1;
        private Label label1;
        private Label label2;
        private ToolTip searchTT;
    }
}

