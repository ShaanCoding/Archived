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
using System.Windows.Shapes;

namespace IconDrive
{
    /// <summary>
    /// Interaction logic for selectDriveDialog.xaml
    /// </summary>
    public partial class selectDriveDialog : Window
    {
        public static DriveInfo[] driveArray;
        public selectDriveDialog()
        {
            InitializeComponent();
            driveArray = DriveInfo.GetDrives();
            for(int i = 0; i < driveArray.Length; i++)
            {
                listBoxAnswer.Items.Add(driveArray[i].Name);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if(driveArray.Length >= 2)
            {
                listBoxAnswer.SelectedIndex = 1;
                listBoxAnswer.UpdateLayout();
            }
            else
            {
                listBoxAnswer.SelectedIndex = 0;
                listBoxAnswer.UpdateLayout();
            }
            /*
            txtAnswer.SelectAll();
            txtAnswer.Focus();
            */
        }
        public string Answer
        {
            get { return listBoxAnswer.SelectedItem.ToString(); }
        }

        public string Answer2
        {
            get { return driveArray[listBoxAnswer.SelectedIndex].VolumeLabel; }
        }
        private void ListBoxAnswer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnDialogOk_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
