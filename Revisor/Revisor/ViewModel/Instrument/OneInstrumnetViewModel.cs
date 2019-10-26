using Revisor.ViewModel.Base;
using Revisor.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.ViewModel
{
    public class OneInstrumnetViewModel : ViewModelBase
    {

        public LocalContext LocalContext { get; set; }
        public OneInstrumnetViewModel(LocalContext localContext) => LocalContext = localContext;





        private string imageSource;
        public string ImageSource { get => imageSource; set { imageSource = value; OnPropertyChanged("ImageSource"); SaveElement.RaiseCanExecuteChanged(); } }

        private bool isNewElement;
        public bool IsNewElement { get => isNewElement; set { isNewElement = value; OnPropertyChanged("IsNewElement"); SaveElement.RaiseCanExecuteChanged(); } }

        private bool autogen;
        public bool Autogen { get => autogen; set { autogen = value; OnPropertyChanged("Autogen"); SaveElement.RaiseCanExecuteChanged(); } }


        #region OldElement

        private InstrumnetHeader selectedInstrumnetHeader;
        public InstrumnetHeader SelectedInstrumnetHeader { get => selectedInstrumnetHeader; set { selectedInstrumnetHeader = value; OnPropertyChanged("SelectedInstrumnetHeader"); SaveElement.RaiseCanExecuteChanged(); } }

        #endregion

        #region NewElement

        private InstrumentNomenclature nomenclature;
        public InstrumentNomenclature Nomenclature { get => nomenclature; set { nomenclature = value; OnPropertyChanged("Nomenclature"); SaveElement.RaiseCanExecuteChanged(); } }

        private string xkey;
        public string XKey { get => xkey; set { xkey = value; OnPropertyChanged("XKey"); SaveElement.RaiseCanExecuteChanged(); } }
        #endregion

        private RelayCommand takeFoto;

        public RelayCommand TakeFoto

        {
            get
            {
                if (takeFoto == null)
                {
                    takeFoto = new RelayCommand(ExecuteTakeFoto, CanExecuteTakeFoto);
                }
                return takeFoto;
            }
        }


        public async void ExecuteTakeFoto(object parameter)
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Sample",
                    Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                });

                if (file == null)
                    return;
                ImageSource = (file.Path);
            };




        }
        public bool CanExecuteTakeFoto(object parameter)
        {
            return true;
        }



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
            ViewModelService.SelectNomenclatureViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.SelectNomenclaturePage);
        }
        public bool CanExecuteSelectFromNomenclarture(object parameter)
        {
            return true;
        }








        private RelayCommand selectFromListElements;

        public RelayCommand SelectFromListElements

        {
            get
            {
                if (selectFromListElements == null)
                {
                    selectFromListElements = new RelayCommand(ExecuteSelectFromListElements, CanExecuteSelectFromListElements);
                }
                return selectFromListElements;
            }
        }


        public async void ExecuteSelectFromListElements(object parameter)
        {
            ViewModelService.SelectElementViewModel.Update();
            await Shell.Current.Navigation.PushAsync(ViewService.SelectElementPage);
        }
        public bool CanExecuteSelectFromListElements(object parameter)
        {
            return true;
        }




        private RelayCommand deleteImage;

        public RelayCommand DeleteImage

        {
            get
            {
                if (deleteImage == null)
                {
                    deleteImage = new RelayCommand(ExecuteDeleteImage, CanExecuteDeleteImage);
                }
                return deleteImage;
            }
        }


        public void ExecuteDeleteImage(object parameter)
        {
            ImageSource = "";
        }
        public bool CanExecuteDeleteImage(object parameter)
        {
            return true;
        }




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

            if (IsNewElement)
            {
                if (Autogen) LocalContext.AppDataBaseContext.InventoryListInstrumentToUpdate.Add(new ElementInstrumentToUpload { HoldInstrument = LocalContext.CurrentHoldInstrument, ImagePhoneSource = ImageSource, Nomenclature = Nomenclature, XKey = null });
                else LocalContext.AppDataBaseContext.InventoryListInstrumentToUpdate.Add(new ElementInstrumentToUpload { HoldInstrument = LocalContext.CurrentHoldInstrument, ImagePhoneSource = ImageSource, Nomenclature = Nomenclature, XKey = XKey });
            }
            else
            {
                LocalContext.AppDataBaseContext.InventoryListInstrumentToUpdate.Add(new ElementInstrumentToUpload { HoldInstrument = LocalContext.CurrentHoldInstrument, ImagePhoneSource = ImageSource, InstrumnetHeader = SelectedInstrumnetHeader });
            }
            LocalContext.AppDataBaseContext.SaveChanges();

            ViewModelService.OneInstrumnetHoldViewModel.Update();
            ViewModelService.ListElementsForSynchroniztionViewModel.Update();
            await Shell.Current.Navigation.PopAsync();
        }
        public bool CanExecuteSaveElement(object parameter)
        {
            if (ImageSource != null && ImageSource.Length > 0)
            {
                if (IsNewElement)
                {
                    if (Nomenclature != null)
                    {
                        if (Autogen) return true;

                        if (XKey != null)
                            if (XKey.Length > 2) return true;
                    }
                }
                else
                {
                    if (SelectedInstrumnetHeader != null) return true;
                }
            }
            return false;
        }

        public void Update()
        {
            IsNewElement = false;
            ImageSource = "";
            Autogen = false;
            SelectedInstrumnetHeader = null;
            Nomenclature = null;
            XKey = "";
        }


    }
}
