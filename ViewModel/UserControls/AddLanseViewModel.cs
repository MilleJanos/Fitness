using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using Fitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class AddLanseViewModel : ViewModelBase, IAddLanseContent
    {
        public AddLanseViewModel()
        {
            this.CloseTabItemCommand = new RelayCommand(this.CloseTabItemExecute);

        }

        public string Header => "Create New Lance";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;


        public void CloseTabItemExecute()
        {
            MainWindowViewModel.Instance.CloseTabItem(this);
        }
    }
}
