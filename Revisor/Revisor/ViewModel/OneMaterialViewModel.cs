using InventoryModels;
using Revisor.Service;
using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class OneMaterialViewModel : ViewModelBase
    {
        public OneMaterialViewModel(LocalContextService localContext)
        {
            LocalContext = localContext;
        }
        LocalContextService LocalContext { get; set; }

        #region ForEding
        private string edingcount;
        public string EdingCount { get => edingcount; set { edingcount = value; OnPropertyChanged("EdingCount"); ClicChangeCount.RaiseCanExecuteChanged(); } }
        #endregion


        private bool isForEding;
        public bool IsForEding { get => isForEding; set { isForEding = value; OnPropertyChanged("IsForEding"); } }


        private bool isnotnomenclature;
        public bool IsNotNomenclature { get => isnotnomenclature; set { isnotnomenclature = value; OnPropertyChanged("IsNotNomenclature"); SaveElement.RaiseCanExecuteChanged(); } }

        public ElementMaterialToUpload ElementMaterialToEdit;

        private MaterialNomenclature materialNomenclature;
        public MaterialNomenclature SelectedMaterialNomenclature { get => materialNomenclature; set { materialNomenclature = value; OnPropertyChanged("SelectedMaterialNomenclature"); SaveElement.RaiseCanExecuteChanged(); } }

        public void Update()
        {
            SelectedMaterialNomenclature = null;
            Name = string.Empty;
            MesuareValue = string.Empty;
            Count = "0";
            IsForEding = false;
            ElementMaterialToEdit = null;
            SaveElement.RaiseCanExecuteChanged();
        }

        public void ImportElement(ElementMaterialToUpload elementMaterialToUpload)
        {
           /* Update();
            if (elementMaterialToUpload.MaterialNomenclature != null)
            {
                this.SelectedMaterialNomenclature = elementMaterialToUpload.MaterialNomenclature;
                this.Count = elementMaterialToUpload.Count.ToString();
            }
            else
            {
                this.Name = elementMaterialToUpload.Name;
                this.MesuareValue = elementMaterialToUpload.Units;
                this.Count = elementMaterialToUpload.Count.ToString();
            }
            ElementMaterialToEdit = elementMaterialToUpload;
            IsForEding = true;
            */
        }


        #region NotNomenclature

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); SaveElement.RaiseCanExecuteChanged(); } }

        private string mesuarevalue;
        public string MesuareValue { get => mesuarevalue; set { mesuarevalue = value; OnPropertyChanged("MesuareValue"); SaveElement.RaiseCanExecuteChanged(); } }

        private string count;
        public string Count { get => count; set { count = value; OnPropertyChanged("Count"); SaveElement.RaiseCanExecuteChanged(); } }



        private RelayCommand selectFromNomenclature;

        public RelayCommand SelectFromNomenclarture

        {
            get
            {
                if (selectFromNomenclature == null)
                {
                    selectFromNomenclature = new RelayCommand(ExecuteSelectFromNomenclarture, CanExecuteSelectFromNomenclarture);
                }
                return selectFromNomenclature;
            }
        }


        public async void ExecuteSelectFromNomenclarture(object parameter)
        {
         //   ViewModelService.SelectNomenclatureMaterialViewModel.Update();
         //   await Shell.Current.Navigation.PushAsync(ViewService.SelectMaterialNomenclature);
        }
        public bool CanExecuteSelectFromNomenclarture(object parameter)
        {
            return true;
        }


        #endregion

        private RelayCommand saveElement;

        public RelayCommand SaveElement

        {
            get
            {
                if (saveElement == null)
                {
                    saveElement = new RelayCommand(ExecuteSaveElement, CanExecuteSaveElement);
                }
                return saveElement;
            }
        }


        public async void ExecuteSaveElement(object parameter)
        {
         /*   double res;
            if (double.TryParse(Count, out res))
            {
                if (IsNotNomenclature)
                {
                    LocalContext.AppDataBaseContext.InventoryListMaterialToUpdate.Add(new ElementMaterialToUpload() { Count = res, HoldMaterial = LocalContext.CurrentHoldMaterial, Name = Name, Units = MesuareValue });
                    LocalContext.AppDataBaseContext.SaveChanges();
                }
                else
                {
                    LocalContext.AppDataBaseContext.InventoryListMaterialToUpdate.Add(new ElementMaterialToUpload() { Count = res, MaterialNomenclature = SelectedMaterialNomenclature, HoldMaterial = LocalContext.CurrentHoldMaterial });
                    LocalContext.AppDataBaseContext.SaveChanges();
                }



                await ViewService.OneMaterial.DisplayAlert("Успешно", "Успешно сохранен материал", "Ок");
                ViewModelService.OneMaterialViewModel.Update();
                ViewModelService.OneMaterialHoldViewModel.Update();
                ViewModelService.ListMaterialElementsForSynchronization.Update();
                await Shell.Current.Navigation.PopAsync();

            }*/
        }
        public bool CanExecuteSaveElement(object parameter)
        {
            double res;
            if (IsNotNomenclature)
            {
                if (Name != null)
                    if (Name.Length > 2)
                        if (MesuareValue != null)
                            if (Double.TryParse(Count, out res))
                            {
                                if (res > 0) return true;
                            }

            }
            else
            {
                if (SelectedMaterialNomenclature != null)
                {
                    if (Double.TryParse(Count, out res))
                    {
                        if (res > 0) return true;
                    }
                }
            }
            return false;
        }


        RelayCommand _clicChangeCount;
        public RelayCommand ClicChangeCount
        {
            get
            {
                if (_clicChangeCount == null)
                {
                    _clicChangeCount = new RelayCommand(ExecuteChangeCount, CanExecuteChangeCount);
                }
                return _clicChangeCount;
            }
        }

        private bool CanExecuteChangeCount(object obj)
        {
            double d;
            if (double.TryParse(EdingCount, out d))
            {
                if (d > 0) return true;
            }
            return false;
        }

        public async void ExecuteChangeCount(object parameter)
        {
            double d;
            if (double.TryParse(EdingCount, out d))
            {
                if (d > 0)
                {
                    if (System.Convert.ToInt32(parameter) == 1)
                    {
                        var result = await ViewService.OneMaterial.DisplayAlert("Подтвердите действие", $"Плюс {d}", "Ок", "Отмена");
                        if (result == true)
                        {
                            ElementMaterialToEdit.Count += d;
                            Count = ElementMaterialToEdit.Count.ToString();
                        }
                    }
                    if (System.Convert.ToInt32(parameter) == 2)
                    {
                        var result = await ViewService.OneMaterial.DisplayAlert("Подтвердите действие", $"Минус {d}", "Ок", "Отмена");
                        if (result == true)
                        {
                            ElementMaterialToEdit.Count -= d;
                            Count = ElementMaterialToEdit.Count.ToString();

                        }
                    }
                ///   LocalContext.AppDataBaseContext.SaveChanges();
                    ViewModelService.OneMaterialHoldViewModel.Update();
                }
            }
        }

    }
}
