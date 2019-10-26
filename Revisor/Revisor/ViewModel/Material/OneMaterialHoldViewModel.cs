using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class OneMaterialHoldViewModel : ViewModelBase
    {
        public OneMaterialHoldViewModel(LocalContext localContext) => LocalContext = localContext;
        public LocalContext LocalContext { get; set; }
        public List<ElementMaterialToUpload> LocalSaveElements { get => LocalContext.LocalSavedMaterialForOneHold; }



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
            ViewModelService.OneMaterialViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.OneMaterial);
        }
        public bool CanExecuteAddnewElement(object parameter)
        {
            return true;
        }


        private RelayCommand selectforEding;

        public RelayCommand SelectForEding

        {
            get
            {
                if (selectforEding == null)
                {
                    selectforEding = new RelayCommand(ExecuteSelectForEding, CanExecuteSelectForEding);
                }
                return selectforEding;
            }
        }


        public async void ExecuteSelectForEding(object parameter)
        {


            ViewModelService.OneMaterialViewModel.ImportElement((ElementMaterialToUpload)((ItemTappedEventArgs)parameter).Item);
            await Shell.Current.Navigation.PushAsync(ViewService.OneMaterial);

        }
        public bool CanExecuteSelectForEding(object parameter)
        {
            return true;
        }




        public void Update() => OnPropertyChanged("LocalSaveElements");
    }
}
