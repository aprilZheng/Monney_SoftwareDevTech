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
        public Record Record { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        //click "Add" button show "AddRecordWindow"
        private void AddBtnClick(object sender, RoutedEventArgs e) {
            AddRecordWindow window=new AddRecordWindow(Record);
            window.ShowDialog();
        }
            
    }
}
