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
using System.Globalization;


namespace Monney.Views
{
    /// <summary>
    /// Interaction logic for RecordView.xaml
    /// </summary>
    public partial class RecordView : UserControl
    {
        public Record Record { get; set; }

        public RecordView(Record record)
        {
            Record = record;
            DataContext = Record;

            InitializeComponent();
        }
    }
}
