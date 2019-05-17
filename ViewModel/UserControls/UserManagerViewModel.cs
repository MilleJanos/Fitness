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
    public class UserManagerViewModel : ViewModelBase, IUserManagerContent
    {
        public static User LastSelectedUser = null;

        private List<User> _users;
        private User _selectedUser;
        private bool _EmptyDataGridMessageVisibility = false;
        public RelayCommand ItemClickCommand { get; private set; }
        public RelayCommand ClearBirthDateCommand { get; private set; }
        public RelayCommand ClearRegistrationDateCommand { get; private set; }

        // Filter
        private string _filter_FirstName;
        private string _filter_LastName;
        private string _filter_Barcode;
        private string _filter_Email;
        private string _filter_PhoneNumber;
        private List<Role> _filter_Roles;
        private string _filter_SelectedRoleStrId;
        private DateTime _filter_BirthDate;
        private DateTime _filter_RegistrationDate;
        private bool _showInactives;

               
        public UserManagerViewModel()
        {
            this._users = GetAllUsers();
            this._filter_Roles = GetAllRoles();
            this._filter_Roles.Add( new Role { Id = -1, StringId = "all", Name="All", Description = "Used to List all roles" } );
            this._filter_SelectedRoleStrId = "all";
            this._showInactives = true;
            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.ClearBirthDateCommand = new RelayCommand(this.ClearBirthDateExecute);
            this.ClearRegistrationDateCommand = new RelayCommand(this.ClearRegistrationDateExecute);
        }


        public string Header => "User Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        // Commands / CanExecutes / Executes:

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        private List<User> GetAllUsers()
        {
            return Fitness.Logic.Data.FitnessC.GetUsers();
        }

        private List<Role> GetAllRoles()
        {
            return Fitness.Logic.Data.FitnessC.GetRoles();
        }

        public void ItemClickExecute()
        {
            LastSelectedUser = SelectedUser;
            MainWindowViewModel.Instance.SetNewTab(new UserInfoViewModel());
        }

        public void ClearBirthDateExecute()
        {
            Filter_BirthDate = System.DateTime.Now; // TODO: Change this logic (now == filter off) (1)
        }

        public void ClearRegistrationDateExecute()
        {
            Filter_RegistrationDate = System.DateTime.Now; // TODO: Change this logic (now == filter off) (2)
        }

        // Filters:

        public List<User> FirstName_Filter(string firstname, List<User> users)
        {
            if ( firstname != "" && firstname != null )
                return users.Where(u => u.FirstName.ToLower().Contains(firstname.ToLower())).ToList();
            return users;
        }

        public List<User> LastName_Filter(string lastname, List<User> users)
        {
            if ( lastname != "" && lastname != null )
                return users.Where(u => u.LastName.ToLower().Contains(lastname.ToLower())).ToList();
            return users;
        }

        public List<User> Email_Filter(string email, List<User> users)
        {
            if ( email != "" && email != null )
                return users.Where(u => u.Email.ToLower().Contains(email.ToLower())).ToList();
            return users;
        }

        public List<User> PhoneNumber_Filter(string phonenumber, List<User> users)
        {
            if ( phonenumber != "" && phonenumber != null )
                return users.Where(u => u.PhoneNumber.Contains(phonenumber)).ToList();
            return users;
        }

        public List<User> Barcode_Filter(string barcode, List<User> users)
        {
            if ( barcode != "" && barcode != null )
                return users.Where(u => u.Barcode.Contains(barcode)).ToList();
            return users;
        }

        public List<User> Role_Filter(string rolestringid, List<User> users)
        {
            if ( !rolestringid.Equals("all") )
                return users.Where(u => u.Role == rolestringid).ToList();
            return users;
        }

        public List<User> BirthDate_Filter(DateTime datetime, List<User> users)
        {
            if ( datetime.Equals(System.DateTime.Now) )      // TODO: Change this logic (now == filter off) (1)
                return users.Where(u => u.BirthDate.Equals(datetime)).ToList();
            return users;
        }

        public List<User> RegistrationDate_Filter(DateTime datetime, List<User> users)
        {
            if ( datetime.Equals(System.DateTime.Now) )     // TODO: Change this logic (now == filter off) (2)
                return users.Where(u => u.RegistrationDate.Equals(datetime)).ToList();
            return users;
        }

        public List<User> ShowInactive_Filter(bool showactive, List<User> users)
        {
            if ( ! showactive )     
                return users.Where(u => u.Active == true ).ToList();
            return users;
        }

        // Filter Properties:

        public void RecalculateFilters()
        {
            EmptyDataGridMessageVisibility = false;
            Users = GetAllUsers();

            Users = Role_Filter( Filter_SelectedRoleStrId, Users );
            Users = ShowInactive_Filter( ShowInactives, Users );
            Users = FirstName_Filter( Filter_FirstName, Users );
            Users = LastName_Filter( Filter_LastName, Users );
            Users = Barcode_Filter( Filter_Barcode, Users );
            Users = Email_Filter( Filter_Email, Users );
            Users = PhoneNumber_Filter( Filter_PhoneNumber, Users );
            Users = BirthDate_Filter( Filter_BirthDate, Users );
            Users = RegistrationDate_Filter( Filter_RegistrationDate, Users );

            if ( Users.Count == 0 )
            {
                EmptyDataGridMessageVisibility = true;
            }
        }

        // Properties:

        public string Filter_FirstName
        {
            get
            {
                return _filter_FirstName;
            }
            set
            {
                _filter_FirstName = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public string Filter_LastName
        {
            get
            {
                return _filter_LastName;
            }
            set
            {
                _filter_LastName = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public string Filter_Barcode
        {
            get
            {
                return _filter_Barcode;
            }
            set
            {
                _filter_Barcode = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public string Filter_Email
        {
            get
            {
                return _filter_Email;
            }
            set
            {
                _filter_Email = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public string Filter_PhoneNumber
        {
            get
            {
                return _filter_PhoneNumber;
            }
            set
            {
                _filter_PhoneNumber = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public bool EmptyDataGridMessageVisibility
        {
            get
            {
                return _EmptyDataGridMessageVisibility;
            }
            set
            {
                _EmptyDataGridMessageVisibility = value;
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

        public List<Role> Filter_Roles
        {
            get
            {
                return _filter_Roles;
            }
            set
            {
                _filter_Roles = value;
                RaisePropertyChanged();
            }
        }

        public string Filter_SelectedRoleStrId
        {
            get
            {
                return _filter_SelectedRoleStrId;
            }
            set
            {
                _filter_SelectedRoleStrId = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public DateTime Filter_BirthDate
        {
            get
            {
                return _filter_BirthDate;
            }
            set
            {
                _filter_BirthDate = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public DateTime Filter_RegistrationDate
        {
            get
            {
                return _filter_RegistrationDate;
            }
            set
            {
                _filter_RegistrationDate = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public bool ShowInactives
        {
            get
            {
                return _showInactives;
            }
            set
            {
                _showInactives = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

    }
}
