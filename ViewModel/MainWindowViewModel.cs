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
        private bool _loginVisibility;
        private bool _homeVisibility;


        

        public MainWindowViewModel()
        {
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);

            LoginVisibility = true;
            HomeVisibility = false;

            GenerateContents();
        }

        //
        // Common: Switch
        //

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

        // TODO

        //
        // HOME:
        //

        // TODO

        //
        // DEBUG:
        //
        private string _pageTitle = "MainPage";
        private ObservableCollection<IMainContent> _contents;
        private IMainContent _selectedContent;

        public RelayCommand CloseCommand { get; private set; }


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

            IMainContent addLanseTypeViewModel = new AddLanseTypeViewModel();
            IMainContent addLanseViewModel = new AddLanseViewModel();
            IMainContent addUserViewMode = new AddUserViewModel();

            Contents.Add(addLanseTypeViewModel);
            Contents.Add(addLanseViewModel);
            Contents.Add(addUserViewMode);

            SelectedContent = Contents.First();
        }


    }
}