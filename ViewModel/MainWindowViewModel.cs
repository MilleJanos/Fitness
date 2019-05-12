using Fitness.Common.Contents;
using Fitness.Common.MVVM;
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

        private string _pageTitle = "MainPage";
        private ObservableCollection<IMainContent> _contents;
        private IMainContent _selectedContent;

        public MainWindowViewModel()
        {
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);

            GenerateContents();
        }


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
