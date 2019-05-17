using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewModel.UserControls
{
    public class HomeViewModel : ViewModelBase, IHomeContent
    {
        public RelayCommand EntryManager { get; private set; }
        public RelayCommand UserManager { get; private set; }
        public RelayCommand LanseManager { get; private set; }
        public RelayCommand LanseTypeManager { get; private set; }
        public RelayCommand StatisticsManager { get; private set; }

  
        public HomeViewModel()
        {
            this.EntryManager = new RelayCommand(this.EntryManagerExecute);
            this.UserManager = new RelayCommand(this.UserManagerExecute);
            this.LanseManager = new RelayCommand(this.LanseManagerExecute);
            this.LanseTypeManager = new RelayCommand(this.LanseTypeManagerCanExecute);
            this.StatisticsManager = new RelayCommand(this.StatisticsManagerCanExecute);
        } 


        // Implement interface members:
        public string Header => "Home";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => false;


        // Commands:
        private void EntryManagerExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new EntryManagerViewModel());
        }

        private void UserManagerExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new UserManagerViewModel());
        }

        private void LanseManagerExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new LanseManagerViewModel());
        }

        private void LanseTypeManagerCanExecute()
        {
            if (MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin") /* TODO: Andi - Is admin ?*/)
            {
                LanseTypeManagerExecute();
            }
            else
            {
                MessageBox.Show("Admin right required");
            }
        }

        private void LanseTypeManagerExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new LanseTypeManagerViewModel());
        }

        private void StatisticsManagerCanExecute()
        {
            if (MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin") /* TODO: Andi - Is admin ?*/)
            {
                StatisticsManagerExecute();
            }
            else
            {
                MessageBox.Show("Admin right required");
            }
        }

        private void StatisticsManagerExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new StatManagerViewModel());
        }

    }
}
