using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.ComponentModel;
using System.Data;

namespace XKCDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberOfComics;
        string downloadDirectory;
        bool isFolderSelected = false;
        bool startStopButtonBool = true;
        bool isPausedBool = false;
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        DataTable dt = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorkerDownloadingImages;
            backgroundWorker.ProgressChanged += BackgroundWorkerDownloadingImages_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorkerDownloadingImages_RunWorkerCompleted;
        }

        private void SelectDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            selectFolder();
        }

        private void selectFolder()
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.IsFolderPicker = true;
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    downloadDirectory = openFileDialog.FileName;
                    isFolderSelected = true;
                    DownloadDirectoryURL.Text = downloadDirectory;
                }
            }
        }

        private void startStopButton_Click(object sender, RoutedEventArgs e)
        {
            if(startStopButtonBool == true)
            {
                if(isFolderSelected == true)
                {
                    findMaxPages();
                    backgroundWorker.RunWorkerAsync();
                    startStopButtonBool = false;
                    startStopButton.Content = "Stop";
                }
                else if(isFolderSelected == false)
                {
                    MessageBox.Show("Error: Cannot start until a output folder is selected.");
                }
            }
            else if(startStopButtonBool == false)
            {
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
                startStopButtonBool = true;
                startStopButton.Content = "Start";
            }
        }

        private void findMaxPages()
        {
            using(WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead("https://xkcd.com/info.0.json");
                using (StreamReader r = new StreamReader(stream))
                {
                    string json = r.ReadToEnd();
                    dynamic items = JsonConvert.DeserializeObject<dynamic>(json);
                    numberOfComics = items["num"];
                }
            }
        }

        private string[] imageURLData(int index)
        {
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(string.Format("https://xkcd.com/{0}/info.0.json", index));
                using (StreamReader r = new StreamReader(stream))
                {
                    string json = r.ReadToEnd();
                    dynamic items = JsonConvert.DeserializeObject<dynamic>(json);
                    string[] returnString = { items["img"], items["safe_title"] };
                    return returnString;
                }
            }
        }

        private void BackgroundWorkerDownloadingImages(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= numberOfComics; i++)
            {
                while (isPausedBool == true) { }

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    try
                    {
                        string[] imageURLDataString = imageURLData(i);
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(imageURLDataString[0]), string.Format(@"{0}\{1}.png", downloadDirectory, imageURLDataString[1]));
                            
                            dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(delegate ()
                            {
                                dataTableAdd(i, numberOfComics, imageURLDataString[1], Convert.ToInt64(client.ResponseHeaders["Content-Length"]).ToString());
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occured, refer to: " + ex.ToString());
                    }

                }
                int returnProgressPercent = (int)Math.Ceiling((decimal)(i + 1) / numberOfComics * 100);
                worker.ReportProgress(returnProgressPercent);
            }
        }

        private void BackgroundWorkerDownloadingImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                MessageBox.Show("Success! The task has finished successfully.");
            }
        }

        private void BackgroundWorkerDownloadingImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPausedBool == true)
            {
                isPausedBool = false;
                PauseButton.Content = "Resume";
            }
            else if(isPausedBool == false)
            {
                isPausedBool = true;
                PauseButton.Content = "Pause";
            }
        }

        private void dataTablePopulated()
        {
            DataColumn dlNumber = new DataColumn("Number", typeof(string));
            DataColumn dlTitle = new DataColumn("Title", typeof(string));
            DataColumn dlSize = new DataColumn("Size", typeof(string));
            DataColumn dlStatus = new DataColumn("Status", typeof(string));

            dt.Columns.Add(dlNumber);
            dt.Columns.Add(dlTitle);
            dt.Columns.Add(dlSize);
            dt.Columns.Add(dlStatus);

            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void dataTableAdd(int i, int totalNumber, string title, string size)
        {
            dt.Rows.Add("Number " + i + " of " + totalNumber, title, size + " bytes", "Completed");
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataTablePopulated();
        }
    }
}
