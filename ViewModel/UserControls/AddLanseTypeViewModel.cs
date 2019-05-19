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
    public class AddLanseTypeViewModel : ViewModelBase, IAddLanseTypeContent
    {

        private string _name;
        private string _activeDays;
        private int _activePerDay;
        private int _activeHoursPerDay;
        private int _price;
        private string _description;
        private bool _active;

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }


        public AddLanseTypeViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);


            CancelCommand = new RelayCommand(CancelExecute);
            SaveCommand = new RelayCommand(SaveCanExecute);
        }



   
        public string Header => "Create New Lance Type";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

     


        private void CancelExecute()
        {
            if ( MessageBox.Show("Candel editting?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No )
            {
                //do nothing
            }
            else
            {
                CloseTabItemExecute();
            }
        }

        private void SaveCanExecute()
        {
            if ( ValidateInputs() )
            {
                SaveExecute();
                MessageBox.Show("Saved.");
                CloseTabItemExecute();
            }
        }

        private void SaveExecute()
        {
            LanseType lt = new LanseType();

            lt.Id = Fitness.Logic.Data.FitnessC.GetLanseTypes().Count();
            lt.Name = Name;
            lt.ActiveDays = ActiveDays;
            lt.ActivePerDay = ActivePerDay;
            lt.ActiveHoursPerDay = ActiveHoursPerDay;
            lt.Price = Price;
            lt.Description = Description;
            lt.Active = Active;


            // Update in DB
            Fitness.Logic.Data.FitnessC.InsertLanseType(lt);
        }



        private bool ValidateInputs()
        {


            if ( Name.Equals("") )
            {
                MessageBox.Show("Name must be filled!");
                return false;
            }
            if ( ActiveDays.Equals("") && ActiveDays.Length != 7 )
            {
                MessageBox.Show("Wrong Active Days!");
                return false;
            }
            if ( ActivePerDay >= 0 )
            {
                MessageBox.Show("Wrong active / day!");
                return false;
            }
            if ( ActiveHoursPerDay >= 0 )
            {
                MessageBox.Show("Wrong active hours / day!");
                return false;
            }
            if ( Price >= 0 )
            {
                MessageBox.Show("Wrong price!");
                return false;
            }
            return true;
        }


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }


        // Properties:

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        public string ActiveDays
        {
            get { return _activeDays; }
            set { _activeDays = value; RaisePropertyChanged();}
        }

        public int ActivePerDay
        {
            get { return _activePerDay; }
            set { _activePerDay = value; RaisePropertyChanged();}
        }

        public int ActiveHoursPerDay
        {
            get { return _activeHoursPerDay; }
            set { _activeHoursPerDay = value; RaisePropertyChanged();}
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged();}
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged();}
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged();}
        }

    }
}
