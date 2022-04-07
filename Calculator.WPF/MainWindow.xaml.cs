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

namespace Calculator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorController cal = new CalculatorController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "0";
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "9";
        }

        private void Button_point_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += ",";
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "+";
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "-";
        }

        private void Button_Equale_Click(object sender, RoutedEventArgs e)
        {
            string tmp = Textbox_expression.Text;
            string postfixExpresion = cal.TranslatePostfixNotation(tmp);
            double result = cal.SolveExpression(postfixExpresion);
            Textbox_answer.Text = Convert.ToString(result);
        }

        private void Button_Delit_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "/";
        }

        private void Button_umnoj_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "*";
        }

        private void Button_left_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += "(";
        }

        private void Button_right_Click(object sender, RoutedEventArgs e)
        {
            Textbox_expression.Text += ")";
        }

        private void Button_BackSpace_Click(object sender, RoutedEventArgs e)
        {
            string tmp = "";
            for (int i = 0; i < Textbox_expression.Text.Length - 1; i++)
            {
                tmp += Textbox_expression.Text[i];
            }
            Textbox_expression.Text = tmp;
        }
    }
}
