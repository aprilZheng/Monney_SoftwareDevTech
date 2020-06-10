using Monney.Models;
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
using Monney;

namespace Monney.Views
{
    /// <summary>
    /// Interaction logic for EditRecordWindow.xaml
    /// </summary>
    public partial class EditRecordWindow : Window
    {
        public Record Record { get; }
        public DateTime? OriginalDate { get; }

        /// <summary>
        /// Window constructor, with an input parameter
        /// </summary>
        /// <param name="recordIn"></param>
        public EditRecordWindow(Record recordIn)
        {
            InitializeComponent();

            //sharing data
            Record = recordIn;
            DataContext = Record;

            OriginalDate = Record.Date;

            //build category list
            BuildCategoryList();
        }
        
        /// <summary>
        /// Ok button for submitting value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            Record.Category = ProcessCategory();
            Record.Amount = int.Parse(AmountDisplay.Text);

            Close();
        }

        /// <summary>
        /// Cancle button, not making any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancle_Btn_Click(object sender, RoutedEventArgs e)
        {
            Record.Date = OriginalDate;
            Close();
        }

        //method for build category list in ComboBox
        private void BuildCategoryList()
        {
            //get every value from Category enum class
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                string title = category.ToString().ToLower();
                title = title[0].ToString().ToUpper() + title.Substring(1);

                //new combox item and set properties
                ComboBoxItem item = new ComboBoxItem
                {
                    Tag = category,
                    Content = title
                };
                //add combox item to frontend
                CategoryInput.Items.Add(item);
                //set default value is the first value of Category
                if (Record.Category == category)
                {
                    CategoryInput.SelectedItem = item;
                }
            }
        }

        //method for getting category
        private Category ProcessCategory()
        {
            ComboBoxItem selItem = (ComboBoxItem)CategoryInput.SelectedItem;
            Category tagValue = (Category)selItem.Tag;
            return tagValue;
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
            ClearAll();
        }

        //method for clear all key in values
        public void ClearAll()
        {
            number1 = number2 = 0;
            operation = "";
            AmountDisplay.Text = "0";
            CategoryInput.SelectedIndex = 0;
            DatePicker.Value = null;
        }

    }

}
