using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ViewModel.UserControls
{
    public class UserInfoViewModel : ViewModelBase, IUserInfoContent
    {
        //public static UserInfoViewModel Instance;

        private User CurrentUser; 
        private int _userId;
        private string _userBarcode;
        private string _userName;
        private string _userProfileImagePath;
        private string _userOtherInformations;
        private List<Lanse> _lanses;
        private string _deleteOrRollbackTitle;

        private string _errorMessage;
        private bool _errorMessageVisibility;

        public RelayCommand EditUserCommand { get; private set; }
        public RelayCommand DeleteOrRollbackUserCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }
        

        public UserInfoViewModel()
        {
            CurrentUser = CopyOfThisUser(UserManagerViewModel.LastSelectedUser);

            //Instance = this;

            RefreshUserInfo();

            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.EditUserCommand = new RelayCommand(this.EditUserExecute);
            this.DeleteOrRollbackUserCommand = new RelayCommand(this.DeleteOrRollbackUserExecute);
            this.RefreshCommand = new RelayCommand(this.RefreshExecute);
        }

        public string Header => "User Info "/* + CurrentUser.FirstName + " " + CurrentUser.LastName*/;

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                RaisePropertyChanged();
            }
        }

        public string UserBarcode
        {
            get
            {
                return _userBarcode;
            }
            set
            {
                _userBarcode = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        public string UserProfileImagePath
        {
            get
            {
                return _userProfileImagePath;
            }
            set
            {
                _userProfileImagePath = value;
                RaisePropertyChanged();
            }
        }

        public string UserOtherInformations
        {
            get
            {
                return _userOtherInformations;
            }
            set
            {
                _userOtherInformations = value;
                RaisePropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            private set
            {
                _errorMessage = value;
                RaisePropertyChanged();
            }
        }

        public bool ErrorMessageVisibility
        {
            get
            {
                return _errorMessageVisibility;
            }
            private set
            {
                _errorMessageVisibility = value;
                RaisePropertyChanged();
            }
        }

        public List<Lanse> GetAllLanses()
        {
            return Fitness.Logic.Data.FitnessC.GetLanses();
        }
        
        public List<Lanse> Lanses
        {
            get
            {
                return _lanses; 
            }
            set
            {
                _lanses = value;
                RaisePropertyChanged();
            }
        }

        public string DeleteOrRollbackTitle
        {
            get
            {
                return _deleteOrRollbackTitle;
            }
            set
            {
                _deleteOrRollbackTitle = value;
                RaisePropertyChanged();
            }
        }



        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        public void EditUserExecute()
        {
            // Save current user:
            MainWindowViewModel.Instance.UserInfoToEditUserHelper = CurrentUser;
            MainWindowViewModel.Instance.SetNewTab(new EditUserViewModel());
        }

        public void DeleteOrRollbackUserExecute()
        {
            if ( CurrentUser.Active )
            {
                // Make it inactive
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this use ?", "Delete", MessageBoxButtons.YesNo);
                if ( dialogResult == DialogResult.Yes )
                {
                    CurrentUser.Active = false;
                    Fitness.Logic.Data.FitnessC.UpdateUser(CurrentUser.Id, CurrentUser);
                    DeleteOrRollbackTitle = "Rollback User";
                }
                else if ( dialogResult == DialogResult.No )
                {
                    //do nothing
                }
            }
            else
            {
                if( ! MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin") )
                {
                    System.Windows.MessageBox.Show("Only admin can rollback deleted user!");
                    return;
                }

                // if is admin:
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to rollback use ?", "Rollback", MessageBoxButtons.YesNo);
                if ( dialogResult == DialogResult.Yes )
                {
                    // Make it back active
                    CurrentUser.Active = true;
                    Fitness.Logic.Data.FitnessC.UpdateUser(CurrentUser.Id, CurrentUser);
                    DeleteOrRollbackTitle = "Delete";
                }
                else if ( dialogResult == DialogResult.No )
                {
                    //do nothing
                }
            }
            RaisePropertyChanged();
        }

        public void RefreshExecute()
        {
            RefreshUserInfo();
        }

        public void RefreshUserInfo()
        {
            _userId = CurrentUser.Id;
            _userBarcode = CurrentUser.Barcode;
            _userName = CurrentUser.FirstName + " " + CurrentUser.LastName;
            UserOtherInformations = (CurrentUser.OtherInformations.Equals(""))
                    ? "No information."
                    : CurrentUser.OtherInformations;

            if ( CurrentUser.Image.Equals("") || CurrentUser.Image.Equals("null") )
            {
                int x = 10;
                //"/AssemblyName;component/Images/ImageName.jpg"
                //UserProfileImagePath = @"/View;component/Resources/profile_icon.png";
                //UserProfileImagePath = "pack://application:Fitness.View;component/Resources/profile_icon.png";
                UserProfileImagePath = @"C:\Users\mrtin\Desktop\Fitness\View\Resources\Images\profile_icon.png";

            }
            else
            {
                UserProfileImagePath = @"C:\Users\mrtin\Desktop\Fitness\View\Resources\Images\" + CurrentUser.Image;
            }

            // Get All Lanses belongs to the current user
            List<Lanse> temp = GetAllLanses();
            Lanses = temp;//.Where(l => l.UserId == CurrentUser.Id).ToList();

            //string name = Lanses.ElementAt(0).Type.Name;
            Lanses = temp.Where(l => l.UserId == CurrentUser.Id     -1     ).ToList();

            //string name = Lanses.ElementAt(0).Type.Name;  

            // Show message if user is Invisible (user.Active == false):
            ErrorMessage = "User is Deleted!";
            if ( CurrentUser.Active )
            {
                ErrorMessageVisibility = false;
            }
            else
            {
                ErrorMessageVisibility = true;
            }

            if ( CurrentUser.Active )
            {
                DeleteOrRollbackTitle = "Delete";
            }
            else
            {
                DeleteOrRollbackTitle = "Rollback user";
            }
        }

        private User CopyOfThisUser(User user)
        {
            User result = new User();

            result.Id = user.Id;
            result.Id = user.Id;
            result.Barcode = user.Barcode;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.BirthDate = user.BirthDate;
            result.Email = user.Email;
            result.Address = user.Address;
            result.OtherInformations = user.OtherInformations;
            result.Password = user.Password;
            result.PhoneNumber = user.PhoneNumber;
            result.Image = user.Image;
            result.Role = user.Role;
            result.RegistrationDate = user.RegistrationDate;
            result.Active = user.Active;

            return result;
        }

        

    }
}
