using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class ListOfObjectsViewModel : ViewModelBase
    {

        public ListOfObjectsViewModel(LocalContext localContext) => LocalContext = localContext;
        public LocalContext LocalContext { get; set; }
        public List<InventoryObject> InventoryObjectMobiles
        {
            get
            {
                if (LocalContext.InventoryObjectMobiles != null) { return LocalContext.InventoryObjectMobiles; }
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
            LocalContext.SetCurrentInventoryObject((int)o);

            await Shell.Current.Navigation.PushAsync(ViewService.SelectTypeWork);
        }
        public bool CanExecuteSelectObjectClick(object parameter)
        {
            return true;
        }

        public void Update() => OnPropertyChanged("InventoryObjectMobiles");
    }
}
