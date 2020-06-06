using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monney.Models
{
    class Record:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void TriggerPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int spendingAmount;
        private Category category;
        private DateTime? spendingDate;
        private string spendingDateText;

        public int SpendingAmount
        {
            get => spendingAmount;
            set
            {
                if (spendingAmount != value)
                {
                    spendingAmount = value;
                    TriggerPropertyChanged("SpendingAmount");
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

        public DateTime? SpendingDate
        {
            get => spendingDate;
            set
            {
                spendingDate = value;
                if (spendingDate == null)
                {
                    SpendingDateText = null;
                }
                else
                {
                    DateTime nonNullable = (DateTime)spendingDate;
                    SpendingDateText = nonNullable.ToString("yyy-MM-dd");
                }
            }
        }

        public string SpendingDateText
        {
            get => spendingDateText;
            set
            {
                if (spendingDateText != value)
                {
                    spendingDateText = value;
                    TriggerPropertyChanged("SpendingDateText");
                }
            }
        }

    }
}
