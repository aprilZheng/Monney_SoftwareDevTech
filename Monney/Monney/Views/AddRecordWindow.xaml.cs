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

namespace Monney.Views
{
    /// <summary>
    /// Interaction logic for AddRecordWindow.xaml
    /// </summary>
    public partial class AddRecordWindow : Window
    {
        public AddRecordWindow()
        {
            InitializeComponent();
        }

        //Calculate part
        long number1 = 0;
        long number2 = 0;
        string operation = "";

        private void Num_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {//convert button content to number
                number1 = (number1 * 10) + int.Parse(((Button)sender).Content.ToString());
                AmountDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + int.Parse(((Button)sender).Content.ToString());
                AmountDisplay.Text = number2.ToString();
            }
        }

        private void Math_Btn_Click(object sender, RoutedEventArgs e)
        {
            operation = ((Button)sender).Content.ToString();
            AmountDisplay.Text = "0";
        }

        private void Equal_Btn_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    AmountDisplay.Text = (number1 + number2).ToString();
                    break;
                case "-":
                    AmountDisplay.Text = (number1 - number2).ToString();
                    break;
                case "*":
                    AmountDisplay.Text = (number1 * number2).ToString();
                    break;
                case "/":
                    AmountDisplay.Text = (number1 / number2).ToString();
                    break;
                case "":
                    AmountDisplay.Text = "0";
                    break;
            }
            operation = "";
            number2 = 0;
            number1 = int.Parse(AmountDisplay.Text);
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 / 10);
                AmountDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 / 10);
                AmountDisplay.Text = number2.ToString();
            }
        }

        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            number1 = number2 = 0;
            operation = "";
            AmountDisplay.Text = "0";
        }

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
