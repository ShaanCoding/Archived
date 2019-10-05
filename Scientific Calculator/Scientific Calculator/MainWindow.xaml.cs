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
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            expression += "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            expression += "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            expression += "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            expression += "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            expression += "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            expression += "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            expression += "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            expression += "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            expression += "9";
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            expression += ".";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(Solver.solveValue(expression).ToString());
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            expression += "/";
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            expression += "*";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            expression += "-";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            expression += "+";
        }

        private void ParenthesisLeft_Click(object sender, RoutedEventArgs e)
        {
            expression += "(";
        }

        private void ParenthesisRight_Click(object sender, RoutedEventArgs e)
        {
            expression += ")";
        }
        private void ViewExpression_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(expression);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            expression.Remove(expression.Length - 1);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            expression = "";
        }
    }
}
