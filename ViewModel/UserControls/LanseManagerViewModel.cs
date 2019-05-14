using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class LanseManagerViewModel : ViewModelBase, ILanseManagerContent
    {
        public string Header => "Lanse Manager";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;
    }
}
