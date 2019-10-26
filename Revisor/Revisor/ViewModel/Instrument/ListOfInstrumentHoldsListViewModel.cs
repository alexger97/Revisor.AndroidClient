using InventoryModels;
using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Revisor.ViewModel
{
    
        public class ListOfInstrumentHoldsListViewModel : ViewModelBase
        {

            public ListOfInstrumentHoldsListViewModel(LocalContextService localContext) => LocalContext = localContext;
            public LocalContextService LocalContext { get; set; }

            public List<Hold> HoldInstruments { get { return LocalContext.ListInstrumentHolds; } }

            public void Update() => OnPropertyChanged("HoldInstruments");


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
                LocalContext.SetCurrentInstrumentHold(((Hold)((ItemTappedEventArgs)parameter).Item).Id);
                ViewModelService.OneInstrumnetHoldViewModel.Update();
                await Shell.Current.Navigation.PushAsync(ViewService.OneInstrumentHold);
            }
            public bool CanExecuteSelectHold(object parameter)
            {
                return true;
            }

        }
    
}
