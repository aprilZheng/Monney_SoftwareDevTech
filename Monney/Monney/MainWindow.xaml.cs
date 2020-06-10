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
using Monney.Models;
using Monney.Views;

namespace Monney
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Record list for storing all records are created
        /// </summary>
        Records Records = new Records();

        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            BuildCategoryList();            
        }
        /// <summary>
        /// Click "Add" button to create a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            //add a new record
            Record record = new Record();
            DataContext = record;
            //pass value to record
            record.Category = ProcessCategory();
            record.Amount = int.Parse(AmountDisplay.Text);
            record.Date = DatePicker.SelectedDate;
            record.DateText = ProcessDateText();

            //add record to list Records
            Records.records.Add(record);

            //update amount of records
            int amountOfRecords=UpdateAmount(Records);
            AmountOfCurrentRecords.Text = amountOfRecords.ToString();

            //show new added record to window
            AddRecordToWindow(record);

            //clear values in the calculator
            ClearAll();
        }

        /// <summary>
        /// Method for updating amount of all the records in list
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public int UpdateAmount(Records records)
        {
            int amount = 0;
            foreach(Record re in records.records)
            {
                amount += re.Amount;
            }
            return amount;
        }

        /// <summary>
        /// Method for adding record to window
        /// </summary>
        public void AddRecordToWindow(Record re)
        {
            RecordView recordView = new RecordView(re);
            RecordsContainer.Children.Add(recordView);
        }

        /// <summary>
        /// Method for getting dateText
        /// </summary>
        /// <returns></returns>
        private string ProcessDateText()
        {
            DateTime? selDate = DatePicker.SelectedDate;
            if (selDate.HasValue)
            {
                string formatted = selDate.Value.ToString("yyyy-MM-dd");
                return formatted;
            }
            return null;
        }

        /// <summary>
        /// Method for getting category
        /// </summary>
        /// <returns></returns>
        private Category ProcessCategory()
        {
            ComboBoxItem selItem = (ComboBoxItem)CategoryInput.SelectedItem;
            Category tagValue = (Category)selItem.Tag;
            return tagValue;
        }

        /// <summary>
        /// Method for build category list in ComboBox
        /// </summary>
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
                CategoryInput.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Calculator part
        /// </summary>
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
            DatePicker.SelectedDate = null;
        }

        /// <summary>
        /// Update button for updating the amount of given records list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            int amountOfRecords = UpdateAmount(Records);
            AmountOfCurrentRecords.Text = amountOfRecords.ToString();
        }
    }
}
