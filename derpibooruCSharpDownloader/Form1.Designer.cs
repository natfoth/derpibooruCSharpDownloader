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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rate5StarButton = new System.Windows.Forms.Button();
            this.rate4StarButton = new System.Windows.Forms.Button();
            this.rate3StarButton = new System.Windows.Forms.Button();
            this.rate2StarButton = new System.Windows.Forms.Button();
            this.rate1StarButton = new System.Windows.Forms.Button();
            this.deletePictureButton = new System.Windows.Forms.Button();
            this.previousPictureButton = new System.Windows.Forms.Button();
            this.nextPictureButton = new System.Windows.Forms.Button();
            this.offlinePicBox = new System.Windows.Forms.PictureBox();
            this.downloadOnlyButton = new System.Windows.Forms.Button();
            this.updateDatabaseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPagesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPicsTotalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRatingBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offlinePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(85, 358);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(553, 20);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Luna";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Terms";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(644, 356);
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
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder Location";
            // 
            // folderLocationTextBox
            // 
            this.folderLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderLocationTextBox.Location = new System.Drawing.Point(92, 16);
            this.folderLocationTextBox.Name = "folderLocationTextBox";
            this.folderLocationTextBox.Size = new System.Drawing.Size(627, 20);
            this.folderLocationTextBox.TabIndex = 3;
            this.folderLocationTextBox.TextChanged += new System.EventHandler(this.folderLocationTextBox_TextChanged);
            // 
            // numberOfPagesBox
            // 
            this.numberOfPagesBox.Location = new System.Drawing.Point(101, 49);
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
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Pages";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(101, 429);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(618, 23);
            this.progressBar.TabIndex = 8;
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Location = new System.Drawing.Point(57, 91);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.Size = new System.Drawing.Size(155, 20);
            this.apiKeyTextBox.TabIndex = 9;
            this.apiKeyTextBox.TextChanged += new System.EventHandler(this.apiKeyTextBox_TextChanged);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(6, 435);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(55, 13);
            this.progressLabel.TabIndex = 14;
            this.progressLabel.Text = "Searching";
            // 
            // currentProgressLabel
            // 
            this.currentProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.currentProgressLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentProgressLabel.Location = new System.Drawing.Point(296, 413);
            this.currentProgressLabel.Name = "currentProgressLabel";
            this.currentProgressLabel.Size = new System.Drawing.Size(73, 13);
            this.currentProgressLabel.TabIndex = 15;
            this.currentProgressLabel.Text = "0";
            this.currentProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalProgressLabel
            // 
            this.TotalProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TotalProgressLabel.Location = new System.Drawing.Point(383, 413);
            this.TotalProgressLabel.Name = "TotalProgressLabel";
            this.TotalProgressLabel.Size = new System.Drawing.Size(63, 13);
            this.TotalProgressLabel.TabIndex = 16;
            this.TotalProgressLabel.Text = "0";
            this.TotalProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(366, 413);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "/";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressPerctLabel
            // 
            this.progressPerctLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressPerctLabel.Location = new System.Drawing.Point(459, 413);
            this.progressPerctLabel.Name = "progressPerctLabel";
            this.progressPerctLabel.Size = new System.Drawing.Size(29, 13);
            this.progressPerctLabel.TabIndex = 18;
            this.progressPerctLabel.Text = "0";
            this.progressPerctLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(484, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "%";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Width";
            // 
            // imageWidthBox
            // 
            this.imageWidthBox.Location = new System.Drawing.Point(47, 148);
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
            this.label10.Location = new System.Drawing.Point(6, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Image Resolution";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Height";
            // 
            // imageHeightBox
            // 
            this.imageHeightBox.Location = new System.Drawing.Point(172, 148);
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
            this.clearCacheButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearCacheButton.Location = new System.Drawing.Point(4, 319);
            this.clearCacheButton.Name = "clearCacheButton";
            this.clearCacheButton.Size = new System.Drawing.Size(75, 23);
            this.clearCacheButton.TabIndex = 25;
            this.clearCacheButton.Text = "Clear Cache";
            this.clearCacheButton.UseVisualStyleBackColor = true;
            this.clearCacheButton.Click += new System.EventHandler(this.clearCacheButton_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(481, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Number of Pics";
            // 
            // numOfPicsTotalBox
            // 
            this.numOfPicsTotalBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfPicsTotalBox.Location = new System.Drawing.Point(576, 50);
            this.numOfPicsTotalBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOfPicsTotalBox.Name = "numOfPicsTotalBox";
            this.numOfPicsTotalBox.Size = new System.Drawing.Size(143, 20);
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
            this.orderModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderModeComboBox.FormattingEnabled = true;
            this.orderModeComboBox.Items.AddRange(new object[] {
            "Rating",
            "Newest",
            "Oldest",
            "Favorites",
            "Random"});
            this.orderModeComboBox.Location = new System.Drawing.Point(599, 146);
            this.orderModeComboBox.Name = "orderModeComboBox";
            this.orderModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderModeComboBox.TabIndex = 28;
            this.orderModeComboBox.Text = "Rating";
            this.orderModeComboBox.SelectedIndexChanged += new System.EventHandler(this.orderModeComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(599, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ordering";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(599, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Min Rating";
            // 
            // minRatingBox
            // 
            this.minRatingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minRatingBox.Location = new System.Drawing.Point(658, 173);
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
            this.apiKeyLabel.Location = new System.Drawing.Point(6, 95);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(45, 13);
            this.apiKeyLabel.TabIndex = 32;
            this.apiKeyLabel.TabStop = true;
            this.apiKeyLabel.Text = "API Key";
            this.apiKeyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.apiKeyLabel_LinkClicked);
            // 
            // clearCacheAllButton
            // 
            this.clearCacheAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearCacheAllButton.BackColor = System.Drawing.Color.Maroon;
            this.clearCacheAllButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearCacheAllButton.Location = new System.Drawing.Point(85, 319);
            this.clearCacheAllButton.Name = "clearCacheAllButton";
            this.clearCacheAllButton.Size = new System.Drawing.Size(91, 23);
            this.clearCacheAllButton.TabIndex = 33;
            this.clearCacheAllButton.Text = "Clear Cache All";
            this.clearCacheAllButton.UseVisualStyleBackColor = false;
            this.clearCacheAllButton.Click += new System.EventHandler(this.clearCacheAllButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 488);
            this.tabControl1.TabIndex = 34;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.updateDatabaseButton);
            this.tabPage1.Controls.Add(this.downloadOnlyButton);
            this.tabPage1.Controls.Add(this.clearCacheAllButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.apiKeyLabel);
            this.tabPage1.Controls.Add(this.searchTextBox);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.minRatingBox);
            this.tabPage1.Controls.Add(this.searchButton);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.folderLocationTextBox);
            this.tabPage1.Controls.Add(this.orderModeComboBox);
            this.tabPage1.Controls.Add(this.numberOfPagesBox);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numOfPicsTotalBox);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.clearCacheButton);
            this.tabPage1.Controls.Add(this.apiKeyTextBox);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.imageHeightBox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.progressLabel);
            this.tabPage1.Controls.Add(this.imageWidthBox);
            this.tabPage1.Controls.Add(this.currentProgressLabel);
            this.tabPage1.Controls.Add(this.progressPerctLabel);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.TotalProgressLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Download";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rate5StarButton);
            this.tabPage2.Controls.Add(this.rate4StarButton);
            this.tabPage2.Controls.Add(this.rate3StarButton);
            this.tabPage2.Controls.Add(this.rate2StarButton);
            this.tabPage2.Controls.Add(this.rate1StarButton);
            this.tabPage2.Controls.Add(this.deletePictureButton);
            this.tabPage2.Controls.Add(this.previousPictureButton);
            this.tabPage2.Controls.Add(this.nextPictureButton);
            this.tabPage2.Controls.Add(this.offlinePicBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(729, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browse Offline";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rate5StarButton
            // 
            this.rate5StarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rate5StarButton.Location = new System.Drawing.Point(429, 436);
            this.rate5StarButton.Name = "rate5StarButton";
            this.rate5StarButton.Size = new System.Drawing.Size(42, 23);
            this.rate5StarButton.TabIndex = 8;
            this.rate5StarButton.Text = "5";
            this.rate5StarButton.UseVisualStyleBackColor = true;
            this.rate5StarButton.Click += new System.EventHandler(this.rate5StarButton_Click);
            // 
            // rate4StarButton
            // 
            this.rate4StarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rate4StarButton.Location = new System.Drawing.Point(381, 436);
            this.rate4StarButton.Name = "rate4StarButton";
            this.rate4StarButton.Size = new System.Drawing.Size(42, 23);
            this.rate4StarButton.TabIndex = 7;
            this.rate4StarButton.Text = "4";
            this.rate4StarButton.UseVisualStyleBackColor = true;
            this.rate4StarButton.Click += new System.EventHandler(this.rate4StarButton_Click);
            // 
            // rate3StarButton
            // 
            this.rate3StarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rate3StarButton.Location = new System.Drawing.Point(333, 436);
            this.rate3StarButton.Name = "rate3StarButton";
            this.rate3StarButton.Size = new System.Drawing.Size(42, 23);
            this.rate3StarButton.TabIndex = 6;
            this.rate3StarButton.Text = "3";
            this.rate3StarButton.UseVisualStyleBackColor = true;
            this.rate3StarButton.Click += new System.EventHandler(this.rate3StarButton_Click);
            // 
            // rate2StarButton
            // 
            this.rate2StarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rate2StarButton.Location = new System.Drawing.Point(285, 436);
            this.rate2StarButton.Name = "rate2StarButton";
            this.rate2StarButton.Size = new System.Drawing.Size(42, 23);
            this.rate2StarButton.TabIndex = 5;
            this.rate2StarButton.Text = "2";
            this.rate2StarButton.UseVisualStyleBackColor = true;
            this.rate2StarButton.Click += new System.EventHandler(this.rate2StarButton_Click);
            // 
            // rate1StarButton
            // 
            this.rate1StarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rate1StarButton.Location = new System.Drawing.Point(237, 436);
            this.rate1StarButton.Name = "rate1StarButton";
            this.rate1StarButton.Size = new System.Drawing.Size(42, 23);
            this.rate1StarButton.TabIndex = 4;
            this.rate1StarButton.Text = "1";
            this.rate1StarButton.UseVisualStyleBackColor = true;
            this.rate1StarButton.Click += new System.EventHandler(this.rate1StarButton_Click);
            // 
            // deletePictureButton
            // 
            this.deletePictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePictureButton.BackColor = System.Drawing.Color.Maroon;
            this.deletePictureButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deletePictureButton.Location = new System.Drawing.Point(112, 436);
            this.deletePictureButton.Name = "deletePictureButton";
            this.deletePictureButton.Size = new System.Drawing.Size(75, 23);
            this.deletePictureButton.TabIndex = 3;
            this.deletePictureButton.Text = "Delete";
            this.deletePictureButton.UseVisualStyleBackColor = false;
            this.deletePictureButton.Click += new System.EventHandler(this.deletePictureButton_Click);
            // 
            // previousPictureButton
            // 
            this.previousPictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousPictureButton.Location = new System.Drawing.Point(3, 436);
            this.previousPictureButton.Name = "previousPictureButton";
            this.previousPictureButton.Size = new System.Drawing.Size(75, 23);
            this.previousPictureButton.TabIndex = 2;
            this.previousPictureButton.Text = "Previous";
            this.previousPictureButton.UseVisualStyleBackColor = true;
            this.previousPictureButton.Click += new System.EventHandler(this.previousPictureButton_Click);
            // 
            // nextPictureButton
            // 
            this.nextPictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPictureButton.Location = new System.Drawing.Point(648, 436);
            this.nextPictureButton.Name = "nextPictureButton";
            this.nextPictureButton.Size = new System.Drawing.Size(75, 23);
            this.nextPictureButton.TabIndex = 1;
            this.nextPictureButton.Text = "Next";
            this.nextPictureButton.UseVisualStyleBackColor = true;
            this.nextPictureButton.Click += new System.EventHandler(this.nextPictureButton_Click);
            // 
            // offlinePicBox
            // 
            this.offlinePicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.offlinePicBox.BackColor = System.Drawing.Color.Silver;
            this.offlinePicBox.Location = new System.Drawing.Point(3, 6);
            this.offlinePicBox.Name = "offlinePicBox";
            this.offlinePicBox.Size = new System.Drawing.Size(720, 416);
            this.offlinePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.offlinePicBox.TabIndex = 0;
            this.offlinePicBox.TabStop = false;
            // 
            // downloadOnlyButton
            // 
            this.downloadOnlyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadOnlyButton.Location = new System.Drawing.Point(644, 385);
            this.downloadOnlyButton.Name = "downloadOnlyButton";
            this.downloadOnlyButton.Size = new System.Drawing.Size(75, 23);
            this.downloadOnlyButton.TabIndex = 34;
            this.downloadOnlyButton.Text = "Download";
            this.downloadOnlyButton.UseVisualStyleBackColor = true;
            this.downloadOnlyButton.Click += new System.EventHandler(this.downloadOnlyButton_Click);
            // 
            // updateDatabaseButton
            // 
            this.updateDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateDatabaseButton.Location = new System.Drawing.Point(563, 384);
            this.updateDatabaseButton.Name = "updateDatabaseButton";
            this.updateDatabaseButton.Size = new System.Drawing.Size(75, 23);
            this.updateDatabaseButton.TabIndex = 35;
            this.updateDatabaseButton.Text = "Update";
            this.updateDatabaseButton.UseVisualStyleBackColor = true;
            this.updateDatabaseButton.Click += new System.EventHandler(this.updateDatabaseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Derpiboo.ru Downloader by Natfoth";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPagesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPicsTotalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRatingBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offlinePicBox)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.PictureBox offlinePicBox;
        private System.Windows.Forms.Button previousPictureButton;
        private System.Windows.Forms.Button nextPictureButton;
        private System.Windows.Forms.Button deletePictureButton;
        private System.Windows.Forms.Button rate1StarButton;
        private System.Windows.Forms.Button rate5StarButton;
        private System.Windows.Forms.Button rate4StarButton;
        private System.Windows.Forms.Button rate3StarButton;
        private System.Windows.Forms.Button rate2StarButton;
        public System.Windows.Forms.Button updateDatabaseButton;
        public System.Windows.Forms.Button downloadOnlyButton;
    }
}

