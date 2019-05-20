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
        // Members
        public static User LastSelectedUser = null;
        private List<User> _users;
        private User _selectedUser;
        private bool _adminVisibility = false;
        private bool _EmptyDataGridMessageVisibility = false;
        public RelayCommand ItemClickCommand { get; private set; }
        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }

        // Filter
        private string _filter_FirstName;
        private string _filter_LastName;
        private string _filter_IdStr;
        private string _filter_Barcode;
        private string _filter_Email;
        private string _filter_PhoneNumber;
        private List<Role> _filter_Roles;
        private string _filter_SelectedRoleStrId;
        private bool _showInactives;
        private DateTime _filter_BirthDate;
        private DateTime _filter_FromRegistrationDate;
        private DateTime _filter_ToRegistrationDate;
        private string _birthDateChechBox;
        private string _registrationDateChechBox;
        


        public UserManagerViewModel()
        {
            this.Users = GetAllUsers();
            Users = Admin_Role_Filter(Users);       // Do not show admin & reteptionist & deleted registrations, only if admin is logged in

            this._filter_Roles = GetAllRoles();
            this._filter_Roles.Add( new Role { Id = -1, StringId = "all", Name="All", Description = "Used to List all roles" } );
            this._filter_SelectedRoleStrId = "all";
            this._showInactives = true;

            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.AddUserCommand = new RelayCommand(this.AddUserExecute);
            this.RefreshCommand = new RelayCommand(this.RefreshExecute);

            if( MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin") )
            {
                AdminVisibility = true;
            }
            else
                {
                AdminVisibility = false;
            }

            BirthDateChechBox = "True";
            RegistrationDateChechBox = "True";
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


        public void AddUserExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new AddUserViewModel());
        }

        public void RefreshExecute()
        {
            RecalculateFilters();
        }

        // Filters:

        public List<User> Id_Filter(string strId, List<User> users)
        {
            if ( strId != "" && strId != null )
            {
                try
                {
                    int id = Int32.Parse(strId);
                    return users.Where(u => u.Id == id).ToList();
                }
                catch
                {
                    return users;
                }
            }
            return users;
        }

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

        public List<User> Admin_Role_Filter( List<User> users) // Do not show admin & reteptionist registrations, only if admin is logged in
        {
            if( MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin") )
            {
                return users;
            }
            List<User> temp = users.Where(u => u.Role.Equals("client")).ToList();
            return temp.Where(u => u.Active).ToList();
        }

        // Filter Properties:

        public void RecalculateFilters()
        {
            EmptyDataGridMessageVisibility = false;
            Users = GetAllUsers();

            Users = Id_Filter( Filter_IdStr, Users );
            Users = Admin_Role_Filter( Users );   
            Users = Role_Filter( Filter_SelectedRoleStrId, Users );
            Users = ShowInactive_Filter( ShowInactives, Users );
            Users = FirstName_Filter( Filter_FirstName, Users );
            Users = LastName_Filter( Filter_LastName, Users );
            Users = Barcode_Filter( Filter_Barcode, Users );
            Users = Email_Filter( Filter_Email, Users );
            Users = PhoneNumber_Filter( Filter_PhoneNumber, Users );
            Users = BirthDate_Filter( Filter_BirthDate, Users );
            //Users = RegistrationDate_Filter( Filter_RegistrationDate, Users );            // !!!!!!!!!!!!!!!!!!!! TODO

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

        
        public string Filter_IdStr
        {
            get
            {
                return _filter_IdStr;
            }
            set
            {
                _filter_IdStr = value;
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

        public bool AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }
            private set
            {
                _adminVisibility = value;
                RaisePropertyChanged();
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

        public DateTime Filter_FromRegistrationDate
        {
            get
            {
                return _filter_FromRegistrationDate;
            }
            set
            {
                _filter_FromRegistrationDate = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public DateTime Filter_ToRegistrationDate
        {
            get
            {
                return _filter_ToRegistrationDate;
            }
            set
            {
                _filter_ToRegistrationDate = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public string BirthDateChechBox
        {
            get
            {
                return _birthDateChechBox;
            }
            set
            {
                _birthDateChechBox = value;
                RaisePropertyChanged();
            }
        }

        public string RegistrationDateChechBox
        {
            get
            {
                return _registrationDateChechBox;
            }
            set
            {
                _registrationDateChechBox = value;
                RaisePropertyChanged();
            }
        }

    }
}
