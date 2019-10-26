using InventoryModels;
using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class ListOfObjectsViewModel : ViewModelBase
    {

        public ListOfObjectsViewModel(LocalContextService localContext) => LocalContext = localContext;
        public LocalContextService LocalContext { get; set; }
        public List<InventoryObject> InventoryObjectMobiles
        {
            get
            {
                if (LocalContext.InventoryObjects != null) { return LocalContext.InventoryObjects; }
                return new List<InventoryObject>();
            }
        }


        private RelayCommand selectObjectClick;

        public RelayCommand SelectObjectClick

        {
            get
            {
                if (selectObjectClick == null)
                {
                    selectObjectClick = new RelayCommand(ExecuteSelectObjectClick, CanExecuteSelectObjectClick);
                }
                return selectObjectClick;
            }
        }


        public async void ExecuteSelectObjectClick(object parameter)
        {
            var o = parameter;
           // LocalContext.SetCurrentInventoryObject((int)o);

           // await Shell.Current.Navigation.PushAsync(ViewService.SelectTypeWork);
        }
        public bool CanExecuteSelectObjectClick(object parameter)
        {
            return true;
        }

        public void Update() => OnPropertyChanged("InventoryObjectMobiles");
    }
}
