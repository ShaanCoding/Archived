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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlayerEnum currentPlayer = PlayerEnum.XPlayer;
        public int turns = 0;
        public int playerXWins = 0;
        public int playerOWins = 0;
        public int playerDraws = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GridClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if((string)button.Content != "O" && (string)button.Content != "X")
            {
                if(currentPlayer == PlayerEnum.XPlayer)
                {
                    button.Content = "X";
                    currentPlayer = PlayerEnum.OPlayer;
                }
                else if(currentPlayer == PlayerEnum.OPlayer)
                {
                    button.Content = "O";
                    currentPlayer = PlayerEnum.XPlayer;
                }

                turns++;

                if (CheckWinner())
                {
                    if ((string)button.Content == "X")
                    {
                        MessageBox.Show("X Won!");
                        playerXWins++;
                        XWinLabel.Content = "X Win: " + playerXWins;
                        NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O Won!");
                        playerOWins++;
                        XWinLabel.Content = "O Win: " + playerOWins;
                        NewGame();
                    }
                }
                else
                {
                    if (CheckDraw())
                    {
                        MessageBox.Show("Tie!");
                        playerDraws++;
                        DrawsLabel.Content = "Draws: " + playerDraws;
                        NewGame();
                    }
                }
            }
        }

        public void NewGame()
        {
            currentPlayer = PlayerEnum.XPlayer;
            turns = 0;
            B00.Content = B01.Content = B02.Content = B10.Content = B11.Content = B12.Content = B20.Content = B21.Content = B22.Content = "";
        }

        public bool CheckWinner()
        {
            //Check Rows
            if(B00.Content == B10.Content && B10.Content == B20.Content && (string)B00.Content != "") { return true; }
            if(B01.Content == B11.Content && B11.Content == B21.Content && (string)B01.Content != "") { return true; }
            if(B02.Content == B12.Content && B12.Content == B22.Content && (string)B02.Content != "") { return true; }

            //Check columns
            if(B00.Content == B01.Content && B01.Content == B02.Content && (string)B00.Content != "") { return true; }
            if(B10.Content == B11.Content && B11.Content == B12.Content && (string)B10.Content != "") { return true; }
            if(B20.Content == B21.Content && B21.Content == B22.Content && (string)B20.Content != "") { return true; }

            if(B00.Content == B11.Content && B11.Content == B22.Content && (string)B00.Content != "") { return true; }
            if(B02.Content == B11.Content && B11.Content == B20.Content && (string)B02.Content != "") { return true; }

            return false;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = PlayerEnum.XPlayer;
            turns = 0;
            B00.Content = B01.Content = B02.Content = B10.Content = B11.Content = B12.Content = B20.Content = B21.Content = B22.Content = "";
            playerXWins = 0;
            playerOWins = 0;
            playerDraws = 0;
        }

        public bool CheckDraw()
        {
            return turns == 9;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
