﻿using Fitness.Common.Contents;
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
                _selectedContent = value;
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


    }
}