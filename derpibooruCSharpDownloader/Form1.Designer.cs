namespace derpibooruCSharpDownloader
{
    partial class Form1
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderLocationTextBox = new System.Windows.Forms.TextBox();
            this.numberOfPagesBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numPerPageBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.currentProgressLabel = new System.Windows.Forms.Label();
            this.TotalProgressLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.progressPerctLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imageWidthBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.imageHeightBox = new System.Windows.Forms.NumericUpDown();
            this.clearCacheButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.numOfPicsTotalBox = new System.Windows.Forms.NumericUpDown();
            this.orderModeComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.minRatingBox = new System.Windows.Forms.NumericUpDown();
            this.apiKeyLabel = new System.Windows.Forms.LinkLabel();
            this.clearCacheAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPagesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerPageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPicsTotalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRatingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(91, 285);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(319, 20);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Luna";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Terms";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(416, 283);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder Location";
            // 
            // folderLocationTextBox
            // 
            this.folderLocationTextBox.Location = new System.Drawing.Point(98, 12);
            this.folderLocationTextBox.Name = "folderLocationTextBox";
            this.folderLocationTextBox.Size = new System.Drawing.Size(319, 20);
            this.folderLocationTextBox.TabIndex = 3;
            this.folderLocationTextBox.TextChanged += new System.EventHandler(this.folderLocationTextBox_TextChanged);
            // 
            // numberOfPagesBox
            // 
            this.numberOfPagesBox.Location = new System.Drawing.Point(107, 45);
            this.numberOfPagesBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberOfPagesBox.Name = "numberOfPagesBox";
            this.numberOfPagesBox.Size = new System.Drawing.Size(120, 20);
            this.numberOfPagesBox.TabIndex = 6;
            this.numberOfPagesBox.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numberOfPagesBox.ValueChanged += new System.EventHandler(this.numberOfPagesBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Pages";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(107, 339);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 23);
            this.progressBar.TabIndex = 8;
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Location = new System.Drawing.Point(63, 87);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.Size = new System.Drawing.Size(155, 20);
            this.apiKeyTextBox.TabIndex = 9;
            this.apiKeyTextBox.TextChanged += new System.EventHandler(this.apiKeyTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pics Per Page";
            // 
            // numPerPageBox
            // 
            this.numPerPageBox.Enabled = false;
            this.numPerPageBox.Location = new System.Drawing.Point(329, 88);
            this.numPerPageBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPerPageBox.Name = "numPerPageBox";
            this.numPerPageBox.Size = new System.Drawing.Size(61, 20);
            this.numPerPageBox.TabIndex = 11;
            this.numPerPageBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numPerPageBox.ValueChanged += new System.EventHandler(this.numPerPageBox_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "- Requires API Key";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 345);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(55, 13);
            this.progressLabel.TabIndex = 14;
            this.progressLabel.Text = "Searching";
            // 
            // currentProgressLabel
            // 
            this.currentProgressLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentProgressLabel.Location = new System.Drawing.Point(185, 323);
            this.currentProgressLabel.Name = "currentProgressLabel";
            this.currentProgressLabel.Size = new System.Drawing.Size(73, 13);
            this.currentProgressLabel.TabIndex = 15;
            this.currentProgressLabel.Text = "0";
            this.currentProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalProgressLabel
            // 
            this.TotalProgressLabel.Location = new System.Drawing.Point(269, 323);
            this.TotalProgressLabel.Name = "TotalProgressLabel";
            this.TotalProgressLabel.Size = new System.Drawing.Size(73, 13);
            this.TotalProgressLabel.TabIndex = 16;
            this.TotalProgressLabel.Text = "0";
            this.TotalProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(255, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "/";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressPerctLabel
            // 
            this.progressPerctLabel.Location = new System.Drawing.Point(348, 323);
            this.progressPerctLabel.Name = "progressPerctLabel";
            this.progressPerctLabel.Size = new System.Drawing.Size(29, 13);
            this.progressPerctLabel.TabIndex = 18;
            this.progressPerctLabel.Text = "0";
            this.progressPerctLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(373, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "%";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Width";
            // 
            // imageWidthBox
            // 
            this.imageWidthBox.Location = new System.Drawing.Point(53, 144);
            this.imageWidthBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imageWidthBox.Name = "imageWidthBox";
            this.imageWidthBox.Size = new System.Drawing.Size(61, 20);
            this.imageWidthBox.TabIndex = 20;
            this.imageWidthBox.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.imageWidthBox.ValueChanged += new System.EventHandler(this.imageWidthBox_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Image Resolution";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(137, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Height";
            // 
            // imageHeightBox
            // 
            this.imageHeightBox.Location = new System.Drawing.Point(178, 144);
            this.imageHeightBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imageHeightBox.Name = "imageHeightBox";
            this.imageHeightBox.Size = new System.Drawing.Size(61, 20);
            this.imageHeightBox.TabIndex = 23;
            this.imageHeightBox.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.imageHeightBox.ValueChanged += new System.EventHandler(this.imageHeightBox_ValueChanged);
            // 
            // clearCacheButton
            // 
            this.clearCacheButton.Location = new System.Drawing.Point(10, 229);
            this.clearCacheButton.Name = "clearCacheButton";
            this.clearCacheButton.Size = new System.Drawing.Size(75, 23);
            this.clearCacheButton.TabIndex = 25;
            this.clearCacheButton.Text = "Clear Cache";
            this.clearCacheButton.UseVisualStyleBackColor = true;
            this.clearCacheButton.Click += new System.EventHandler(this.clearCacheButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(253, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Number of Pics";
            // 
            // numOfPicsTotalBox
            // 
            this.numOfPicsTotalBox.Location = new System.Drawing.Point(348, 46);
            this.numOfPicsTotalBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOfPicsTotalBox.Name = "numOfPicsTotalBox";
            this.numOfPicsTotalBox.Size = new System.Drawing.Size(120, 20);
            this.numOfPicsTotalBox.TabIndex = 26;
            this.numOfPicsTotalBox.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numOfPicsTotalBox.ValueChanged += new System.EventHandler(this.numOfPicsTotalBox_ValueChanged);
            // 
            // orderModeComboBox
            // 
            this.orderModeComboBox.FormattingEnabled = true;
            this.orderModeComboBox.Items.AddRange(new object[] {
            "Rating",
            "Newest",
            "Oldest",
            "Favorites",
            "Random"});
            this.orderModeComboBox.Location = new System.Drawing.Point(371, 142);
            this.orderModeComboBox.Name = "orderModeComboBox";
            this.orderModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderModeComboBox.TabIndex = 28;
            this.orderModeComboBox.Text = "Rating";
            this.orderModeComboBox.SelectedIndexChanged += new System.EventHandler(this.orderModeComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(371, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ordering";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(371, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Min Rating";
            // 
            // minRatingBox
            // 
            this.minRatingBox.Location = new System.Drawing.Point(430, 169);
            this.minRatingBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minRatingBox.Name = "minRatingBox";
            this.minRatingBox.Size = new System.Drawing.Size(61, 20);
            this.minRatingBox.TabIndex = 30;
            this.minRatingBox.ValueChanged += new System.EventHandler(this.minRatingBox_ValueChanged);
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Location = new System.Drawing.Point(12, 91);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(45, 13);
            this.apiKeyLabel.TabIndex = 32;
            this.apiKeyLabel.TabStop = true;
            this.apiKeyLabel.Text = "API Key";
            this.apiKeyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.apiKeyLabel_LinkClicked);
            // 
            // clearCacheAllButton
            // 
            this.clearCacheAllButton.BackColor = System.Drawing.Color.Maroon;
            this.clearCacheAllButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearCacheAllButton.Location = new System.Drawing.Point(91, 229);
            this.clearCacheAllButton.Name = "clearCacheAllButton";
            this.clearCacheAllButton.Size = new System.Drawing.Size(91, 23);
            this.clearCacheAllButton.TabIndex = 33;
            this.clearCacheAllButton.Text = "Clear Cache All";
            this.clearCacheAllButton.UseVisualStyleBackColor = false;
            this.clearCacheAllButton.Click += new System.EventHandler(this.clearCacheAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 374);
            this.Controls.Add(this.clearCacheAllButton);
            this.Controls.Add(this.apiKeyLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.minRatingBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.orderModeComboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numOfPicsTotalBox);
            this.Controls.Add(this.clearCacheButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.imageHeightBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.imageWidthBox);
            this.Controls.Add(this.progressPerctLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TotalProgressLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.currentProgressLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numPerPageBox);
            this.Controls.Add(this.apiKeyTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfPagesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folderLocationTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Name = "Form1";
            this.Text = "Derpiboo.ru Downloader by Natfoth";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPagesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerPageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPicsTotalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRatingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox searchTextBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button searchButton;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox folderLocationTextBox;
        public System.Windows.Forms.NumericUpDown numberOfPagesBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.TextBox apiKeyTextBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown numPerPageBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label progressLabel;
        public System.Windows.Forms.Label currentProgressLabel;
        public System.Windows.Forms.Label TotalProgressLabel;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label progressPerctLabel;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown imageWidthBox;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.NumericUpDown imageHeightBox;
        public System.Windows.Forms.Button clearCacheButton;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown numOfPicsTotalBox;
        private System.Windows.Forms.ComboBox orderModeComboBox;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.NumericUpDown minRatingBox;
        private System.Windows.Forms.LinkLabel apiKeyLabel;
        public System.Windows.Forms.Button clearCacheAllButton;
    }
}

