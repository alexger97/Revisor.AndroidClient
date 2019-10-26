using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    
        public class ListOfInstrumentHoldsListViewModel : ViewModelBase
        {

            public ListOfInstrumentHoldsListViewModel(LocalContext localContext) => LocalContext = localContext;
            public LocalContext LocalContext { get; set; }

            public List<HoldInstrument> HoldInstruments { get { return LocalContext.ListIntrumentHolds; } }

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
                LocalContext.SetCurrentInstrumentHold(((HoldInstrument)((ItemTappedEventArgs)parameter).Item).Id);
                ViewModelService.OneInstrumnetHoldViewModel.Update();
                await Shell.Current.Navigation.PushAsync(ViewService.OneInstrumentHold);
            }
            public bool CanExecuteSelectHold(object parameter)
            {
                return true;
            }

        }
    
}
