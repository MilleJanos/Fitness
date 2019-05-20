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
            User user = new User();

        }

        public string Header => "Statistic Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

       /* public List<User> Counter(User user)
        {
            return user;
        }
        */
    }
}
