using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel;
using ViewModel.UserControls;

namespace Fitness.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Common:
        public static MainWindowViewModel Instance { get; private set; }
        //onmga tarolja az informaciookat onmagaban
        public static User _userInfoToEditUserHelper = null;    // Used to help pass User object from UserInfo to EditUser

        private bool _loginVisibility;
        private bool _homeVisibility;

        // Login:
        public RelayCommand LoginCommand { get; private set; }
        private User loggedInUser;

        private string loginEmail;
        private string loginPassword;

        // Logout:
        public RelayCommand LogoutCommand { get; private set; }

        // Home:
        public RelayCommand CloseCommand { get; private set; }

        private string _pageTitle = "MainPage";
        private ObservableCollection<IMainContent> _contents;
        private IMainContent _selectedContent;
        private IMainContent _prevSelectedContent;

        

        public MainWindowViewModel()
        {
            Instance = this;

            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.LoginCommand = new RelayCommand(this.LoginCommandCanExecute);
            this.LogoutCommand = new RelayCommand(this.LogoutCommandCanExecute);

            LoginVisibility = true;
            HomeVisibility = false;

            GenerateContents();

            /*DELETE THIS:*/
            DeleteMe1Command = new RelayCommand(this.DeleteMe1Execute); /*:DELETE THIS*/
            DeleteMe2Command = new RelayCommand(this.DeleteMe2Execute); /*:DELETE THIS*/
            DeleteMe3Command = new RelayCommand(this.DeleteMe3Execute); /*:DELETE THIS*/
        }

        //
        // Common: Switch
        //

        private void ShowLoginPage()
        {
            LoginVisibility = true;
        }

        private void ShowHomePage()
        {
            HomeVisibility = true;
        }

        public bool LoginVisibility
        {
            get
            {
                return _loginVisibility;
            }
            set
            {
                _loginVisibility = value;
                if ( _loginVisibility == true )
                {
                    if ( HomeVisibility == true )
                    {
                        HomeVisibility = false;
                    }
                }
                else
                {
                    if ( HomeVisibility == false )
                    {
                        HomeVisibility = true;
                    }
                }
                RaisePropertyChanged();
            }
        }

        public bool HomeVisibility
        {
            get
            {
                return _homeVisibility;
            }
            set
            {
                _homeVisibility = value;
                if( _homeVisibility == true )
                {
                    if ( LoginVisibility == true )
                    {
                        LoginVisibility = false;
                    }
                }
                else
                {
                    if ( LoginVisibility == false )
                    {
                        LoginVisibility = true;
                    }
                }
                RaisePropertyChanged();
            }
        }

        //
        // LOGIN:
        //

        public void LoginCommandCanExecute()
        {
            User user=Fitness.Logic.Data.FitnessC.GetUserByUserEmail( LoginEmail );

            if ( user != null )
            {
                if(LoginPassword == null)
                {
                    MessageBox.Show("Please fill the password field.");
                    return;
                }
                string hashedstrpassword = LoginPassword.GetHashCode().ToString();

                if (user.Password.Equals(hashedstrpassword) /* TODO: Andi */ )
                {
                    LoggedInUser = user;
                    LoginCommandExecute();
                }

                else
                {
                    MessageBox.Show("Wrong password!");
                }
                
            }
            else
            {
                MessageBox.Show("Wrong email!");
            }
        }


        public void LoginCommandExecute()
        {
            // Refresh Home's Buttons Visibility:
            HomeViewModel.Instance.RefreshButtonsVisibility();

            ShowHomePage();
        }

        public User LoggedInUser
        {
            get { return loggedInUser; }
            set
            {
                loggedInUser = value;
                RaisePropertyChanged();
            }
        }


        public string LoginEmail
        {
            get { return loginEmail; }
            set
            {
                loginEmail = value;
                RaisePropertyChanged();
            }
        }


        public string LoginPassword
        {
            get { return loginPassword; }
            set
            {
                loginPassword = value;
                RaisePropertyChanged();
            }
        }


        //
        // LOGOUT:
        //

        public void LogoutCommandCanExecute()
        {
            if( true )
            {
                LogoutCommandExecute();
            }
        }

        public void LogoutCommandExecute()
        {

            /* TODO: Andi - Logging out methods */
            LoginEmail = null;
            LoginPassword = null;
            LoggedInUser = null;
            
            // Close opened tabs
            CloseAllTabs();          

            // Go Back to Login Page
            ShowLoginPage();

        }

        //
        // HOME:
        //

        public void CloseCommandExecute()
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to exit application?", "Exit", MessageBoxButtons.YesNo);
            if ( dialogResult == DialogResult.Yes )
            {
                ViewService.CloseDialog(this);
            }
            else if ( dialogResult == DialogResult.No )
            {
                //do nothing
            }
            
        }

        public void CloseAllTabs()
        {
            SelectedContent = this.Contents.FirstOrDefault();
            foreach(var c in this.Contents.ToList() )
            {
                if ( c.ShowCloseButton )
                {
                    this.Contents.Remove(c);
                }
            }
        }

        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<IMainContent> Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
                RaisePropertyChanged();
            }
        }

        public IMainContent SelectedContent
        {
            get
            {
                return _selectedContent;
            }
            set
            {
                PrevSelectedContent = _selectedContent;
                _selectedContent = value;
                RaisePropertyChanged();
            }
        }

        public IMainContent PrevSelectedContent
        {
            get
            {
                return _prevSelectedContent;
            }
            set
            {
                _prevSelectedContent = value;
                RaisePropertyChanged();
            }
        }

        private void GenerateContents()
        {
            Contents = new ObservableCollection<IMainContent>();

            IMainContent homeViewModel = new HomeViewModel();
            //IMainContent addLanseTypeViewModel = new AddLanseTypeViewModel();
            //IMainContent addLanseViewModel = new AddLanseViewModel();
            //IMainContent addUserViewMode = new AddUserViewModel();

            Contents.Add(homeViewModel);
            //Contents.Add(addLanseTypeViewModel);
            //Contents.Add(addLanseViewModel);
            //Contents.Add(addUserViewMode);

            SelectedContent = Contents.First();
        }

        public User UserInfoToEditUserHelper
        {
            get
            {
                return _userInfoToEditUserHelper;
            }
            set
            {
                _userInfoToEditUserHelper = value;
                RaisePropertyChanged();
            }
        }


        //private void OpenTabExecute()
        //{
        //    MainWindowViewModel.Instance.Set
        //}

        public void SetNewTab(IMainContent content  )
        {
            
            IMainContent mainContent = null;

            if ( content is IEntryManagerContent )
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is IEntryManagerContent);
                // Set Tab:
                EntryManagerViewModel vm = new EntryManagerViewModel();
                SetTab(mainContent, vm);

            } else if ( content is IUserManagerContent )
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is IUserManagerContent);
                // Set Tab:
                UserManagerViewModel vm = new UserManagerViewModel();
                SetTab(mainContent, vm);

            } else if ( content is ILanseManagerContent )
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is ILanseManagerContent);
                // Set Tab:
                LanseManagerViewModel vm = new LanseManagerViewModel();
                SetTab(mainContent, vm);

            } else if ( content is ILanseTypeManagerContent )
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is ILanseTypeManagerContent);
                // Set Tab:
                LanseTypeManagerViewModel vm = new LanseTypeManagerViewModel();
                SetTab(mainContent, vm);

            } else if ( content is IStatManagerContent )
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is IStatManagerContent);
                // Set Tab:
                StatManagerViewModel vm = new StatManagerViewModel();
                SetTab(mainContent, vm);

            }
            else if ( content is IUserInfoContent )
            {
                // Test if tab is already opened: (Only if the user is the same too)
                mainContent = this.Contents.FirstOrDefault(c => c is IUserInfoContent && (c as IUserInfoContent).Header.Equals(content.Header));
                // Set Tab:
                UserInfoViewModel vm = new UserInfoViewModel();
                SetTab(mainContent, vm);

            }
            else if (content is IAddUserContent)
            {
                // Test if tab is already opened:
                mainContent = this.Contents.FirstOrDefault(c => c is IAddUserContent);
                // Set Tab:
                AddUserViewModel vm = new AddUserViewModel();
                SetTab(mainContent, vm);

            }
            else if ( content is IEditUserContent )
            {
                // Test if tab is already opened: (Only if the user is the same too)
                mainContent = this.Contents.FirstOrDefault(c => c is IEditUserContent && (c as IEditUserContent).Header.Equals(content.Header));
                // Set Tab:
                EditUserViewModel vm = new EditUserViewModel();
                SetTab(mainContent, vm);
            }
       

        }

        public void SetTab( IMainContent mainContent, IMainContent viewModel )
        {
            if ( mainContent == null )
            {
                this.Contents.Add(viewModel);
                this.SelectedContent = this.Contents.LastOrDefault();
            }
            else
            {
                // show already opened tab:
                this.SelectedContent = mainContent;
            }
        }

        //
        // Close Tab:
        //

        public void CloseTabItem(IMainContent content)
        {
            if ( content != null )
            {
                // before closing, open prev. tab
                this.SelectedContent = PrevSelectedContent; //this.Contents.FirstOrDefault();

                // close this tab
                this.Contents.Remove(content);
            }
        }


        /* TODO: DELETE ME*/
        public RelayCommand DeleteMe1Command { get; private set; }
        public RelayCommand DeleteMe2Command { get; private set; }
        public RelayCommand DeleteMe3Command { get; private set; }
        public void DeleteMe1Execute()
        {
            LoginEmail = "mj@mail";
            LoginPassword = "mj";
        }
        public void DeleteMe2Execute()
        {
            LoginEmail = "andi@mail";
            LoginPassword = "andi";
        }
        public void DeleteMe3Execute()
        {
            LoginEmail = "rec@mail";
            LoginPassword = "rec";
        }

    }
}