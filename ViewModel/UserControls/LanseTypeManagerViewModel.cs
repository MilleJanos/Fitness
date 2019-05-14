using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class LanseTypeManagerViewModel : ViewModelBase, ILanseTypeManagerContent
    {
        public string Header => "Lanse Type Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;
    }
}
