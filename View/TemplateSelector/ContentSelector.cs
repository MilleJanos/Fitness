﻿using Fitness.Common.Contents;
using Fitness.Common.Contents.Home;
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
            // HOME:
            else if ( item is IEntryManagerContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("EntryTemplate") as DataTemplate;
            }
            else if ( item is IUserManagerContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("UserManagerTemplate") as DataTemplate;
            }
            else if ( item is ILanseManagerContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("LanseManagerTemplate") as DataTemplate;
            }
            else if ( item is ILanseTypeManagerContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("LanseTypeManagerTemplate") as DataTemplate;
            }
            else if ( item is IStatManagerContent )
            {
                return System.Windows.Application.Current.MainWindow.TryFindResource("StatManagerTemplate") as DataTemplate;
            }
            // MANAGER:
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
