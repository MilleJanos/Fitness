using Fitness.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Common.Contents
{
    public interface IMainContent
    {
        string Header { get; }

        RelayCommand CloseTabItemCommand { get; set; }

        bool ShowCloseButton { get; }
    }
}
