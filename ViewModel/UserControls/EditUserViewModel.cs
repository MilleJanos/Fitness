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
    public class EditUserViewModel : ViewModelBase, IEditUserContent
    {
        private User _currentUser = null;

        public int _id;
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

        private RelayCommand CancelCommand;
        private RelayCommand SaveCommand;

        public EditUserViewModel()
        {
            // Get User:
            CurrentUser = MainWindowViewModel.Instance.UserInfoToEditUserHelper;

            LoadInitState();
        }


        public string Header => "Edit user: " + CurrentUser.FirstName + " " + CurrentUser.LastName;

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        public void LoadInitState()
        {
            Id = CurrentUser.Id;
            FirstName = CurrentUser.FirstName;
            LastName = CurrentUser.LastName;
            Barcode = CurrentUser.Barcode;
            Email = CurrentUser.Email;
            Address = CurrentUser.Address;
            OtherInformations = CurrentUser.OtherInformations;
            PhoneNumber = CurrentUser.PhoneNumber;
            Active = CurrentUser.Active;

            Roles = GetAllRoles();
            Roles.Add(new Role { Id = -1, StringId = "all", Name = "All", Description = "Used to List all roles" });

            this.CancelCommand = new RelayCommand(this.CancelExecute);
            this.SaveCommand = new RelayCommand(this.SaveCanExecute);
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
        }

        private List<Role> GetAllRoles()
        {
            return Fitness.Logic.Data.FitnessC.GetRoles();
        }

        private void CancelExecute()
        {
            if ( MessageBox.Show("Candel editting?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No )
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
            if ( ValidateInputs() )
            {
                SaveExecute();
            }
        }

        private void SaveExecute()
        {
            User user = new User();
            user.Id = CurrentUser.Id;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.Barcode = Barcode;
            user.Address = Address;
            user.Role = SelectedRoleStrId;
            user.Active = Active;
            user.PhoneNumber = PhoneNumber;
            // Copy remained fields:
            user.Image = CurrentUser.Image;
            user.RegistrationDate = CurrentUser.RegistrationDate;
            user.BirthDate = CurrentUser.BirthDate;

            // Update in DB
            Fitness.Logic.Data.FitnessC.UpdateUser(user.Id, user);
        }



        private bool ValidateInputs()
        {
            if ( Id.Equals("") )
            {
                MessageBox.Show("Id must be filled!");
                return false;
            }


            if ( FirstName.Equals("") )
            {
                MessageBox.Show("First name must be filled!");
                return false;
            }
            if ( LastName.Equals("") )
            {
                MessageBox.Show("Last Name must be filled!");
                return false;
            }
            if ( Barcode.Equals("") )
            {
                MessageBox.Show("Barcode must be filled!");
                return false;
            }
            if ( Email.Equals("") )
            {
                MessageBox.Show("Email must be filled!");
                return false;
            }
            else
            {
                if ( IsValidEmailAddress(Email) )
                {
                    MessageBox.Show("Invalid email!");
                    return false;
                }
            }
            if ( Address.Equals("") )
            {
                MessageBox.Show("Address must be filled!");
                return false;
            }
            if ( PhoneNumber.Equals("") )
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

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }
    }
}
