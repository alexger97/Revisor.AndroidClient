using Revisor.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.Service
{
  public  class ViewModelService
    {

        public static OneInstrumnetViewModel OneInstrumnetViewModel { get; set; }

        public static OneMaterialViewModel OneMaterialViewModel { get; set; }
     //   public static SelectNomenclatureViewModel SelectNomenclatureViewModel { get; set; }

       // public static SelectElementHeaderPageViewModel SelectElementViewModel { get; set; }

        public static MainViewModel MainPageViewModel { get; set; }

        public static ListOfObjectsViewModel ListOfObjectsViewModel { get; set; }

        public static SelectTypeOfWorkViewModel SelectTypeOfWorkViewModel { get; set; }

        public static ListOfInstrumentHoldsListViewModel ListOfInstrumentHoldsListViewModel { get; set; }
        public static ListOfMaterialHoldsListViewModel ListOfMaterialHoldsListViewModel { get; set; }

        public static OneInstrumnetHoldViewModel OneInstrumnetHoldViewModel { get; set; }

        public static OneMaterialHoldViewModel OneMaterialHoldViewModel { get; set; }
       /* public static ListInstrumentElementsForSynchroniztionViewModel ListElementsForSynchroniztionViewModel { get; set; }
        public static ListMaterialElementsForSynchronization ListMaterialElementsForSynchronization { get; set; }
        public static SelectNomenclatureMaterialViewModel SelectNomenclatureMaterialViewModel { get; set; }

        public static DowloadElementsViewModel DowloadElementsViewModel { get; set; }

        public static SettingsViewModel SettingsView { get; set; }*/

    }
}
