using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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


namespace Frequence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class GeneralFunctions
    {
        public static void saveFileXML()
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = "csv";
                saveFile.Filter = "CSV|*.csv";
                bool? result = saveFile.ShowDialog();
                if (result == true)
                {
                    if (File.Exists(saveFile.FileName))
                    {
                        File.Delete(saveFile.FileName);
                    }

                    using (Stream s = File.Open(saveFile.FileName, FileMode.CreateNew))
                    {
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(MainWindow.rainBoolean + "," + MainWindow.rainVolume + "\n");
                            sw.Write(MainWindow.thunderstormBoolean + "," + MainWindow.thunderstormVolume + "\n");
                            sw.Write(MainWindow.windBoolean + "," + MainWindow.windVolume + "\n");
                            sw.Write(MainWindow.forestBoolean + "," + MainWindow.forestVolume + "\n");
                            sw.Write(MainWindow.leavesBoolean + "," + MainWindow.leavesVolume + "\n");
                            sw.Write(MainWindow.waterStreamBoolean + "," + MainWindow.waterStreamVolume + "\n");
                            sw.Write(MainWindow.seaSideBoolean + "," + MainWindow.seaSideVolume + "\n");
                            sw.Write(MainWindow.waterStreamBoolean + "," + MainWindow.waterStreamVolume + "\n");
                            sw.Write(MainWindow.firePlaceBoolean + "," + MainWindow.firePlaceVolume + "\n");
                            sw.Write(MainWindow.summerNightBoolean + "," + MainWindow.summerNightVolume + "\n");
                            sw.Write(MainWindow.coffeeShopBoolean + "," + MainWindow.coffeeShopVolume + "\n");
                            sw.Write(MainWindow.trainBoolean + "," + MainWindow.trainVolume + "\n");
                            sw.Write(MainWindow.fanBoolean + "," + MainWindow.fanVolume + "\n");
                            sw.Write(MainWindow.whiteNoiseBoolean + "," + MainWindow.whiteNoiseVolume + "\n");
                            sw.Write(MainWindow.pinkNoiseBoolean + "," + MainWindow.pinkNoiseVolume + "\n");
                            sw.Write(MainWindow.brownNoiseBoolean + "," + MainWindow.pinkNoiseVolume + "\n");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR: An Error Has Occured Whilst Saving");
            }
        }

        public static void loadFileCSV()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = "csv";
                openFile.Filter = "CSV|*.csv";
                bool? result = openFile.ShowDialog();
                if (result == true)
                {
                    using (Stream s = File.Open(openFile.FileName, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            var dataReadSplit = sr.ReadLine().Split(',');
                            MainWindow.rainBoolean = Convert.ToBoolean(dataReadSplit[0]);
                            MainWindow.rainVolume = Convert.ToInt32(dataReadSplit[1]);

                            if (MainWindow.rainBoolean == false)
                            {
                                MainWindow.rain.Play("rain");
                            }
                            MainWindow.rain.Volume("rain", MainWindow.rainVolume);
                            
                            /*
                             *                   sw.Write(MainWindow.rainBoolean + "," + MainWindow.rainVolume + "\n");
                        sw.Write(MainWindow.thunderstormBoolean + "," + MainWindow.thunderstormVolume + "\n");
                        sw.Write(MainWindow.windBoolean + "," + MainWindow.windVolume + "\n");
                        sw.Write(MainWindow.forestBoolean + "," + MainWindow.forestVolume + "\n");
                        sw.Write(MainWindow.leavesBoolean + "," + MainWindow.leavesVolume + "\n");
                        sw.Write(MainWindow.waterStreamBoolean + "," + MainWindow.waterStreamVolume + "\n");
                        sw.Write(MainWindow.seaSideBoolean + "," + MainWindow.seaSideVolume + "\n");
                        sw.Write(MainWindow.waterStreamBoolean + "," + MainWindow.waterStreamVolume + "\n");
                        sw.Write(MainWindow.firePlaceBoolean + "," + MainWindow.firePlaceVolume + "\n");
                        sw.Write(MainWindow.summerNightBoolean + "," + MainWindow.summerNightVolume + "\n");
                        sw.Write(MainWindow.coffeeShopBoolean + "," + MainWindow.coffeeShopVolume + "\n");
                        sw.Write(MainWindow.trainBoolean + "," + MainWindow.trainVolume + "\n");
                        sw.Write(MainWindow.fanBoolean + "," + MainWindow.fanVolume + "\n");
                        sw.Write(MainWindow.whiteNoiseBoolean + "," + MainWindow.whiteNoiseVolume + "\n");
                        sw.Write(MainWindow.pinkNoiseBoolean + "," + MainWindow.pinkNoiseVolume + "\n");
                        sw.Write(MainWindow.brownNoiseBoolean + "," + MainWindow.pinkNoiseVolume + "\n");
                             */
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR: An Error Has Occured Whilst Loading");
            }
        }

    }

    public class OggPlayer
    {
        readonly bool repeat = true;

        public OggPlayer(string fileName, string alias)
        {
            //open filename then type must be mpegvideo
            const string format = @"open ""{0}"" type mpegvideo alias ""{1}""";
            string command = string.Format(format, fileName, alias);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Play(string alias)
        {
            string format = @"play ""{0}""";
            if (repeat == true)
            {
                format += " REPEAT";
            }
            string command = string.Format(format, alias);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Stop(string alias)
        {
            string format = @"stop ""{0}""";
            string command = string.Format(format, alias);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Volume(string alias, int volume)
        {
            string format = @"setaudio ""{0}"" volume to {1}";
            string command = string.Format(format, alias, volume.ToString());
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public void Dispose(string alias)
        {
            string format = @"close ""{0}""";
            string command = string.Format(format, alias);
            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }

    public partial class MainWindow : Window
    {
        public static OggPlayer rain;
        public static OggPlayer thunderStorm;
        public static OggPlayer wind;
        public static OggPlayer forest;
        public static OggPlayer leaves;
        public static OggPlayer waterStream;
        public static OggPlayer seaSide;
        public static OggPlayer water;
        public static OggPlayer firePlace;
        public static OggPlayer summerNight;
        public static OggPlayer coffeeShop;
        public static OggPlayer train;
        public static OggPlayer fan;
        public static OggPlayer whiteNoise;
        public static OggPlayer pinkNoise;
        public static OggPlayer brownNoise;
       
        public static bool rainBoolean = true;
        public static bool thunderstormBoolean = true;
        public static bool windBoolean = true;
        public static bool forestBoolean = true;
        public static bool leavesBoolean = true;
        public static bool waterStreamBoolean = true;
        public static bool seaSideBoolean = true;
        public static bool waterBoolean = true;
        public static bool firePlaceBoolean = true;
        public static bool summerNightBoolean = true;
        public static bool coffeeShopBoolean = true;
        public static bool trainBoolean = true;
        public static bool fanBoolean = true;
        public static bool whiteNoiseBoolean = true;
        public static bool pinkNoiseBoolean = true;
        public static bool brownNoiseBoolean = true;

        public static int rainVolume = 500;
        public static int thunderstormVolume = 500;
        public static int windVolume = 500;
        public static int forestVolume = 500;
        public static int leavesVolume = 500;
        public static int waterStreamVolume = 500;
        public static int seaSideVolume = 500;
        public static int waterVolume = 500;
        public static int firePlaceVolume = 500;
        public static int summerNightVolume = 500;
        public static int coffeeShopVolume = 500;
        public static int trainVolume = 500;
        public static int fanVolume = 500;
        public static int whiteNoiseVolume = 500;
        public static int pinkNoiseVolume = 500;
        public static int brownNoiseVolume = 500;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            rain = new OggPlayer((Environment.CurrentDirectory + @"\Sound\rain.mp3"), "rain");
            thunderStorm = new OggPlayer((Environment.CurrentDirectory + @"\Sound\thunderstorm.mp3"), "thunderstorm");
            wind = new OggPlayer((Environment.CurrentDirectory + @"\Sound\wind.mp3"), "wind");
            forest = new OggPlayer((Environment.CurrentDirectory + @"\Sound\forest.mp3"), "forest");
            leaves = new OggPlayer((Environment.CurrentDirectory + @"\Sound\leaves.mp3"), "leaves");
            waterStream = new OggPlayer((Environment.CurrentDirectory + @"\Sound\waterstream.mp3"), "waterstream");
            seaSide = new OggPlayer((Environment.CurrentDirectory + @"\Sound\seaside.mp3"), "seaside");
            water = new OggPlayer((Environment.CurrentDirectory + @"\Sound\water.mp3"), "water");
            firePlace = new OggPlayer((Environment.CurrentDirectory + @"\Sound\fireplace.mp3"), "fireplace");
            summerNight = new OggPlayer((Environment.CurrentDirectory + @"\Sound\summernight.mp3"), "summernight");
            coffeeShop = new OggPlayer((Environment.CurrentDirectory + @"\Sound\coffeeshop.mp3"), "coffeeshop");
            train = new OggPlayer((Environment.CurrentDirectory + @"\Sound\train.mp3"), "train");
            fan = new OggPlayer((Environment.CurrentDirectory + @"\Sound\fan.mp3"), "fan");
            whiteNoise = new OggPlayer((Environment.CurrentDirectory + @"\Sound\whitenoise.mp3"), "whitenoise");
            pinkNoise = new OggPlayer((Environment.CurrentDirectory + @"\Sound\pinknoise.mp3"), "pinknoise");
            brownNoise = new OggPlayer((Environment.CurrentDirectory + @"\Sound\brownnoise.mp3"), "brownnoise");

            rain.Volume("rain", 500);
            thunderStorm.Volume("thunderstorm", 500);
            wind.Volume("wind", 500);
            forest.Volume("forest", 500);
            leaves.Volume("leaves", 500);
            waterStream.Volume("waterstream", 500);
            seaSide.Volume("seaside", 500);
            water.Volume("water", 500);
            firePlace.Volume("fireplace", 500);
            summerNight.Volume("summernight", 500);
            coffeeShop.Volume("coffeeshop", 500);
            train.Volume("train", 500);
            fan.Volume("fan", 500);
            whiteNoise.Volume("whitenoise", 500);
            pinkNoise.Volume("pinknoise", 500);
            brownNoise.Volume("brownnoise", 500);
        }

        private void RainButton_Click(object sender, RoutedEventArgs e)
        {
            if (rainBoolean == true)
            {
                rain.Play("rain");
                rainBoolean = false;
            }
            else if(rainBoolean == false)
            {
                rain.Stop("rain");
                rainBoolean = true;
            }
        }

        private void ThunderstormButton_Click(object sender, RoutedEventArgs e)
        {
            if (thunderstormBoolean == true)
            {
                thunderStorm.Play("thunderstorm");
                thunderstormBoolean = false;
            }
            else if (thunderstormBoolean == false)
            {
                thunderStorm.Stop("thunderstorm");
                thunderstormBoolean = true;
            }
        }

        private void WindButton_Click(object sender, RoutedEventArgs e)
        {
            if (windBoolean == true)
            {
                wind.Play("wind");
                windBoolean = false;
            }
            else if (windBoolean == false)
            {
                wind.Stop("wind");
                windBoolean = true;
            }
        }

        private void ForestButton_Click(object sender, RoutedEventArgs e)
        {
            if (forestBoolean == true)
            {
                forest.Play("forest");
                forestBoolean = false;
            }
            else if (forestBoolean == false)
            {
                forest.Stop("forest");
                forestBoolean = true;
            }
        }

        private void LeavesButton_Click(object sender, RoutedEventArgs e)
        {
            if (leavesBoolean == true)
            {
                leaves.Play("leaves");
                leavesBoolean = false;
            }
            else if (leavesBoolean == false)
            {
                leaves.Stop("leaves");
                leavesBoolean = true;
            }
        }

        private void WaterStreamButton_Click(object sender, RoutedEventArgs e)
        {
            if (waterStreamBoolean == true)
            {
                waterStream.Play("waterstream");
                waterStreamBoolean = false;
            }
            else if (waterStreamBoolean == false)
            {
                waterStream.Stop("waterstream");
                waterStreamBoolean = true;
            }
        }

        private void SeaSideButton_Click(object sender, RoutedEventArgs e)
        {
            if (seaSideBoolean == true)
            {
                seaSide.Play("seaside");
                seaSideBoolean= false;
            }
            else if (seaSideBoolean == false)
            {
                seaSide.Stop("seaside");
                seaSideBoolean = true;
            }
        }

        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            if (waterBoolean == true)
            {
                water.Play("water");
                waterBoolean = false;
            }
            else if (waterBoolean == false)
            {
                water.Stop("water");
                waterBoolean = true;
            }
        }

        private void FirePlaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (firePlaceBoolean == true)
            {
                firePlace.Play("fireplace");
                firePlaceBoolean = false;
            }
            else if (firePlaceBoolean == false)
            {
                firePlace.Stop("fireplace");
                firePlaceBoolean = true;
            }
        }

        private void SummerNightButton_Click(object sender, RoutedEventArgs e)
        {
            if (summerNightBoolean == true)
            {
                summerNight.Play("summernight");
                summerNightBoolean = false;
            }
            else if (summerNightBoolean == false)
            {
                summerNight.Stop("summernight");
                summerNightBoolean = true;
            }
        }

        private void CoffeeShopButton_Click(object sender, RoutedEventArgs e)
        {
            if (coffeeShopBoolean == true)
            {
                coffeeShop.Play("coffeeshop");
                coffeeShopBoolean = false;
            }
            else if (coffeeShopBoolean == false)
            {
                coffeeShop.Stop("coffeeshop");
                coffeeShopBoolean = true;
            }
        }

        private void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            if (trainBoolean == true)
            {
                train.Play("train");
                trainBoolean = false;
            }
            else if (trainBoolean == false)
            {
                train.Stop("train");
                trainBoolean = true;
            }
        }

        private void FanButton_Click(object sender, RoutedEventArgs e)
        {
            if (fanBoolean == true)
            {
                fan.Play("fan");
                fanBoolean = false;
            }
            else if (fanBoolean == false)
            {
                fan.Stop("fan");
                fanBoolean = true;
            }
        }

        private void WhiteNoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (whiteNoiseBoolean == true)
            {
                whiteNoise.Play("whitenoise");
                whiteNoiseBoolean = false;
            }
            else if (whiteNoiseBoolean == false)
            {
                whiteNoise.Stop("whitenoise");
                whiteNoiseBoolean = true;
            }
        }

        private void PinkNoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (pinkNoiseBoolean == true)
            {
                pinkNoise.Play("pinknoise");
                pinkNoiseBoolean = false;
            }
            else if (pinkNoiseBoolean == false)
            {
                pinkNoise.Stop("pinknoise");
                pinkNoiseBoolean = true;
            }
        }

        private void BrownNoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (brownNoiseBoolean == true)
            {
                brownNoise.Play("brownnoise");
                brownNoiseBoolean = false;
            }
            else if (brownNoiseBoolean == false)
            {
                brownNoise.Stop("brownnoise");
                brownNoiseBoolean = true;
            }
        }

        private void RainSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rainBoolean == false && rain != null)
            {
                rainVolume = Convert.ToInt32(rainSlider.Value);
                rain.Volume("rain", rainVolume);
            }
        }

        private void ThunderstormSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (thunderstormBoolean == false && thunderStorm != null)
            {
                thunderstormVolume = Convert.ToInt32(thunderstormSlider.Value);
                thunderStorm.Volume("thunderstorm", thunderstormVolume);
            }
        }

        private void WindSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (windBoolean == false && wind != null)
            {
                windVolume = Convert.ToInt32(windSlider.Value);
                wind.Volume("wind", windVolume);
            }
        }

        private void ForestSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (forestBoolean == false && forest != null)
            {
                forestVolume = Convert.ToInt32(forestSlider.Value);
                forest.Volume("forest", forestVolume);
            }
        }

        private void LeavesSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (leavesBoolean == false && leaves != null)
            {
                leavesVolume = Convert.ToInt32(leavesSlider.Value);
                leaves.Volume("leaves", leavesVolume);
            }
        }

        private void WaterStreamSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (waterStreamBoolean == false && waterStream != null)
            {
                waterStreamVolume = Convert.ToInt32(waterStreamSlider.Value);
                waterStream.Volume("waterstream", waterStreamVolume);
            }
        }

        private void SeaSideSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (seaSideBoolean == false && seaSide != null)
            {
                seaSideVolume = Convert.ToInt32(seaSideSlider.Value);
                seaSide.Volume("seaside", seaSideVolume);
            }
        }

        private void WaterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (waterBoolean == false && water != null)
            {
                waterVolume = Convert.ToInt32(waterSlider.Value);
                water.Volume("water", waterVolume);
            }
        }

        private void FirePlaceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (firePlaceBoolean == false && firePlace != null)
            {
                firePlaceVolume = Convert.ToInt32(firePlaceSlider.Value);
                firePlace.Volume("fireplace", firePlaceVolume);
            }
        }

        private void SummerNightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (summerNightBoolean == false && summerNight != null)
            {
                summerNightVolume = Convert.ToInt32(summerNightSlider.Value);
                summerNight.Volume("summernight", summerNightVolume);
            }
        }

        private void CoffeeShopSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (coffeeShopBoolean == false && coffeeShop != null)
            {
                coffeeShopVolume = Convert.ToInt32(coffeeShopSlider.Value);
                coffeeShop.Volume("coffeeshop", coffeeShopVolume);
            }
        }

        private void TrainSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (trainBoolean == false && train != null)
            {
                trainVolume = Convert.ToInt32(trainSlider.Value);
                train.Volume("train", trainVolume);
            }
        }

        private void FanSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fanBoolean == false && fan != null)
            {
                fanVolume = Convert.ToInt32(fanSlider.Value);
                fan.Volume("fan", fanVolume);
            }
        }

        private void WhiteNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (whiteNoiseBoolean == false && whiteNoise != null)
            {
                whiteNoiseVolume = Convert.ToInt32(whiteNoiseSlider.Value);
                whiteNoise.Volume("whitenoise", whiteNoiseVolume);
            }
        }

        private void PinkNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pinkNoiseBoolean == false && pinkNoise != null)
            {
                pinkNoiseVolume = Convert.ToInt32(pinkNoiseSlider.Value);
                pinkNoise.Volume("pinknoise", pinkNoiseVolume);
            }
        }

        private void BrownNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (brownNoiseBoolean == false && brownNoise != null)
            {
                brownNoiseVolume = Convert.ToInt32(brownNoiseSlider.Value);
                brownNoise.Volume("brownnoise", brownNoiseVolume);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralFunctions.saveFileXML();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralFunctions.loadFileCSV();
        }
    }
}
