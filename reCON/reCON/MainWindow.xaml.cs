using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Thanks to microsoft.windowsapicodepack

namespace reCON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inputFolderURL;
        bool canStartConversionOne = false;
        bool canStartConversionTwo = false;
        System.Drawing.Color newColor;
        int viewedIconIndex = 0;
        readonly string URLExtension = "_Modified";
        List<string> imageFiles;
        bool startButtonCancel = false;
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += BackgroundWorkerConvertingImages;
            worker.ProgressChanged += BackgroundWorkerConvertingImages_ProgressChanged;
            worker.RunWorkerCompleted += BackgroundWorkerConvertingImages_RunWorkerCompleted;
        }

        private void ChooseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.IsFolderPicker = true;
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    inputFolderURL = openFileDialog.FileName;
                    canStartConversionOne = true;
                    //Gets url of all image files with the png, bmp, tiff, gif or png file extension
                    imageFiles = Directory.GetFiles(inputFolderURL, "*.*", SearchOption.AllDirectories)
                    .Where(file => new string[] { ".jpg", ".bmp", ".tiff", ".gif", ".png" }
                    .Contains(System.IO.Path.GetExtension(file)))
                    .ToList();

                    LoadPictureBox(); //Will load image to picture box when done
                }
            }
        }

        private void ChooseColorButton_Click(object sender, RoutedEventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    newColor = colorDialog.Color;
                    canStartConversionTwo = true;
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if(canStartConversionOne == true && canStartConversionTwo == true && startButtonCancel == false)
            {
                worker.RunWorkerAsync();
                startButton.Content = "Cancel";
                startButtonCancel = true;
            }
            else if(startButtonCancel == true)
            {
                if (worker.IsBusy)
                {
                    worker.CancelAsync();
                }

                startButton.Content = "Start";
                startButtonCancel = false;
            }
        }

        private void BackgroundWorkerConvertingImages(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Bitmap bmp;

            for (int i = 0; i < imageFiles.Count; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    try
                    {
                        bmp = (Bitmap)System.Drawing.Image.FromFile(imageFiles[i]);
                        bmp = ChangeColor(bmp);
                        bmp.Save(imageFiles[i].Replace(".png", "") + URLExtension + ".png");
                        //Calculates the loading bar
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.MessageBox.Show("An error has occured, refer to: " + ex.ToString());
                    }
                    int returnProgressPercent = (int)Math.Ceiling((decimal)(i+1) / imageFiles.Count * 100); // NO IDEA WHY IT DOESNT WORK
                    worker.ReportProgress(returnProgressPercent);
                }
            }
        }

        private void BackgroundWorkerConvertingImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                System.Windows.MessageBox.Show("Operation Cancelled");
            }
            else if (e.Error != null)
            {
                System.Windows.MessageBox.Show("Error in Process :" + e.Error);
            }
            else
            {
                System.Windows.MessageBox.Show("Success! The task has finished successfully.");
            }
        }

        private void BackgroundWorkerConvertingImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingBar.Value = e.ProgressPercentage;
        }


        //need to replace with faster method
        private Bitmap ChangeColor(Bitmap scrBitmap)
        {
            System.Drawing.Color actualColor;
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    actualColor = scrBitmap.GetPixel(i, j);
                    //Alpha Smoothing
                    if (actualColor.A > 150)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, actualColor);
                }
            }
            return newBitmap;
        }

        private void LoadPictureBox()
        {
            ImageSource newImage = new BitmapImage(new Uri(imageFiles[viewedIconIndex]));
            previewPictureBox.Source = newImage;
            previewPictureBoxIndex.Content = "Viewing Image: " + (viewedIconIndex + 1);
        }

        private void BackImage_Click(object sender, RoutedEventArgs e)
        {
            if(imageFiles != null && viewedIconIndex > 0)
            {
                viewedIconIndex--;
                LoadPictureBox();
            }
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            if(imageFiles != null && viewedIconIndex < (imageFiles.Count - 1))
            {
                viewedIconIndex++;
                LoadPictureBox();
            }
        }

        private void PreviewPictureBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(imageFiles[viewedIconIndex]);
            bmp = ChangeColor(bmp);
            previewPictureBox.Source = BitmapToImageSource(bmp);
            previewPictureBoxIndex.Content = "Viewing Image Preview: " + (viewedIconIndex + 1);
        }

        /* https://stackoverflow.com/questions/22499407/how-to-display-a-bitmap-in-a-wpf-image */
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void PreviewPictureBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LoadPictureBox();
        }

        private void LoadingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
