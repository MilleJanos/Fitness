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
        public RelayCommand AddLanseCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }
       

        // Filter

        private string _id;
        private string _typeId;
        private string _userId;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _lowprice;
        private string _highprice;
        private bool _showInactives;
        private string _filter_IdStr;
        private string _filter_TypeId;
        private string _filter_UserId;
        private string _filter_low_Price;
        private string _filter_high_Price;
        private string _filter_SelectedActive;
        private List<string> _filter_Active;
        private string _remainingTimes;
        private User _user;


   





        private string _priceTitle;

        public string PriceTitle
        {
            get { return _priceTitle; }
            set { _priceTitle = value;
                RaisePropertyChanged();
            }
        }



        public LanseManagerViewModel()
        {
            this.Lanses = GetAllLanses();
             PriceTitle = "Price <";

            Filter_Active = new List<string>();
            Filter_Active.Add("All");
            Filter_Active.Add("True");
            Filter_Active.Add("False");

            this.Filter_SelectedActive = Filter_Active.First() ;


            // Users = Admin_Role_Filter(Users);       // Do not show admin & reteptionist & deleted registrations, only if admin is logged in

            this._showInactives = true;

           
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
            MainWindowViewModel.Instance.SetNewTab(new AddLanseViewModel());
        }

        public void RefreshExecute()
        {
           RecalculateFilters();
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
        // Filters:



        public List<Lanse> Id_Filter(string strId, List<Lanse> lanses)
        {
            if (strId != "" && strId != null)
            {
                try
                {
                    int id = Int32.Parse(strId);
                    return lanses.Where(u => u.Id == id).ToList();
                }
                catch
                {
                    return lanses;
                }
            }
            return lanses;
        }

      

        public List<Lanse> Type_Id_Filter(string Type_Id, List<Lanse> lanses)
        {

            if (Type_Id != "" && Type_Id != null)
            {
                try
                {
                    int id = Int32.Parse(Type_Id);
                    return lanses.Where(u => u.TypeId == id).ToList();
                }
                catch
                {
                    return lanses;
                }
            }
            return lanses;
        }

        public List<Lanse> User_Id_Filter(string User_Is, List<Lanse> lanses)
        {

            if (User_Is != "" && User_Is != null)
            {
                try
                {
                    int id = Int32.Parse(User_Is);
                    return lanses.Where(u => u.UserId == id).ToList();
                }
                catch
                {
                    return lanses;
                }
            }
            return lanses;
        }

        public List<Lanse> Price_GreatherThan_Filter(string price, List<Lanse> lanses)
        {

            if (price != "" && price != null)
            {
                try
                {
                    int pricee = Int32.Parse(price);
                    return lanses.Where(u => u.Price >= pricee).ToList();
                }
                catch
                {
                    return lanses;
                }
            }
            return lanses;
        }

        public List<Lanse> Price_LessThan_Filter(string price, List<Lanse> lanses)
        {

            if (price != "" && price != null)
            {
                try
                {
                    int pricee = Int32.Parse(price);
                    return lanses.Where(u => u.Price <= pricee).ToList();
                }
                catch
                {
                    return lanses;
                }
            }
            return lanses;
        }
        // Filter Properties:

        public void RecalculateFilters()
         {
             EmptyDataGridMessageVisibility = false;
            Lanses = GetAllLanses();

            Lanses = Id_Filter(Filter_IdStr, Lanses);
            Lanses = Type_Id_Filter(Filter_TypeId, Lanses);
            Lanses = User_Id_Filter(Filter_UserId, Lanses);
            Lanses = Price_GreatherThan_Filter(Filter_HighPrice, Lanses);
            Lanses = Activ_Filter(Filter_SelectedActive, Lanses);
            Lanses = Price_LessThan_Filter(Filter_LowPrice, Lanses);
           

             if (Lanses.Count == 0)
             {
                 EmptyDataGridMessageVisibility = true;
             }
         }

        private List<Lanse> Activ_Filter(string filter_SelectedActive, List<Lanse> lanses)
        {
            if (Filter_SelectedActive != null && !Filter_SelectedActive.Equals("All"))
            {
                bool b = filter_SelectedActive.Equals("True")
                  ? true
                  : false;

                return lanses.Where(u => u.Active == b).ToList();
            }

            return lanses;
        }

        public string Filter_SelectedActive
        {
            get
            {
                return _filter_SelectedActive;
            }
            set
            {
                _filter_SelectedActive = value;
                RaisePropertyChanged();
                RecalculateFilters();
            }
        }

        public List<string> Filter_Active
        {
            get { return _filter_Active; }
            set
            {
                _filter_Active = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }


        public string Filter_LowPrice
        {
            get { return _filter_low_Price; }
            set {
                _filter_low_Price = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }

        public string Filter_HighPrice
        {
            get { return _filter_high_Price; }
            set
            {
                _filter_high_Price = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }
        public string Filter_UserId
        {
            get { return _filter_UserId; }
            set { _filter_UserId = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }

        public string Filter_TypeId
        {
            get { return _filter_TypeId; }
            set
            {
                _filter_TypeId = value;
                RecalculateFilters();
                RaisePropertyChanged();
            }
        }
        public string Filter_IdStr
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

        // Properties:


        public string RemainingTimes
        {
            get { return _remainingTimes; }
            set
            {
                _remainingTimes = value;
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
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged();
            }
        }
        public string LowPrice
        {
            get { return _lowprice; }
            set
            {
                _lowprice = value;
                RaisePropertyChanged();
            }
        }

        public string HighPrice
        {
            get { return _highprice; }
            set
            {
                _highprice = value;
                RaisePropertyChanged();
            }
        }

        public string TypeId
        {
            get { return _typeId; }
            set
            {
                _typeId = value;
                RaisePropertyChanged();
            }
        }

        public string Id
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
                 RecalculateFilters();
            }
        }
    }

}