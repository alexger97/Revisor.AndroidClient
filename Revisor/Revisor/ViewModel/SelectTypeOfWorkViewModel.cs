using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Revisor.ViewModel
{
    public class SelectTypeOfWorkViewModel : ViewModelBase
    {

        private RelayCommand selectFirstButton;

        public RelayCommand SelectFirstButton

        {
            get
            {
                if (selectFirstButton == null)
                {
                    selectFirstButton = new RelayCommand(ExecuteSelectFirstButton, CanExecuteSelectFirstButton);
                }
                return selectFirstButton;
            }
        }


        public async void ExecuteSelectFirstButton(object parameter)
        {
            ViewModelService.ListOfInstrumentHoldsListViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.ListOfInstrumentHolds);
        }
        public bool CanExecuteSelectFirstButton(object parameter)
        {
            return true;
        }




        private RelayCommand selectSecondButton;

        public RelayCommand SelectSecondButton

        {
            get
            {
                if (selectSecondButton == null)
                {
                    selectSecondButton = new RelayCommand(ExecuteSelectSecondButton, CanExecuteSelectSecondButton);
                }
                return selectSecondButton;
            }
        }


        public async void ExecuteSelectSecondButton(object parameter)
        {

            ViewModelService.ListOfMaterialHoldsListViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.ListOfMaterialHolds);
        }
        public bool CanExecuteSelectSecondButton(object parameter)
        {
            return true;
        }


    }
}

