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
    public class AddUserViewModel : ViewModelBase, IAddUserContent
    {
        private User _currentUser = null;

        public DateTime _birthday;
        public string _firstName;
        public string _lastName;
        public string _barcode;
        public string _email;
        public string _address;
        public string _otherInformations;
        public string _phoneNumber;
        public List<Role> _roles;
        private string _selectedRoleStrId;
        public bool _active;
        private bool _adminVisibility;

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public AddUserViewModel()
        {
            // Get User:
            CurrentUser = new User();

            AdminVisibility = MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin")
                ? true
                : false;
            CancelCommand = new RelayCommand(CancelExecute);
            SaveCommand = new RelayCommand(SaveCanExecute);

            Role clientRole = Fitness.Logic.Data.FitnessC.GetRoles().Where(u=>u.Id == 3).FirstOrDefault();
            Roles = new List<Role>();
            Roles.Add(clientRole);
            SelectedRoleStrId = Roles.FirstOrDefault().StringId;

            BirthDay = DateTime.Now;

        }


        public string Header => "Add user: ";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        private List<Role> GetAllRoles()
        {
            return Fitness.Logic.Data.FitnessC.GetRoles();
        }

        private List<Role> GetRoles()
        {
            return Fitness.Logic.Data.FitnessC.GetRecepcionistAllowedRoles();
        }

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
            User user = new User();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.Barcode = Barcode;
            user.Address = Address;
            user.Role = SelectedRoleStrId;
            user.Active = true;
            user.PhoneNumber = PhoneNumber;
            user.OtherInformations = OtherInformations;
            
            user.Id = Fitness.Logic.Data.FitnessC.GetUsers().ToList().Count();

            // Copy remained fields:
            user.Image = "";
            user.RegistrationDate = DateTime.Now;
            user.BirthDate = BirthDay;
            user.Password = "_";

            // Update in DB
            Fitness.Logic.Data.FitnessC.InsertUser(user);
        }



        private bool ValidateInputs()
        {
           

            if (FirstName.Equals(""))
            {
                MessageBox.Show("First name must be filled!");
                return false;
            }
            if (LastName.Equals(""))
            {
                MessageBox.Show("Last Name must be filled!");
                return false;
            }
            if (Barcode.Equals(""))
            {
                MessageBox.Show("Barcode must be filled!");
                return false;
            }
            if (Email.Equals(""))
            {
                MessageBox.Show("Email must be filled!");
                return false;
            }
            //else
            //{
            //    if ( IsValidEmailAddress(Email) )
            //    {
            //        MessageBox.Show("Invalid email!");
            //        return false;
            //    }
            //}
            if (Address.Equals(""))
            {
                MessageBox.Show("Address must be filled!");
                return false;
            }
            if (PhoneNumber.Equals(""))
            {
                MessageBox.Show("Phone number must be filled!");
                return false;
            }
            return true;
        }

        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        // Property

        private User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                RaisePropertyChanged();
            }
        }
      

        public DateTime BirthDay
        {
            get { return _birthday; }
            set {
                _birthday = value;
                RaisePropertyChanged();
            }
        }


        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged();
            }
        }

        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged();
            }
        }

        public string OtherInformations
        {
            get
            {
                return _otherInformations;
            }
            set
            {
                _otherInformations = value;
                RaisePropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged();
            }
        }

        public List<Role> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                RaisePropertyChanged();
            }
        }

        public string SelectedRoleStrId
        {
            get
            {
                return _selectedRoleStrId;
            }
            set
            {
                _selectedRoleStrId = value;
                RaisePropertyChanged();
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                RaisePropertyChanged();
            }
        }

        public bool AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }
            set
            {
                _adminVisibility = value;
                RaisePropertyChanged();
            }
        }


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }
    }



}
