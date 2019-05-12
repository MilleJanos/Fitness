namespace Fitness
{
    using Fitness.Common.MVVM;
    using Fitness.View;
    using Fitness.ViewModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            //this.InitializeData();
            this.OpenMainWindow();
        }

        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
            ViewService.CloseDialog(mainWindowViewModel);
        }

        //private void InitializeData()
        //{
        //    try

        //    {
        //        DBInitializer dbinit = new DBInitializer();
        //        dbinit.InitializeDatabase(new TMCatalogDB());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
