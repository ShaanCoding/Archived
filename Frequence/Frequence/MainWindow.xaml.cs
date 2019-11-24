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

        bool rainBoolean = true;
        bool thunderstormBoolean = true;
        bool windBoolean = true;
        bool forestBoolean = true;
        bool leavesBoolean = true;
        bool waterStreamBoolean = true;
        bool seaSideBoolean = true;
        bool waterBoolean = true;
        bool firePlaceBoolean = true;
        bool summerNightBoolean = true;
        bool coffeeShopBoolean = true;
        bool trainBoolean = true;
        bool fanBoolean = true;
        bool whiteNoiseBoolean = true;
        bool pinkNoiseBoolean = true;
        bool brownNoiseBoolean = true;

        public MainWindow()
        {
            InitializeComponent();

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
                firePlace.Play("fire");
                firePlaceBoolean = false;
            }
            else if (firePlaceBoolean == false)
            {
                firePlace.Stop("fire");
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
    }
}
