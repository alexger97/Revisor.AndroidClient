using Revisor.Data;
using Revisor.Interfaces;
using Revisor.Service;
using Revisor.View.Shell;
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
            AppContext.InventoryObjects.Add(new InventoryModels.InventoryObject() { Name = "Первый объект", Holds = new System.Collections.Generic.List<InventoryModels.Hold>() 
            {
            new InventoryModels.Hold(){ Name="Склад инструмента", Type=InventoryModels.TypeOfHold.InstrumentHold},
             new InventoryModels.Hold(){ Name="Склад инструмента", Type=InventoryModels.TypeOfHold.InstrumentHold}
            }
            
            });
            AppContext.SaveChanges();
           LocalContextService localContextService = new LocalContextService(AppContext);
            ViewModelService.MainPageViewModel = new MainViewModel();
            ViewModelService.ListOfObjectsViewModel = new ListOfObjectsViewModel(localContextService);
            ViewModelService.SelectTypeOfWorkViewModel = new SelectTypeOfWorkViewModel();
            ViewModelService.ListOfInstrumentHoldsListViewModel = new ListOfInstrumentHoldsListViewModel(localContextService);
            ViewModelService.ListOfMaterialHoldsListViewModel = new ListOfMaterialHoldsListViewModel(localContextService);
            ViewModelService.OneInstrumnetHoldViewModel = new OneInstrumnetHoldViewModel();
            ViewModelService.OneMaterialHoldViewModel = new OneMaterialHoldViewModel(localContextService);
            ViewModelService.OneMaterialViewModel = new OneMaterialViewModel(localContextService);
            ViewModelService.OneInstrumnetViewModel = new OneInstrumnetViewModel(localContextService);

            ViewService.MainPage = new View.MainPage() { BindingContext = ViewModelService.MainPageViewModel };
            ViewService.LsitOfObjects = new View.LsitOfObjects() { BindingContext = ViewModelService.ListOfObjectsViewModel };
            ViewService.SelectTypeOfWork = new View.SelectTypeOfWork() { BindingContext = ViewModelService.SelectTypeOfWorkViewModel };
            ViewService.ListOfInstrumentHolds = new View.ListOfInstrumentHolds() { BindingContext = ViewModelService.ListOfInstrumentHoldsListViewModel };
            ViewService.ListOfMaterialHolds = new View.ListOfMaterialHolds() { BindingContext = ViewModelService.ListOfMaterialHoldsListViewModel };
            ViewService.OneMaterialHold = new View.OneMaterialHold() { BindingContext = ViewModelService.OneMaterialHoldViewModel };
            ViewService.OneInstrumentHold = new View.OneInstrumentHold() { BindingContext = ViewModelService.OneInstrumnetHoldViewModel };
            ViewService.OneMaterial = new View.OneMaterial() { BindingContext = ViewModelService.OneMaterialViewModel };
            ViewService.OneInstrument = new View.OneInstrument() { BindingContext = ViewModelService.OneInstrumnetViewModel };
            MainPage = new AppShell();







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
