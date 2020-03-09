using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace Memely
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string memeURL = "";
        string topText = "";
        string bottomText = "";
        System.Drawing.Brush textBrush = System.Drawing.Brushes.White;
        int textSize = 0;
        bool isReadyToMeme = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetMemeIconURL_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG | *.jpg | PNG | *.png";
            if (openFile.ShowDialog() == true)
            {
                memeURL = openFile.FileName;
                isReadyToMeme = true;
            }
            GenerateMeme();
        }

        private void TopTextTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            topText = TopTextTextbox.Text;
            GenerateMeme();
        }

        private void BottomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bottomText = BottomTextBox.Text;
            GenerateMeme();
        }

        private void TextSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(TextSizeTextBox.Text, out textSize))
            {
                GenerateMeme();
            }
            else
            {

            }
        }

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

        private Bitmap GenerateMeme()
        {
            if(isReadyToMeme == true)
            {
                Bitmap memeImage = null;

                using (var img = new Bitmap(memeURL))
                {
                    memeImage = new Bitmap(img);
                }

                Font memeFont = new Font("Impact", textSize, System.Drawing.FontStyle.Bold);

                Bitmap outputImage = new Bitmap(memeImage.Width, memeImage.Height);
                using (Graphics g = Graphics.FromImage(outputImage))
                {
                    g.InterpolationMode = InterpolationMode.High;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    StringFormat sf = new StringFormat();

                    sf.Alignment = StringAlignment.Center;

                    g.DrawImage(memeImage, 0, 0, memeImage.Width, memeImage.Height);

                    //Uppertext & lower text
                    g.DrawString(topText, memeFont, textBrush, new System.Drawing.Rectangle(0, Convert.ToInt32((outputImage.Height / 100) * 5), outputImage.Width - 20, Convert.ToInt32(MeasureString(topText, memeFont, outputImage.Width - 20).Width)), sf);
                    g.DrawString(bottomText, memeFont, textBrush, new System.Drawing.Rectangle(0, (outputImage.Height - (Convert.ToInt32((outputImage.Height / 100) * 5) + Convert.ToInt32(MeasureString(bottomText, memeFont, outputImage.Width - 20).Height))), outputImage.Width - 20, Convert.ToInt32(MeasureString(bottomText, memeFont, outputImage.Width - 20).Width)), sf);

                }
                MemePreviewImage.Source = BitmapToImageSource(outputImage);
                return outputImage;
            }
            else
            {
                return null;
            }
        }

        public static SizeF MeasureString(string s, Font font, int width)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font, width);
                }
            }

            return result;
        }


        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if(isReadyToMeme == true)
            {
                Bitmap bmp = GenerateMeme();

                Microsoft.Win32.SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "JPG | *.jpg | PNG | *.png";
                if (saveFile.ShowDialog() == true)
                {
                    memeURL = saveFile.FileName;
                    bmp.Save(saveFile.FileName, ImageFormat.Png);
                }
            }
        }

        private void BrushesColour_Click(object sender, RoutedEventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBrush = new SolidBrush(colorDialog.Color);
                }
            }
            GenerateMeme();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
