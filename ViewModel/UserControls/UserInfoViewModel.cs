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
    public class UserInfoViewModel : ViewModelBase, IUserInfoContent
    {
        private User CurrentUser; 
        private int _userId;
        private string _userBarcode;
        private string _userName;
        private string _userProfileImagePath;
        private string _userOtherInformations;
        private List<Lanse> _lanses;

        public UserInfoViewModel()
        {
            CurrentUser = UserManagerViewModel.LastSelectedUser;
            _userId = CurrentUser.Id;
            _userBarcode = CurrentUser.Barcode;
            _userName = CurrentUser.FirstName + " " + CurrentUser.LastName;
            if( CurrentUser.Image.Equals("") || CurrentUser.Image.Equals("null") )
            {
                UserProfileImagePath = @"/View;component/Resources/profile_icon.png";
            }
            else
            {
                UserProfileImagePath = @"/View;component/Resources/" + CurrentUser.Image;
            }
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);

            // Get All Lanses belongs to the current user
            List<Lanse> temp = GetAllLanses();
            Lanses = temp;//.Where(l => l.UserId == CurrentUser.Id).ToList();

            //string name = Lanses.ElementAt(0).Type.Name;

        }

        public string Header => "User Info: " + CurrentUser.FirstName + " " + CurrentUser.LastName;

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

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

    }
}
