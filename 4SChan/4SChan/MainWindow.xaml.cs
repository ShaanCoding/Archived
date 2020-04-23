using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4SChan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<ImagesClass> imagesDictionary = new List<ImagesClass>();

        private static bool showMessageBoxOnComplete;
        private static bool exitOnComplete;
        private static string downloadDirectory;
        private static bool createSubFolderOnDownload;
        private static bool saveWithOriginalFileName;

        private string subFolderName = "";
        private DataTable dt = new DataTable();
        private FetchDownloadCancel fetchDownloadEnum = FetchDownloadCancel.Fetch;
        private bool isFetchValid = false;
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        private enum FetchDownloadCancel
        {
            Fetch,
            Cancel,
            Download,
        };

        public MainWindow()
        {
            InitializeComponent();
            InitalizeDataGridView();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void _4SChan_ContentRendered(object sender, EventArgs e)
        {
            AssignProperties();
        }

        public static void AssignProperties()
        {
            showMessageBoxOnComplete = Properties.Settings.Default.showMessageBoxOnComplete;
            exitOnComplete = Properties.Settings.Default.exitOnComplete;
            downloadDirectory = Properties.Settings.Default.downloadDirectory;
            createSubFolderOnDownload = Properties.Settings.Default.createSubFolderOnDownload;
            saveWithOriginalFileName = Properties.Settings.Default.saveWithOriginalFileName;
        }



        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string directoryToSaveTo;
            if(Properties.Settings.Default.createSubFolderOnDownload)
            {
                //Check if subdirectory exists if not it creates it
                directoryToSaveTo = Properties.Settings.Default.downloadDirectory + "\\" + subFolderName;
                DirectoryInfo destinationDirectory = new DirectoryInfo(directoryToSaveTo);

                if (!destinationDirectory.Exists)
                {
                    destinationDirectory.Create();
                }
            }
            else
            {
                directoryToSaveTo = Properties.Settings.Default.downloadDirectory;
            }

            for(int i = 0; i < imagesDictionary.Count; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    string result = Downloader.DownloadImage(imagesDictionary[i].getURLOfImage(), imagesDictionary[i].getNameOfImage(), imagesDictionary[i].getFileTypeOfImage(), directoryToSaveTo);

                    //Shows success or fail for each image
                    DataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(delegate ()
                    {
                        if(!dt.Rows[i-1].IsNull(5))
                        {
                            dt.Rows[i-1].SetField(5, result);
                        }
                    }));
                }
                int returnProgressPercent = (int)Math.Ceiling((decimal)(i + 1) / imagesDictionary.Count * 100);
                worker.ReportProgress(returnProgressPercent);
            }

            if(Properties.Settings.Default.exitOnComplete)
            {
                this.Close();
            }
            else if(Properties.Settings.Default.showMessageBoxOnComplete)
            {
                MessageBox.Show("Success! All files downloaded sucessfully");
            }
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation Cancelled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error in Process :" + e.Error);
            }
            else
            {
                //Nothing
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsMenu settingsMenu = new SettingsMenu();
            settingsMenu.ShowDialog();
        }

        private void InitalizeDataGridView()
        {
            dt.Columns.Add("Selected", typeof(bool));
            dt.Columns.Add("URL", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("File Type", typeof(string));
            dt.Columns.Add("Download Size (UNIT)", typeof(double));
            dt.Columns.Add("Status");

            DataGrid.ItemsSource = dt.DefaultView;
        }

        private void PopulateDataGridView()
        {
            dt = new DataTable();

            InitalizeDataGridView();
            foreach (ImagesClass img in imagesDictionary)
            {
                dt.Rows.Add(img.getIsSelected(), img.getURLOfImage(), img.getNameOfImage(), img.getFileTypeOfImage(), img.getDownloadSize(), "");
            }
        }

        private string GetSubFolderName(string inputString)
        {
            return string.Join("", inputString.Remove(0, inputString.LastIndexOf('.')).Split('/'), 3, 1);
        }

        private void FetchDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if(fetchDownloadEnum == FetchDownloadCancel.Fetch)
            {
                //Check if thread is valid and populate info

                //Replace true with populate info
                subFolderName = GetSubFolderName(URLTextBox.Text);
                imagesDictionary = Downloader.ViewThread(URLTextBox.Text);
                PopulateDataGridView();

                if(imagesDictionary.Count > 0)
                {
                    isFetchValid = true;
                    FetchDownloadButton.Content = "Download";
                    fetchDownloadEnum = FetchDownloadCancel.Download;
                }
                else
                {
                    MessageBox.Show("Error: Cannot start until a valid thread is inputted.");
                }
            }
            else if(fetchDownloadEnum == FetchDownloadCancel.Download)
            {
                if(isFetchValid == true)
                {
                    backgroundWorker.RunWorkerAsync();
                    FetchDownloadButton.Content = "Cancel";
                    fetchDownloadEnum = FetchDownloadCancel.Cancel;
                }
                else
                {
                    MessageBox.Show("Error: Cannot start until a valid thread is inputted.");
                }
            }
            else if(fetchDownloadEnum == FetchDownloadCancel.Cancel)
            {
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
                FetchDownloadButton.Content = "Fetch";
                fetchDownloadEnum = FetchDownloadCancel.Fetch;
            }
        }

    }
}
