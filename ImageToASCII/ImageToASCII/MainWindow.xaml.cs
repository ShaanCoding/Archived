using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ImageToASCII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string inputImageFileName;
        private static  readonly char[] asciiChars = { '█', '░', '@', '&', '$', '%', '!', '(', ')', '=', '+', '^', '*', ';', ':', '_', '-', '"', '/', ',', '.', ' ' };
        private int asciiWidth;


        //Need a int return to give brightness DONE
        //Function takes in brightness and gives in unicode
        //open image takes width and height therefore 

        public static Bitmap resizeImage(Image inputImage, int asciiWidth)
        {
            //Gains proper ratio height in characters
            int asciiHeight = (int)Math.Ceiling((double)inputImage.Height * asciiWidth / inputImage.Width);

            //Defines new rescaled bitmap
            Bitmap outputImage = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)outputImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputImage, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return outputImage;
        }

        public static int findBrightness(System.Drawing.Color inputColour)
        {
            int brightness = (inputColour.R + inputColour.G + inputColour.B) / 3;
            return brightness;
        }

        public static string brightnessToChar(int brightness)
        {
            int index = brightness * 10 / 255;
            return asciiChars[index].ToString();
        }

        public void openImage()
        {
            try
            {
                if(int.TryParse(asciiWidthTextbox.Text, out asciiWidth))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "JPG|*.jpg|PNG|*.png";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        inputImageFileName = openFileDialog.FileName;

                        Image inputImage = Image.FromFile(inputImageFileName);
                        Bitmap inputImageResize = resizeImage(inputImage, asciiWidth);

                        StringBuilder outputStringFull = new StringBuilder();
                        for (int y = 0; y < inputImageResize.Height; y++)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int x = 0; x < inputImageResize.Width; x++)
                            {
                                System.Drawing.Color colour = inputImageResize.GetPixel(x, y);
                                int brightness = findBrightness(colour);
                                string pxlToChar = brightnessToChar(brightness);
                                stringBuilder.Append(pxlToChar);
                                stringBuilder.Append(pxlToChar);
                            }
                            stringBuilder.Append("\n");
                            outputStringFull.Append(stringBuilder);
                        }
                        outputText.Text = outputStringFull.ToString();
                        MessageBox.Show(inputImageFileName);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: An Error Occured When Declaring The Size");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: An Error Occured When Loading The File \nERROR:" + ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openImage();
        }

        private void AsciiWidthTextbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void ZoomTextbox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int defaultFontSize = 12;
            double percentage = zoomTextbox.Value / 100;
            int fontSize = (int)Math.Ceiling(defaultFontSize * percentage);
            outputText.FontSize = fontSize;
        }
    }
}
