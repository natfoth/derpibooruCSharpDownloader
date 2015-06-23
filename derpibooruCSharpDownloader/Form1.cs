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
        private readonly Downloader _downloader;
        private readonly OfflineBrowser _offlineBrowser;
        public Form1(Downloader newDownloader, OfflineBrowser offlineBrowser)
        {
            _downloader = newDownloader;
            _offlineBrowser = offlineBrowser;

            InitializeComponent();

            folderLocationTextBox.Text = Configuration.Instance.SaveLocation;
            numberOfPagesBox.Value = Configuration.Instance.NumOfPages;
            apiKeyTextBox.Text = Configuration.Instance.APIKey;
            searchTextBox.Text = Configuration.Instance.LastSearchTerm;
            imageWidthBox.Value = Configuration.Instance.ImageWidth;
            imageHeightBox.Value = Configuration.Instance.ImageHeight;
            numOfPicsTotalBox.Value = Configuration.Instance.NumOfPicsTotal;
            orderModeComboBox.SelectedIndex = Configuration.Instance.OrderingSelectedIndex;
            minRatingBox.Value = Configuration.Instance.MinRating;

            

        }

        public void EnableSearchButton()
        {
            this.Invoke(new Action(() =>
            {
                searchButton.Enabled = false;
                downloadOnlyButton.Enabled = false;
                updateDatabaseButton.Enabled = false;
            }));
        }


        private async void searchButton_Click(object sender, EventArgs e)
        {
            searchButton.Enabled = false;
            downloadOnlyButton.Enabled = false;
            updateDatabaseButton.Enabled = false;

            await _downloader.Search(searchTextBox.Text);
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
        }

        private void numPerPageBox_ValueChanged(object sender, EventArgs e)
        {
            
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                _offlineBrowser.TabLoaded();
            

        }

        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.NextPicture();
        }

        private void previousPictureButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.PreviousPicture();
        }

        private void rate1StarButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.RateImage(1);
        }

        private void rate2StarButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.RateImage(2);
        }

        private void rate3StarButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.RateImage(3);
        }

        private void rate4StarButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.RateImage(4);
        }

        private void rate5StarButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.RateImage(5);
        }

        private void deletePictureButton_Click(object sender, EventArgs e)
        {
            _offlineBrowser.DeletePicture();
        }

        private async void downloadOnlyButton_Click(object sender, EventArgs e)
        {
            await _downloader.DownloadPictures();
        }

        private async void updateDatabaseButton_Click(object sender, EventArgs e)
        {
            await _downloader.Search(searchTextBox.Text);
        }
    }
}
