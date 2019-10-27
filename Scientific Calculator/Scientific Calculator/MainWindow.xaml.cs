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


namespace Scientific_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Solver Solver = new Solver();
        string expression = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            expression += "0";
            expressionDisplay.Text = expression;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            expression += "1";
            expressionDisplay.Text = expression;
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            expression += "2";
            expressionDisplay.Text = expression;
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            expression += "3";
            expressionDisplay.Text = expression;
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            expression += "4";
            expressionDisplay.Text = expression;
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            expression += "5";
            expressionDisplay.Text = expression;
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            expression += "6";
            expressionDisplay.Text = expression;
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            expression += "7";
            expressionDisplay.Text = expression;
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            expression += "8";
            expressionDisplay.Text = expression;
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            expression += "9";
            expressionDisplay.Text = expression;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            expression += ".";
            expressionDisplay.Text = expression;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            expression = Solver.solveValue(expression).ToString();
            expressionDisplay.Text = expression;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            expression += "/";
            expressionDisplay.Text = expression;
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            expression += "*";
            expressionDisplay.Text = expression;
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            expression += "-";
            expressionDisplay.Text = expression;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            expression += "+";
            expressionDisplay.Text = expression;
        }

        private void ParenthesisLeft_Click(object sender, RoutedEventArgs e)
        {
            expression += "(";
            expressionDisplay.Text = expression;
        }

        private void ParenthesisRight_Click(object sender, RoutedEventArgs e)
        {
            expression += ")";
            expressionDisplay.Text = expression;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            expression.Remove(expression.Length - 1);
            expressionDisplay.Text = expression;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            expression = "";
            expressionDisplay.Text = expression;
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            expression += "^";
            expressionDisplay.Text = expression;
        }

        private void Nothing_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
