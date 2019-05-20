using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel.UserControls
{
    public class AddLanseViewModel : ViewModelBase, IAddLanseContent
    {
       
        private Lanse _currentLanse= null;

        private bool _adminVisibility;
        private string _id;
        private List<LanseType>_types;
        private LanseType _selectedType;
        private List<User> _users;
        private User _selectedUser;
        private User _user;
        private string _userId;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _remaingTimes;
        private string _price;



        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public AddLanseViewModel()
        {
            // Get Lanse:
            CurrentLanse = new Lanse();


            CloseTabItemCommand = new RelayCommand(CloseTabItemExecute);
            CancelCommand = new RelayCommand(CancelExecute);
            SaveCommand = new RelayCommand(SaveCanExecute);

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            Types = new List<LanseType>();
            Types.Add(new LanseType { Name="SELECT TYPE" } );
            List<LanseType> ltTemp = Fitness.Logic.Data.FitnessC.GetLanseTypes().Where(lt => lt.Active == true).ToList();
            foreach(LanseType lt in ltTemp )
            {
                Types.Add(lt);
            }
            SelectedType = Types.First();


            Users = new List<User>();
            Users.Add(new User { FirstName = "SELECT USER" });
            List<User> uTemp = Fitness.Logic.Data.FitnessC.GetUsers().Where(u => u.Active == true).ToList();
            foreach ( User u in uTemp )
            {
                Users.Add(u);
            }
            SelectedUser = Users.First();

        }


        public string Header => "Add lanse: ";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        
        // Methods

        private void CancelExecute()
        {
            if (MessageBox.Show("Candel editting?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do nothing
            }
            else
            {
                CloseTabItemExecute();
            }
        }

        private void SaveCanExecute()
        {
            if (ValidateInputs())
            {
                SaveExecute();
                MessageBox.Show("Saved.");
                CloseTabItemExecute();
            }
        }

        private void SaveExecute()
        {
            Lanse lanse = new Lanse();

            lanse.Id = Fitness.Logic.Data.FitnessC.GetLanses().ToList().Count();
            lanse.Type = SelectedType;
            lanse.TypeId = SelectedType.Id;
            lanse.User = SelectedUser;
            lanse.UserId = SelectedUser.Id;
            lanse.StartDate = StartDate;
            lanse.EndDate = EndDate;
            lanse.RemainingTimes = SelectedType.ActiveTimes;
            lanse.Price = SelectedType.Price;
            lanse.Active = true;
           
            // Update in DB
            Fitness.Logic.Data.FitnessC.InsertLanse(lanse);
        }



        private bool ValidateInputs()
        {
            if ( SelectedType == Types.First() )
            {
                MessageBox.Show("Select type!");
                return false;
            }


            if ( SelectedUser == Users.First() )
            {
                MessageBox.Show("Select user!");
                return false;
            }


            return true;
        }
        
        // Property
       
        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        // Properties

        public Lanse CurrentLanse
        {
            get { return _currentLanse; }
            set
            {
                _currentLanse = value;
                RaisePropertyChanged();
            }
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }
               
        public string RemaingTimes
        {
            get { return _remaingTimes; }
            set
            {
                _remaingTimes = value;
                RaisePropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged();

            }
        }
        
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                RaisePropertyChanged();
            }
        }
                  
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public List<LanseType> Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
                RaisePropertyChanged();
            }
        }

        public LanseType SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                RaisePropertyChanged();
            }
        }

        public List<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                RaisePropertyChanged();
            }
        }

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                RaisePropertyChanged();
            }
        }


    }
}
