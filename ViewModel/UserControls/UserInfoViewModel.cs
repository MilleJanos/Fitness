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
        private User SelectedUser; 
        private int _userId;
        private string _userBarcode;
        private string _userName;

        public UserInfoViewModel()
        {
            SelectedUser = UserManagerViewModel.LastSelectedUser;
            _userId = SelectedUser.Id;
            _userBarcode = SelectedUser.Barcode;
            _userName = SelectedUser.FirstName + " " + SelectedUser.LastName;
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
        }

        public string Header => "User Info: " + SelectedUser.FirstName + " " + SelectedUser.LastName;

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

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

    }
}
