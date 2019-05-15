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

        private List<User> _users;
        private User _selectedUser;

        public RelayCommand ItemClickCommand { get; private set; }

        public UserManagerViewModel()
        {
            this._users = Fitness.Logic.Data.FitnessC.GetUsers();
            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
        }


        public string Header => "User Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        public void ItemClickExecute()
        {
            // TODO: Jancsi
            int nope = 0;
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
