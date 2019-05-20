﻿using Fitness.Common.Contents;
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
        private bool ComboBoxToTextBlock = false; // To avoid infinite loop
        private bool TextBlockToComboBox = false; //

        private string _enterButtonMargin;
        private string _remainingEntryCounts;
        // For 1 Selected row:
        private int AllTimes;
        private int TimesUsed;
        private int RemainingTimes;

        private List<User> _userPicker;
        private User _selectedUser;
        private List<User> AllUser;
        

        
        public RelayCommand BarcodeScanCommand { get; private set; }
        public RelayCommand ItemClickCommand { get; private set; }
        public RelayCommand EnterButton { get; private set; }
        

        public EntryManagerViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.BarcodeScanCommand = new RelayCommand(this.BarcodeScanCanExecute);
            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.EnterButton = new RelayCommand(this.EnterCanExecute);

            UserPicker = new List<User>();
            AllUser = GetUsers();
            UserPicker.Add( new User { FirstName = "*Not Selected*" } );
            foreach (User u in AllUser )
            {
                UserPicker.Add(u);
            }
            SelectedUser = UserPicker.First();

        }
        
        private List<User> GetUsers()
        {
            return Fitness.Logic.Data.FitnessC.GetUsers();
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
                MessageBox.Show("Enter barcode before scan'");
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
            Lanses = Fitness.Logic.Data.FitnessC.GetLansesByUserId(             CurrentUser.Id           );
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
                if ( SelectedLanse.RemainingTimes > 0 )
                {
                    // TODO add all filters to Entry (Date,Day,Hour)
                    EnterExecute();
                }
                else
                {
                    MessageBox.Show("No available entrance time left.");
                }
            }
            else
            {
                MessageBox.Show("This lanse is inactive");
            }
        }

        private void EnterExecute()
        {

            // Update times left in selected lanse:
            Lanse lanse = new Lanse();

            lanse.Id = SelectedLanse.Id;
            lanse.Type = SelectedLanse.Type;
            lanse.TypeId = SelectedLanse.TypeId;
            lanse.User = SelectedLanse.User;
            lanse.UserId = SelectedLanse.UserId;
            lanse.StartDate = SelectedLanse.StartDate;
            lanse.EndDate = SelectedLanse.EndDate;
            lanse.RemainingTimes = SelectedLanse.RemainingTimes;
            lanse.Active = SelectedLanse.Active;
            lanse.Price = SelectedLanse.Price;

            Fitness.Logic.Data.FitnessC.UpdateLanse(SelectedLanse.Id, lanse);

            // Add new Entry to DB:
            Entry entry = new Entry();

            int entryCount = Fitness.Logic.Data.FitnessC.GetEntryes().ToList().Count();
            Lanse lanse2 = Fitness.Logic.Data.FitnessC.GetLanses().Where(l => l.Id == SelectedLanse.Id ).FirstOrDefault();

            entry.Id = entryCount + 1;
            entry.Lanse = lanse2;
            entry.LanseId = lanse2.Id;
            entry.Date = DateTime.Now;
            entry.ReceptionistId = MainWindowViewModel.Instance.LoggedInUser.Id;

            Fitness.Logic.Data.FitnessC.InsertEntry(entry);

            MessageBox.Show("Entered.");
        }

        private void GenerateEnterButtonAndLocation()
        {
            if(SelectedLanse != null )
            {
                MoveEnterButton();
                AllTimes = Fitness.Logic.Data.FitnessC.GetLanseTypes().Where(lt => lt.Id == SelectedLanse.TypeId).FirstOrDefault().ActiveTimes;
                //List<Lanse> temp_allLanses         = Fitness.Logic.Data.FitnessC.GetLanses();
                //List<Lanse> temp_userLanses        = temp_allLanses.Where(l => l.UserId == SelectedUser.Id).ToList();
                //Lanse       temp_userSelectedLanse = temp_userLanses.Where(l => l.Id == SelectedLanse.Id).FirstOrDefault();
                TimesUsed = SelectedLanse.RemainingTimes;
                RemainingTimes = AllTimes - TimesUsed;
            }
        }


        private void ResetDataGrid()
        {
            Lanses = new List<Lanse>();
            SelectedLanse = null; 
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
                //if( ! _barcodeStr.Equals("") )
                //{
                //    SelectedUser = Fitness.Logic.Data.FitnessC.GetUserByBarcode(_barcodeStr);
                //}
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

                SelectedLanseIndex = Lanses.FindIndex(l => l.Equals(_selectedLanse));
                GenerateEnterButtonAndLocation();
                RemainingEntryCounts = "used: " + TimesUsed + " remained: " + RemainingTimes + " of " + AllTimes; 

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


        public List<User> UserPicker
        {
            get
            {
                return _userPicker;
            }
            set
            {
                _userPicker = value;

                ResetDataGrid();

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
                if( _selectedUser == null || _selectedUser == UserPicker.First() )
                {
                    BarcodeStr = "";
                }
                else
                {
                    BarcodeStr = _selectedUser.Barcode;
                }
                
                RaisePropertyChanged();
            }
        }

        public string RemainingEntryCounts
        {
            get
            {
                return _remainingEntryCounts;
            }
            set
            {
                _remainingEntryCounts = value;
                RaisePropertyChanged();
            }
        }

    }
}
