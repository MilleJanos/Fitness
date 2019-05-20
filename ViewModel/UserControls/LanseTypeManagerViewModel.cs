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
    public class LanseTypeManagerViewModel : ViewModelBase, ILanseTypeManagerContent
    {

        private List<LanseType> _lanseTypes;
        private LanseType _selectedLanseType;
        
        private string _filter_Id;
        private string _filter_Name;
        private string _filter_Description;
        private List<string> _filter_Active;
        private string _filter_SelectedActive;

        private bool _emptyDataGridMessageVisibility;

        public RelayCommand AddNewCommand { get; private set; }
        public RelayCommand ItemClickCommand { get; private set; }

        public LanseTypeManagerViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);
            this.AddNewCommand = new RelayCommand(this.OpenAddNewExecute);
            this.ItemClickCommand = new RelayCommand(this.ItemClickExecute);

            Filter_Active = new List<string>();
            Filter_Active.Add("All");
            Filter_Active.Add("True");
            Filter_Active.Add("False");
            Filter_SelectedActive = Filter_Active.FirstOrDefault();

        }

        public string Header => "Lanse Type Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;

        // Methods:

        private void ReloadDataGrid()
        {
            LanseTypes = Fitness.Logic.Data.FitnessC.GetLanseTypes().ToList();
        }

        // Filter Properties:

        public void RecalculateFilters()
        {
            EmptyDataGridMessageVisibility = false;
            
            LanseTypes = GetAllLanseTypes();

            LanseTypes = Id_Filter(Filter_Id, LanseTypes);
            LanseTypes = Name_Filter(Filter_Name, LanseTypes);
            LanseTypes = Description_Filter(Filter_Description, LanseTypes);
            LanseTypes = Active_Filter(Filter_SelectedActive, LanseTypes);


            if ( LanseTypes.Count == 0 )
            {
                EmptyDataGridMessageVisibility = true;
            }
        }

        private List<LanseType> Id_Filter(string filter_Id, List<LanseType> lanseTypes)
        {
            if ( filter_Id != "" && filter_Id != null )
                try
                {
                    int id = Int32.Parse(filter_Id);
                    return lanseTypes.Where(u => u.Id == id).ToList();
                }
                catch
                {
                    return lanseTypes;
                }
            return lanseTypes;
        }

        private List<LanseType> Name_Filter(string filter_Name, List<LanseType> lanseTypes)
        {
            if ( filter_Name != "" && filter_Name != null )
                return lanseTypes.Where(lt =>lt.Name.ToLower().Contains(filter_Name.ToLower())).ToList();
            return lanseTypes;
        }

        private List<LanseType> Description_Filter(string filter_Description, List<LanseType> lanseTypes)
        {
            if ( filter_Description != "" && filter_Description != null )
                return lanseTypes.Where(lt => lt.Description.ToLower().Contains(filter_Description.ToLower())).ToList();
            return lanseTypes;
        }
        private List<LanseType> Active_Filter(string filter_Active, List<LanseType> lanseTypes)
        {
            if( filter_Active != null )
            {
                if ( !filter_Active.Equals("All") )
                {
                    if ( filter_Active.Equals("True") )
                    {
                        return lanseTypes.Where(lt => lt.Active).ToList();
                    }

                    if ( filter_Active.Equals("False") )
                    {
                        return lanseTypes.Where(lt => !lt.Active).ToList();
                    }

                }
            }
            return lanseTypes;
        }


        public List<LanseType> GetAllLanseTypes()
        {
            return Fitness.Logic.Data.FitnessC.GetLanseTypes();
        }

        // Executes:

        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }

        public void OpenAddNewExecute()
        {
            MainWindowViewModel.Instance.SetNewTab(new AddLanseTypeViewModel());
        }

        public void ItemClickExecute()
        {
            // do nothing
        }

        //Properties:

        public List<LanseType> LanseTypes
        {
            get
            {
                return _lanseTypes;
            }
            set
            {
                _lanseTypes = value;
                RaisePropertyChanged();
            }
        }

        public LanseType SelectedLanseType
        {
            get
            {
                return _selectedLanseType;
            }
            set
            {
                _selectedLanseType = value;
                RaisePropertyChanged();
            }
        }

        public bool EmptyDataGridMessageVisibility
        {
            get
            {
                return _emptyDataGridMessageVisibility;
            }
            set
            {
                _emptyDataGridMessageVisibility = value;
                RaisePropertyChanged();
            }
        }

        public string Filter_Id
        {
            get { return _filter_Id; }
            set { _filter_Id = value;
                RecalculateFilters();
                RaisePropertyChanged(); }
        }

        public string Filter_Name
        {
            get { return _filter_Name; }
            set { _filter_Name = value;
                RecalculateFilters();
                RaisePropertyChanged(); }
        }

        public string Filter_Description
        {
            get { return _filter_Description; }
            set { _filter_Description = value;
                RecalculateFilters();
                RaisePropertyChanged(); }
        }

        public List<string> Filter_Active
        {
            get { return _filter_Active; }
            set { _filter_Active = value;
                RecalculateFilters();
                RaisePropertyChanged(); }
        }

        public string Filter_SelectedActive
        {
            get { return _filter_SelectedActive; }
            set { _filter_SelectedActive = value;
                RecalculateFilters();
                RaisePropertyChanged(); }
        }

    }
}
