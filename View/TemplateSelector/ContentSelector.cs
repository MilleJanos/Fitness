using Fitness.Common.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace View.TemplateSelector
{
    public class ContentSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            if ( item is IHomeContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("HomeTemplate") as DataTemplate;
            }
            else if ( item is IAddUserContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("AddUserTemplate") as DataTemplate;
            }
            else if ( item is IAddLanseContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("AddLanseTemplate") as DataTemplate;
            }
            else if ( item is IAddLanseTypeContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("AddLanseTypeTemplate") as DataTemplate;
            }
            else
            {
                return null;
            }
                               
        }
    }
}
