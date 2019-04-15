using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {


            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
        }

        public RelayCommand CloseCommand { get; private set; }

        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }
    }
}
