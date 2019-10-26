using Revisor.Data;
using Revisor.Interfaces;
using Revisor.Service;
using Revisor.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Revisor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var con = DependencyService.Get<IPath>().GetDatabasePath("atica4.db");
            var AppContext = new AppDataContext(con);

            LocalContextService localContextService = new LocalContextService(AppContext);
            ViewModelService.MainPageViewModel = new MainViewModel();
            ViewModelService.ListOfObjectsViewModel = new ListOfObjectsViewModel(localContextService);
            ViewModelService.SelectTypeOfWorkViewModel = new SelectTypeOfWorkViewModel();
            ViewModelService.ListOfInstrumentHoldsListViewModel = new ListOfInstrumentHoldsListViewModel(localContextService);

            ViewModelService.ListOfMaterialHoldsListViewModel = new ListOfMaterialHoldsListViewModel(localContextService);








            // MainPage =// new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
