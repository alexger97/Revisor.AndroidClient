using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Revisor.ViewModel
{
   public class MainViewModel: ViewModelBase
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

         ViewModelService.ListOfObjectsViewModel.Update();
         await Shell.Current.Navigation.PushAsync(ViewService.LsitOfObjects);
        }
        public bool CanExecuteSelectFirstButton(object parameter)
        {
            return true;
        }


 

        private RelayCommand selectSecondtButton;

        public RelayCommand SelectSecondButton

        {
            get
            {
                if (selectSecondtButton == null)
                {
                    selectSecondtButton = new RelayCommand(ExecuteSelectSecondButton,(x)=>true  );
                }
                return selectSecondtButton;
            }
        }


        public async void ExecuteSelectSecondButton(object parameter)
        {

           // ViewModelService.SettingsView.Update();
          //  await Shell.Current.Navigation.PushAsync(ViewService.Setings);
        }
        

    }
}
