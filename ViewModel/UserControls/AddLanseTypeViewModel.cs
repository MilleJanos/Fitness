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

        private string _name = "";
        private string _activeDays = "";
        private string _activePerDay;
        private string _activeHoursPerDay;
        private string _activeTimes;
        private string _price;
        private string _description = "";
        private List<string> _active;
        private string _selectedActive;


        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }


        public AddLanseTypeViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);


            CancelCommand = new RelayCommand(CancelExecute);
            SaveCommand = new RelayCommand(SaveCanExecute);

            Active = new List<String>();
            Active.Add("True");
            Active.Add("False");
            SelectedActive = Active.First();

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
            lt.ActivePerDay = Int32.Parse(ActivePerDay);
            lt.ActiveHoursPerDay = Int32.Parse(ActiveHoursPerDay);
            lt.ActiveTimes = Int32.Parse(ActiveTimes);
            lt.Price = Int32.Parse(Price);
            lt.Description = Description;
            lt.Active = SelectedActive.Equals("True")
                ? true 
                : false;


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

            if ( ! ActivePerDay.Equals("") && ActiveDays.Length == 7 )
            {
                try
                {
                    int num = Int32.Parse(ActivePerDay);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong active / day! Numbers required.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong active / day!");
                return false;
            }

            if ( ! ActiveHoursPerDay.Equals("") )
            {
                try
                {
                    int num = Int32.Parse(ActiveHoursPerDay);
                }
                catch ( Exception )
                {
                    MessageBox.Show("Wrong active hours / day! Numbers required.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong active hours / day!");
                return false;
            }

            if ( !ActiveTimes.Equals("") )
            {
                try
                {
                    int num = Int32.Parse(ActiveTimes);
                }
                catch ( Exception )
                {
                    MessageBox.Show("Wrong active times! Numbers required.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong active hours / day!");
                return false;
            }

            if ( ! Price.Equals("") )
            {
                try
                {
                    int num = Int32.Parse(Price);
                }
                catch ( Exception )
                {
                    MessageBox.Show("Wrong price! Numbers required.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong price");
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

        public string ActivePerDay
        {
            get { return _activePerDay; }
            set { _activePerDay = value; RaisePropertyChanged();}
        }

        public string ActiveHoursPerDay
        {
            get { return _activeHoursPerDay; }
            set { _activeHoursPerDay = value; RaisePropertyChanged();}
        }

        public string ActiveTimes
        {
            get { return _activeTimes; }
            set { _activeTimes = value; RaisePropertyChanged(); }
        }

        public string Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged();}
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged();}
        }

        public List<string> Active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged();}
        }

        public string SelectedActive
        {
            get { return _selectedActive; }
            set { _selectedActive = value; RaisePropertyChanged(); }
        }

    }
}
