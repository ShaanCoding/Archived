using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _4SChan
{
    /// <summary>
    /// Interaction logic for SettingsMenu.xaml
    /// </summary>
    public partial class SettingsMenu : Window
    {
        public SettingsMenu()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            MessageBoxOnCompleteCheckBox.IsChecked = Properties.Settings.Default.showMessageBoxOnComplete;
            ExitOnCompleteCheckBox.IsChecked = Properties.Settings.Default.exitOnComplete;
            DownloadDirectoryTextBox.Text = Properties.Settings.Default.downloadDirectory;
            CreateSubFolderOnDownloadCheckBox.IsChecked = Properties.Settings.Default.createSubFolderOnDownload;
            SaveWithOriginalFileNameCheckBox.IsChecked = Properties.Settings.Default.saveWithOriginalFileName;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //Saves Data
            Properties.Settings.Default.showMessageBoxOnComplete = (bool)MessageBoxOnCompleteCheckBox.IsChecked;
            Properties.Settings.Default.exitOnComplete = (bool)ExitOnCompleteCheckBox.IsChecked;
            Properties.Settings.Default.downloadDirectory = DownloadDirectoryTextBox.Text;
            Properties.Settings.Default.createSubFolderOnDownload = (bool)CreateSubFolderOnDownloadCheckBox.IsChecked;
            Properties.Settings.Default.saveWithOriginalFileName = (bool)SaveWithOriginalFileNameCheckBox.IsChecked;
            Properties.Settings.Default.Save();

            //Override MainWindow.cs global variables for settings
            MainWindow.AssignProperties();

            this.Close();
        }

        private void OpenFileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.IsFolderPicker = true;
                if(openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    DownloadDirectoryTextBox.Text = openFileDialog.FileName;
                }
            }

            //Focuses back on original window
            this.Focus();
        }

        private void MessageBoxOnCompleteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Can only be one or the other not both
            ExitOnCompleteCheckBox.IsChecked = false;
        }

        private void ExitOnCompleteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Can be one or the other not both
            MessageBoxOnCompleteCheckBox.IsChecked = false;
        }
    }
}
