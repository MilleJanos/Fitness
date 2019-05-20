using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel.UserControls
{
    public class AddLanseViewModel : ViewModelBase, IAddLanseContent
    {
       
        private Lanse _currentLanse= null;

        private bool _adminVisibility;
        private string _id;
        private LanseType _type;
        private string _typeId;
        private User _user;
        private string _userId;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _remaingTimes;
        private string _price;

        public Lanse CurrentLanse
        {
            get { return _currentLanse; }
            set
            {
                _currentLanse = value;
                RaisePropertyChanged();
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }
       /* private List<string> _active;

        public List<string> Active
        {
            get { return _active; }
            set { _active = value;
                RaisePropertyChanged();
            }
        }*/


        public string RemaingTimes
        {
            get { return _remaingTimes; }
            set { _remaingTimes = value;
                RaisePropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value;
                RaisePropertyChanged();

            }
        }


        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value;
                RaisePropertyChanged();
            }
        }


        public string UserId
        {
            get { return _userId; }
            set { _userId = value;
                RaisePropertyChanged();
            }
        }


        public User User
        {
            get { return _user; }
            set { _user = value;
                RaisePropertyChanged();
            }
        }


        public string TypeId
        {
            get { return _typeId; }
            set { _typeId = value;
                RaisePropertyChanged();
            }
        }


        public string Id
        {
            get { return _id; }
            set { _id = value;
                RaisePropertyChanged();
            }
        }

       
        public LanseType Type
        {
            get { return _type; }
            set { _type = value;
                RaisePropertyChanged();
            }
        }





        public RelayCommand CancelCommand { get; private set; }
            public RelayCommand SaveCommand { get; private set; }

            public AddLanseViewModel()
            {
                // Get Lanse:
                CurrentLanse = new Lanse();

                AdminVisibility = MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin")
                    ? true
                    : false;
                CancelCommand = new RelayCommand(CancelExecute);
                SaveCommand = new RelayCommand(SaveCanExecute);
          
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;

            }


            public string Header => "Add lanse: ";

            public RelayCommand CloseTabItemCommand { get; set; }

            public bool ShowCloseButton => true;

           

          

            private void CancelExecute()
            {
                if (MessageBox.Show("Candel editting?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
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
                if (ValidateInputs())
                {
                    SaveExecute();
                    MessageBox.Show("Saved.");
                    CloseTabItemExecute();
                }
            }

            private void SaveExecute()
       
        {
            Lanse lanse = new Lanse();
       
            lanse.Type = Type;
            lanse.TypeId= Int32.Parse(TypeId);
            lanse.User = User;
            lanse.UserId = Int32.Parse(UserId);
            lanse.StartDate = StartDate;
            lanse.EndDate = EndDate;
            lanse.RemainingTimes =Int32.Parse(RemaingTimes);
            lanse.Price =Int32.Parse(Price);
            lanse.Active = true;
           

              
            lanse.Id = Fitness.Logic.Data.FitnessC.GetLanses().ToList().Count();

                // Copy remained fields:
               
                // Update in DB
                Fitness.Logic.Data.FitnessC.InsertLanse(lanse);
            }



            private bool ValidateInputs()
            {


             
                if (TypeId.Equals(""))
                {
                    MessageBox.Show("TypeId must be filled!");
                    return false;
                }
               
             
                if (UserId.Equals(""))
                {
                    MessageBox.Show("UserId must be filled!");
                    return false;
                }
                if (RemaingTimes.Equals(""))
                {
                    MessageBox.Show("RemaingTimes  must be filled!");
                    return false;
                }
                if (Price.Equals(""))
                {
                    MessageBox.Show("Price  must be filled!");
                    return false;
                }
            return true;
            }



        // Property




        public bool AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }
            set
            {
                _adminVisibility = value;
                RaisePropertyChanged();
            }
        }


        public void CloseTabItemExecute()
            {
                MainWindowViewModel.Instance.CloseTabItem(this);
            }
        }
}
