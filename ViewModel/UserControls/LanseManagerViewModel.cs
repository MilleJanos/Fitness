using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.Model;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class LanseManagerViewModel : ViewModelBase, ILanseManagerContent
    {
        public static Lanse LastSelectedLanse = null;

        private List<Lanse> _lanses;

        private Lanse _selectedLanse;
        private bool _adminVisibility = false;
        private bool _EmptyDataGridMessageVisibility = false;
        public RelayCommand ItemClickCommand { get; private set; }
        public RelayCommand ClearBirthDateCommand { get; private set; }
        public RelayCommand AddLanseCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }

        // Filter

        private int _id;
        private int _typeId;
        private int _userId;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _active;
        private int _price;
        private bool _showInactives;
        private int _filter_IdStr;
        private int _filter_TypeId;

     

     






        public bool Active
        {
            get { return _active; }
            set { _active = value;
                RaisePropertyChanged();
            }
        }




        public LanseManagerViewModel()
        {
            this.Lanses = GetAllLanses();


           // Users = Admin_Role_Filter(Users);       // Do not show admin & reteptionist & deleted registrations, only if admin is logged in

            this._showInactives = true;

            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.AddLanseCommand = new RelayCommand(this.AddLanseExecute);
            this.RefreshCommand = new RelayCommand(this.RefreshExecute);

            if (MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin"))
            {
                AdminVisibility = true;
            }
            else
            {
                AdminVisibility = false;
            }
        }


        public string Header => "Lanse Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        // Commands / CanExecutes / Executes:

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        private List<Lanse> GetAllLanses()
        {
            return Fitness.Logic.Data.FitnessC.GetLanses();
        }


        public void ItemClickExecute()
        {
            LastSelectedLanse = _selectedLanse;
            MainWindowViewModel.Instance.SetNewTab(new UserInfoViewModel());
        }




        public void AddLanseExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new AddUserViewModel());
        }

        public void RefreshExecute()
        {
           // RecalculateFilters();
        }

        // Filters:


        public List<Lanse> Id_Filter(int Id, List<Lanse> lanses)
        {
            if (Id > 0)
            {

                return lanses.Where(u => u.Id == Id).ToList();

            }
            return lanses;
        }

        public bool EmptyDataGridMessageVisibility
        {
            get
            {
                return _EmptyDataGridMessageVisibility;
            }
            set
            {
                _EmptyDataGridMessageVisibility = value;
                RaisePropertyChanged();
            }
        }

        public List<Lanse> Type_Id_Filter(int Type_Id, List<Lanse> lanses)
        {

            if (Type_Id > 0)
            {
               
                    return lanses.Where(u => u.TypeId == Type_Id ).ToList();
              
            }
            return lanses;
        }
        /* public List<User> FirstName_Filter(string firstname, List<User> users)
         {
             if (firstname != "" && firstname != null)
                 return users.Where(u => u.FirstName.ToLower().Contains(firstname.ToLower())).ToList();
             return users;
         }

         public List<User> LastName_Filter(string lastname, List<User> users)
         {
             if (lastname != "" && lastname != null)
                 return users.Where(u => u.LastName.ToLower().Contains(lastname.ToLower())).ToList();
             return users;
         }

         public List<User> Email_Filter(string email, List<User> users)
         {
             if (email != "" && email != null)
                 return users.Where(u => u.Email.ToLower().Contains(email.ToLower())).ToList();
             return users;
         }

         public List<User> PhoneNumber_Filter(string phonenumber, List<User> users)
         {
             if (phonenumber != "" && phonenumber != null)
                 return users.Where(u => u.PhoneNumber.Contains(phonenumber)).ToList();
             return users;
         }

         public List<User> Barcode_Filter(string barcode, List<User> users)
         {
             if (barcode != "" && barcode != null)
                 return users.Where(u => u.Barcode.Contains(barcode)).ToList();
             return users;
         }

         public List<User> Role_Filter(string rolestringid, List<User> users)
         {
             if (!rolestringid.Equals("all"))
                 return users.Where(u => u.Role == rolestringid).ToList();
             return users;
         }

         public List<User> BirthDate_Filter(DateTime datetime, List<User> users)
         {
             if (datetime.Equals(System.DateTime.Now))      // TODO: Change this logic (now == filter off) (1)
                 return users.Where(u => u.BirthDate.Equals(datetime)).ToList();
             return users;
         }

         public List<User> RegistrationDate_Filter(DateTime datetime, List<User> users)
         {
             if (datetime.Equals(System.DateTime.Now))     // TODO: Change this logic (now == filter off) (2)
                 return users.Where(u => u.RegistrationDate.Equals(datetime)).ToList();
             return users;
         }

         public List<User> ShowInactive_Filter(bool showactive, List<User> users)
         {
             if (!showactive)
                 return users.Where(u => u.Active == true).ToList();
             return users;
         }


         // Do not show admin & reteptionist registrations, only if admin is logged in
         public List<User> Admin_Role_Filter(List<User> users)
         {
             if (MainWindowViewModel.Instance.LoggedInUser.Role.Equals("admin"))
             {
                 return users;
             }
             List<User> temp = users.Where(u => u.Role.Equals("client")).ToList();
             return temp.Where(u => u.Active).ToList();
         }
         */

        // Filter Properties:

         public void RecalculateFilters()
         {
             EmptyDataGridMessageVisibility = false;
            Lanses = GetAllLanses();

            Lanses = Id_Filter(Filter_IdStr, Lanses);
            Lanses = Type_Id_Filter(Filter_TypeId, Lanses);
           

             if (Lanses.Count == 0)
             {
                 EmptyDataGridMessageVisibility = true;
             }
         }


        // Properties:

       
        public int Filter_TypeId
        {
            get { return _filter_TypeId; }
            set
            {
                _filter_TypeId = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }
        public int Filter_IdStr
        {
            get
            {
                return _filter_IdStr;
            }
            set
            {
                _filter_IdStr = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                RaisePropertyChanged();
            }
        }
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged();
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }

        public int TypeId
        {
            get { return _typeId; }
            set
            {
                _typeId = value;
                RaisePropertyChanged();
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }
        public bool AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }
            private set
            {
                _adminVisibility = value;
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

        public Lanse SelectedLance
        {
            get
            {
                return _selectedLanse;
            }
            set
            {
                _selectedLanse = value;
                RaisePropertyChanged();
            }
        }




        public bool ShowInactives
        {
            get
            {
                return _showInactives;
            }
            set
            {
                _showInactives = value;
                RaisePropertyChanged();
                //   RecalculateFilters();
            }
        }
    }

}