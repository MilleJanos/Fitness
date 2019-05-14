using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddLanseTypeViewModel : ViewModelBase, IAddLanseTypeContent
    {

        private String _name;
        private int _activeDays;
        private int _activePerDay;
        private int _activeHours;
        private int _price;
        private string _description;
        private Boolean _active;

        public AddLanseTypeViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);

        }


        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public int ActiveDays
        {
            get { return _activeDays; }
            set { _activeDays = value; }
        }

        public int ActivePerDay
        {
            get { return _activePerDay; }
            set { _activePerDay = value; }
        }

        public int ActiveHours
        {
            get { return _activeHours; }
            set { _activeHours = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Boolean Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public string Header => "Create New Lance Type";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }
    }
}
