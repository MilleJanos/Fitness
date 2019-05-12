using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class AddLanseViewModel : ViewModelBase, IAddLanseContent
    {
        public string Header => "Create New Lance";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => false;
    }
}
