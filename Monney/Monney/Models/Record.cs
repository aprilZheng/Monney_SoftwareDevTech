using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monney.Models
{
    public class Record:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void TriggerPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int amount;
        private Category category;
        private DateTime? date;
        private string dateText;

        public int Amount
        {
            get => amount;
            set
            {
                if (amount != value)
                {
                    amount = value;
                    TriggerPropertyChanged("Amount");
                }
            }
        }

        public Category Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    TriggerPropertyChanged("Category");
                }
            }
        }

        public DateTime? Date
        {
            get => date;
            set
            {
                date = value;
                if (date == null)
                {
                    DateText = null;
                }
                else
                {
                    DateTime nonNullable = (DateTime)date;
                    DateText = nonNullable.ToString("yyyy-MM-dd");
                }
            }
        }

        public string DateText
        {
            get => dateText;
            set
            {
                if (dateText != value)
                {
                    dateText = value;
                    TriggerPropertyChanged("DateText");
                }
            }
        }

    }
}
