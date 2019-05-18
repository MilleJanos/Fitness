using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel.UserControls
{
    public class EntryManagerViewModel : ViewModelBase, IEntryManagerContent
    {
        private string _barcodeStr = "";
        private List<Lanse> _lanses;
        private Lanse _selectedLanse;
        private int SelectedLanseIndex;
        private User _currentUser;
        private Boolean _enterButtonVisibility;
        private string _enterButtonMargin;


        public RelayCommand BarcodeScanCommand { get; private set; }
        public RelayCommand ItemClickCommand { get; private set; }
        public RelayCommand EnterButton { get; private set; }
        

        public EntryManagerViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.BarcodeScanCommand = new RelayCommand(this.BarcodeScanCanExecute);
            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.EnterButton = new RelayCommand(this.EnterCanExecute);
        }
        

        public string Header => "Entry Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        // Command's Execute

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        private void BarcodeScanCanExecute()
        {
            if ( ! BarcodeStr.Equals("") )
            {
                BarcodeScanExecute();
            }
            else
            {
                MessageBox.Show("Enter barcode before");
            }
        }

        private void BarcodeScanExecute()
        {
            CurrentUser = Fitness.Logic.Data.FitnessC.GetUserByBarcode( BarcodeStr );
            RefreshInformations();
        }

        private void RefreshInformations()
        {
            // List CurrentUser's Lanses:
            try
            {
            Lanses = Fitness.Logic.Data.FitnessC.GetLansesByUserId(             CurrentUser.Id - 1           );
            }
            catch (Exception)
            {
                Lanses = new List<Lanse>();
                EnterButtonVisibility = false;
                MessageBox.Show("User Not found!");
            }


        }

        private void ItemClickExecute()
        {
            MoveEnterButton();
        }

        private void MoveEnterButton()
        {
            EnterButtonVisibility = true;
            int margin = 26 + 22 * SelectedLanseIndex;
            EnterButtonMargin = "5," + margin + ",5,5";
        }

        private void EnterCanExecute()
        {
            if ( SelectedLanse.Active )
            {
                EnterExecute();
            }
        }

        private void EnterExecute()
        {
            Entry entry = new Entry();

            int entryCount = Fitness.Logic.Data.FitnessC.GetEntryes().ToList().Count();
            Lanse lanse = Fitness.Logic.Data.FitnessC.GetLanses().Where(l => l.Id == SelectedLanse.Id ).FirstOrDefault();

            entry.Id = entryCount + 1;
            entry.Lanse = lanse;
            entry.LanseId = lanse.Id;
            entry.Date = DateTime.Now;
            entry.ReceptionistId = MainWindowViewModel.Instance.LoggedInUser.Id;

            Fitness.Logic.Data.FitnessC.InsertEntry(entry);

            MessageBox.Show("TODO: Entered.");
        }

        // Properties

        public string BarcodeStr
        {
            get
            {
                return _barcodeStr;
            }
            set
            {
                _barcodeStr = value;
                RaisePropertyChanged();
            }
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

        public Lanse SelectedLanse
        {
            get
            {
                return _selectedLanse;
            }
            set
            {
                _selectedLanse = value;
                MoveEnterButton();
                SelectedLanseIndex = Lanses.FindIndex(l => l.Equals(_selectedLanse));
                RaisePropertyChanged();
            }
        }

        public bool EnterButtonVisibility
        {
            get
            {
                return _enterButtonVisibility;
            }
            set
            {
                _enterButtonVisibility = value;
                RaisePropertyChanged();

            }
        }

        public string EnterButtonMargin
        {
            get
            {
                return _enterButtonMargin;
            }
            set
            {
                _enterButtonMargin = value;
                RaisePropertyChanged();
            }
        }

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                RaisePropertyChanged();
            }
        }

    }
}
