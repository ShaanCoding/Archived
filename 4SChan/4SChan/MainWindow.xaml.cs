using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            /*
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            */
        }

        private static void ReadOnlyButton()
        {
            /*
            if (startStopButtonBool == true)
            {
                if (isFolderSelected == true)
                {
                    FindMaxPages();
                    backgroundWorker.RunWorkerAsync();
                    startStopButtonBool = false;
                    StartStopButton.Content = "Stop";
                }
                else
                {
                    MessageBox.Show("Error: Cannot start until a output folder is selected.");
                }
            }
            else
            {
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
                startStopButtonBool = true;
                StartStopButton.Content = "Start";
            }
            */
        }

        public static async void TestFunction()
        {
            /*
            var downloader = new Downloader();                        // create new ChanDownloader instance

            var thread = await downloader.LoadThread("Thread URL");   // load thread

            var id = thread.Id;                                        // thread id
            var subject = thread.Subject;                             // get thread subject (original)
            var safeName = thread.SemanticSubject;                    // get thread subject in safe format
            var files = thread.Files;                                 // get the file list

            
             //the webclient is exposed so you can hook up your event callbacks
             //you can get the current downloaded file index from downloader.CurrentFileNumber

            downloader.WebClient.DownloadFileCompleted += "YOUR CALLBACK";
            await downloader.DownloadFiles(thread, "YOUR PATH");  // download the files to the specified directory
            */
        }

        private void BackgroundWorkerDownloadingImages(object sender, DoWorkEventArgs e)
        {
            /*
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= numberOfComics; i++)
            {
                while (isPausedBool == true)
                {
                    //Empty loop to pause downloading
                }

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    try
                    {
                        string[] imageURLDataString = ImageURLData(i);
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(imageURLDataString[0]), string.Format(@"{0}\{1}.png", downloadDirectory, imageURLDataString[1]));

                            dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(delegate ()
                            {
                                DataTableAdd(i, numberOfComics, imageURLDataString[1], Convert.ToInt64(client.ResponseHeaders["Content-Length"]).ToString());
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occured, refer to: " + ex);
                    }

                }
                int returnProgressPercent = (int)Math.Ceiling((decimal)(i + 1) / numberOfComics * 100);
                worker.ReportProgress(returnProgressPercent);
            }
            */
        }

        private static void BackgroundWorkerDownloadingImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            //ProgressBar.Value = e.ProgressPercentage;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsMenu settingsMenu = new SettingsMenu();
            settingsMenu.ShowDialog();
        }
    }
}
