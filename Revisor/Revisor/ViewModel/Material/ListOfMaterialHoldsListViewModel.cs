using Revisor.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class ListOfMaterialHoldsListViewModel : ViewModelBase
    {

        public ListOfMaterialHoldsListViewModel(LocalContext localContext) => LocalContext = localContext;
        public LocalContext LocalContext { get; set; }

        public List<HoldMaterial> HoldMaterials { get { return LocalContext.ListMaterialHolds; } }

        public void Update() => OnPropertyChanged("HoldMaterials");


        private RelayCommand selectHold;

        public RelayCommand SelectHold

        {
            get
            {
                if (selectHold == null)
                {
                    selectHold = new RelayCommand(ExecuteSelectHold, CanExecuteSelectHold);
                }
                return selectHold;
            }
        }


        public async void ExecuteSelectHold(object parameter)
        {

            LocalContext.SetCurrentMaterialHold(((HoldMaterial)((ItemTappedEventArgs)parameter).Item).Id);
            ViewModelService.OneMaterialHoldViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.OneMaterialHold);
        }
        public bool CanExecuteSelectHold(object parameter)
        {
            return true;
        }

    }
}
