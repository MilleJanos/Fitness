using Common.Contents;
using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class HomeViewModel : IHomeContent
    {
        public RelayCommand EntryManager { get; private set; }
        public RelayCommand UserManager { get; private set; }
        public RelayCommand LanseManager { get; private set; }
        public RelayCommand LanseTypeManager { get; private set; }

  
        public HomeViewModel()
        {
            this.EntryManager = new RelayCommand(this.EntryManagerExecute);
            this.UserManager = new RelayCommand(this.UserManagerExecute);
            this.LanseManager = new RelayCommand(this.LanseManagerExecute);
            this.LanseTypeManager = new RelayCommand(this.LanseTypeManagerCanExecute);
        } 


        // Implement interface members:
        public string Header => "Home";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => false;


        // Commands:
        private void EntryManagerExecute()
        {
            // TODO: Open Add entry page to Tab
        }

        private void UserManagerExecute()
        {
            // TODO: Open Add user page to Tab
        }

        private void LanseManagerExecute()
        {
            // TODO: Open Add lanse page to Tab
        }

        private void LanseTypeManagerCanExecute()
        {
            if( true /* TODO: Jancsi - Is admin ?*/)
            {
                LanseTypeManagerExecute();
            }
        }

        private void LanseTypeManagerExecute()
        {
            // TODO: Open Add lanse_type page to Tab
        }


    }
}
