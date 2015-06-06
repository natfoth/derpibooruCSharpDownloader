using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derpibooruCSharpDownloader
{
    public partial class Form1 : Form
    {
        private Downloader _downloader;
        public Form1(Downloader newDownloader)
        {
            _downloader = newDownloader;

            InitializeComponent();

            folderLocationTextBox.Text = Configuration.Instance.SaveLocation;
            numberOfPagesBox.Value = Configuration.Instance.NumOfPages;
            apiKeyTextBox.Text = Configuration.Instance.APIKey;
            numPerPageBox.Value = Configuration.Instance.NumOfPicsPerPage;
            searchTextBox.Text = Configuration.Instance.LastSearchTerm;
            imageWidthBox.Value = Configuration.Instance.ImageWidth;
            imageHeightBox.Value = Configuration.Instance.ImageHeight;
            numOfPicsTotalBox.Value = Configuration.Instance.NumOfPicsTotal;
            orderModeComboBox.SelectedIndex = Configuration.Instance.OrderingSelectedIndex;
            minRatingBox.Value = Configuration.Instance.MinRating;

            

            if (apiKeyTextBox.Text.Length > 0)
                numPerPageBox.Enabled = true;

        }

        public void EnableSearchButton()
        {
            searchButton.Enabled = true;
        }


        private async void searchButton_Click(object sender, EventArgs e)
        {
            //await _downloader.Search(searchTextBox.Text);
            searchButton.Enabled = false;
            await _downloader.DownloadPictures();
        }

        private void folderLocationTextBox_TextChanged(object sender, EventArgs e)
        {
            Configuration.Instance.SaveLocation = folderLocationTextBox.Text;
            Configuration.Instance.Save();
        }

        private void numberOfPagesBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.NumOfPages = (int) numberOfPagesBox.Value;
            Configuration.Instance.Save();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            Configuration.Instance.LastSearchTerm = searchTextBox.Text;
            Configuration.Instance.Save();
        }

        private void apiKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            Configuration.Instance.APIKey = apiKeyTextBox.Text;
            Configuration.Instance.Save();

            numPerPageBox.Enabled = apiKeyTextBox.Text.Length > 0;
        }

        private void numPerPageBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.NumOfPicsPerPage = (int)numPerPageBox.Value;
            Configuration.Instance.Save();
        }

        private void clearCacheButton_Click(object sender, EventArgs e)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\derpibooruDL\\";

            if (!Directory.Exists(documentsFolder))
                Directory.CreateDirectory(documentsFolder);


            var fileName = searchTextBox.Text;

            var invalidFileChars = Path.GetInvalidFileNameChars().ToList();
            invalidFileChars.ForEach(c => fileName = fileName.Replace(c.ToString(), String.Empty));

            fileName = fileName + ".txt";

            documentsFolder += fileName;

            if(File.Exists(documentsFolder))
                File.Delete(documentsFolder);

        }

        private void imageWidthBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.ImageWidth = (int)imageWidthBox.Value;
            Configuration.Instance.Save();
        }

        private void imageHeightBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.ImageHeight = (int)imageHeightBox.Value;
            Configuration.Instance.Save();
        }

        private void numOfPicsTotalBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.NumOfPicsTotal = (int)numOfPicsTotalBox.Value;
            Configuration.Instance.Save();
            
        }

        private void orderModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration.Instance.OrderingSelectedIndex = (int)orderModeComboBox.SelectedIndex;
            Configuration.Instance.Save();
        }

        private void minRatingBox_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.MinRating = (int)minRatingBox.Value;
            Configuration.Instance.Save();
        }

        private void apiKeyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://derpibooru.org/users/edit");
        }

        private void clearCacheAllButton_Click(object sender, EventArgs e)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\derpibooruDL\\";

            if (!Directory.Exists(documentsFolder))
                return;

            var directory = new System.IO.DirectoryInfo(documentsFolder);
            directory.Empty();
        }
    }
}
