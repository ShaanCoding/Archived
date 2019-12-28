using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace IconDrive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedIconString = "";
        private DriveInfo[] driveArray;
        private string selectedDriveString = "";
        private string nameOfDrive = "";
        private bool readyToInstall;

        public MainWindow()
        {
            InitializeComponent();

            //Initalises drive label & selected drive
            driveArray = DriveInfo.GetDrives();
            if (driveArray.Length >= 2)
            {
                selectedDriveString = driveArray[1].Name;
                nameOfDrive = driveArray[1].VolumeLabel;
            }
            else
            {
                selectedDriveString = driveArray[0].Name;
                nameOfDrive = driveArray[0].VolumeLabel;
            }
            SelectedDriveLabel.Content = nameOfDrive + " (" + selectedDriveString + ")";
        }

        private void IconSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectIcon = new OpenFileDialog();
            selectIcon.Filter = "ICO|*.ico";
            if(selectIcon.ShowDialog() == true)
            {
                selectedIconString = selectIcon.FileName;
                iconSelector.Content = System.IO.Path.GetFileName(selectIcon.FileName);
                readyToInstall = true;
                installButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF31C4FF"));
            }
        }

        private void SelectDrive_Click(object sender, RoutedEventArgs e)
        {
            selectDriveDialog selectDriveDialog = new selectDriveDialog();
            selectDriveDialog.Owner = this;
            selectDriveDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (selectDriveDialog.ShowDialog() == true)
            {
                selectedDriveString = selectDriveDialog.Answer;
                nameOfDrive = selectDriveDialog.Answer2;
                SelectedDriveLabel.Content = nameOfDrive + " (" + selectedDriveString + ")";
            }
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //replace this with styling
                if (readyToInstall == true)
                {
                    //Writes autorun.inf & places logo (both are set to hidden in windows)

                    //Deletes original file prior to writing
                    if (File.Exists(selectedDriveString + "autorun.inf"))
                    {
                        File.Delete(selectedDriveString + "autorun.inf");
                    }
                    if (File.Exists(selectedDriveString + "icon.ico"))
                    {
                        File.Delete(selectedDriveString + "icon.ico");
                    }

                    //Copys files over
                    File.Copy(selectedIconString, selectedDriveString + "icon.ico");

                    using (Stream s = File.Open(selectedDriveString + "autorun.inf", FileMode.CreateNew))
                    {
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.WriteLine("[autorun]");
                            sw.WriteLine("icon=icon.ico");
                            sw.Close();
                            s.Close();
                        }
                    }

                    //Makes hidden
                    File.SetAttributes(selectedDriveString + "icon.ico", File.GetAttributes(selectedDriveString + "icon.ico") | FileAttributes.Hidden);
                    File.SetAttributes(selectedDriveString + "autorun.inf", File.GetAttributes(selectedDriveString + "autorun.inf") | FileAttributes.Hidden);
                    MessageBox.Show("Application Sucessfully Installed!");
                }
                else
                {
                    MessageBox.Show("Not Ready To Install, Please Select Icon");
                }
            }
            catch
            {
                MessageBox.Show("Icon Installation Failed!");
            }
        }
    }
}
