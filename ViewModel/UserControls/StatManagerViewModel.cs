using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class StatManagerViewModel : ViewModelBase, IStatManagerContent
    {
        private int _totalCount;
        private int _count_6_10;
        private int _count_10_14;
        private int _count_14_20;
        private int _count_20_6;

        public int Count_20_6
        {
            get { return _count_20_6; }
            set
            {
                _count_20_6 = value;
                RaisePropertyChanged();
            }
        }

        public int Count_14_20
        {
            get { return _count_14_20; }
            set { _count_14_20 = value;
                RaisePropertyChanged();
            }
        }


        public int Count_10_14
        {
            get { return _count_10_14; }
            set { _count_10_14 = value;
                RaisePropertyChanged();
            }
        }



        public int Count_6_10
        {
            get { return _count_6_10; }
            set {
                _count_6_10 = value;
                RaisePropertyChanged();
            }
        }


        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value;
                RaisePropertyChanged();
            }
        }


        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value;
                RaisePropertyChanged();
            }
        }

        public StatManagerViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            Entry entry = new Entry();
            CalculateStatistic();

        }

        public string Header => "Statistic Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

       public void CalculateStatistic()
        {
            TotalCount = Fitness.Logic.Data.FitnessC.GetEntryes().Count();
            Count_6_10 = Fitness.Logic.Data.FitnessC.GetEntryes().Where(e=>e.Date.Hour>=6 && e.Date.Hour<10).Count();
            Count_10_14 = Fitness.Logic.Data.FitnessC.GetEntryes().Where(e=>e.Date.Hour>=10 && e.Date.Hour<14).Count();
            Count_14_20 = Fitness.Logic.Data.FitnessC.GetEntryes().Where(e=>e.Date.Hour>=14 && e.Date.Hour<=20).Count();
            Count_20_6 = Fitness.Logic.Data.FitnessC.GetEntryes().Where(e=>e.Date.Hour>11 && e.Date.Hour<12).Count();

        }
        
    }
}
