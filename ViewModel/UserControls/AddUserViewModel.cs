using Fitness.Common.Contents;
using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.UserControls
{
    public class AddUserViewModel : ViewModelBase, IAddUserContent
    {
        public string Header => "Create New User";

        public RelayCommand CloseTabItemCommand { get; set; }

        public bool ShowCloseButton => true;
    }
}
