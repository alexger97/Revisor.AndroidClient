using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Revisor.ViewModel
{
    public class OneInstrumnetHoldViewModel : ViewModelBase
    {
     //  public OneInstrumnetHoldViewModel( localContext) => LocalContext = localContext;
      //  public LocalContext LocalContext { get; set; }
      //  public List<ElementInstrumentToUpload> LocalSaveElements { get => LocalContext.LocalSavedInstrumentsForOneHold; }



        private RelayCommand addnewElement;

        public RelayCommand AddnewElement

        {
            get
            {
                if (addnewElement == null)
                {
                    addnewElement = new RelayCommand(ExecuteAddnewElement, CanExecuteAddnewElement);
                }
                return addnewElement;
            }
        }


        public async void ExecuteAddnewElement(object parameter)
        {
            ViewModelService.OneInstrumnetViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.OneInstrument);
        }
        public bool CanExecuteAddnewElement(object parameter)
        {
            return true;
        }


        public void Update() => OnPropertyChanged("LocalSaveElements");
    }
}
