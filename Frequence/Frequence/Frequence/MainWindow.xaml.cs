using System;
using System.Collections.Generic;
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


    class OggPlayer
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
        private static OggPlayer rain;
        private static OggPlayer thunderStorm;
        private static OggPlayer wind;
        private static OggPlayer forest;
        private static OggPlayer leaves;
        private static OggPlayer waterStream;
        private static OggPlayer seaSide;
        private static OggPlayer water;
        private static OggPlayer firePlace;
        private static OggPlayer summerNight;
        private static OggPlayer coffeeShop;
        private static OggPlayer train;
        private static OggPlayer fan;
        private static OggPlayer whiteNoise;
        private static OggPlayer pinkNoise;
        private static OggPlayer brownNoise;

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
                rain.Volume("rain", Convert.ToInt32(rainSlider.Value));
            }
        }

        private void ThunderstormSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (thunderstormBoolean == false && thunderStorm != null)
            {
                thunderStorm.Volume("thunderstorm", Convert.ToInt32(thunderstormSlider.Value));
            }
        }

        private void WindSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (windBoolean == false && wind != null)
            {
                wind.Volume("wind", Convert.ToInt32(windSlider.Value));
            }
        }

        private void ForestSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (forestBoolean == false && forest != null)
            {
                forest.Volume("forest", Convert.ToInt32(forestSlider.Value));
            }
        }

        private void LeavesSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (leavesBoolean == false && leaves != null)
            {
                leaves.Volume("leaves", Convert.ToInt32(leavesSlider.Value));
            }
        }

        private void WaterStreamSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (waterStreamBoolean == false && waterStream != null)
            {
                waterStream.Volume("waterstream", Convert.ToInt32(waterStreamSlider.Value));
            }
        }

        private void SeaSideSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (seaSideBoolean == false && seaSide != null)
            {
                seaSide.Volume("seaside", Convert.ToInt32(seaSideSlider.Value));
            }
        }

        private void WaterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (waterBoolean == false && water != null)
            {
                water.Volume("water", Convert.ToInt32(waterSlider.Value));
            }
        }

        private void FirePlaceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (firePlaceBoolean == false && firePlace != null)
            {
                firePlace.Volume("fireplace", Convert.ToInt32(firePlaceSlider.Value));
            }
        }

        private void SummerNightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (summerNightBoolean == false && summerNight != null)
            {
                summerNight.Volume("summernight", Convert.ToInt32(summerNightSlider.Value));
            }
        }

        private void CoffeeShopSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (coffeeShopBoolean == false && coffeeShop != null)
            {
                coffeeShop.Volume("coffeeshop", Convert.ToInt32(coffeeShopSlider.Value));
            }
        }

        private void TrainSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (trainBoolean == false && train != null)
            {
                train.Volume("train", Convert.ToInt32(trainSlider.Value));
            }
        }

        private void FanSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fanBoolean == false && fan != null)
            {
                fan.Volume("fan", Convert.ToInt32(fanSlider.Value));
            }
        }

        private void WhiteNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (whiteNoiseBoolean == false && whiteNoise != null)
            {
                whiteNoise.Volume("whitenoise", Convert.ToInt32(whiteNoiseSlider.Value));
            }
        }

        private void PinkNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pinkNoiseBoolean == false && pinkNoise != null)
            {
                pinkNoise.Volume("pinknoise", Convert.ToInt32(pinkNoiseSlider.Value));
            }
        }

        private void BrownNoiseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (brownNoiseBoolean == false && brownNoise != null)
            {
                brownNoise.Volume("brownnoise", Convert.ToInt32(brownNoiseSlider.Value));
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
