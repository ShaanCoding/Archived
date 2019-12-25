using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
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
        string URLExtension = "_Modified";
        string[] imageFiles;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.IsFolderPicker = true;
            if(openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                inputFolderURL = openFileDialog.FileName;
                canStartConversionOne = true;
                imageFiles = Directory.GetFiles(inputFolderURL);
                loadPictureBox(); //Will load image to picture box when done
            }
        }

        private void ChooseColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                newColor = colorDialog.Color;
                canStartConversionTwo = true;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if(canStartConversionOne == true && canStartConversionTwo == true)
            {
                try
                {
                    Bitmap bmp = null;
                    for(int i = 0; i < imageFiles.Length; i++)
                    {
                        bmp = (Bitmap)System.Drawing.Image.FromFile(imageFiles[i]);
                        bmp = ChangeColor(bmp);
                        bmp.Save(imageFiles[i].Replace(".png","") + URLExtension + ".png");
                    }
                    System.Windows.MessageBox.Show("Success! The task was finished successfully.");
                }
                catch(System.Exception ex)
                {
                    System.Windows.MessageBox.Show("An error has occured, refer to: " + ex.ToString());
                }
            }
        }

        public Bitmap ChangeColor(Bitmap scrBitmap)
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

        private void loadPictureBox()
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
                loadPictureBox();
            }
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            if(imageFiles != null && viewedIconIndex < (imageFiles.Length - 1))
            {
                viewedIconIndex++;
                loadPictureBox();
            }
        }
    }
}
