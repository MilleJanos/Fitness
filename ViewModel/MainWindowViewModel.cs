using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.UserControls;

namespace Fitness.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Common:
        public static MainWindowViewModel Instance { get; private set; }

        private bool _loginVisibility;
        private bool _homeVisibility;

        // Login:
        public RelayCommand LoginCommand { get; private set; }

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
            if ( true /* TODO: Andi */ ) 
            {
                LoginCommandExecute();
            }
        }

        public void LoginCommandExecute()
        {
            ShowHomePage();
        }

        //
        // LOGOUT:
        //

        public void LogoutCommandCanExecute()
        {
            if( true /* TODO: Jancsi */)
            {
                LogoutCommandExecute();
            }
        }

        public void LogoutCommandExecute()
        {

            /* TODO: Jancsi - Logging out methods */

            ShowLoginPage();

        }

        //
        // HOME:
        //


        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
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

    }
}