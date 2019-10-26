using Revisor.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.Service
{
    public  class ViewService
    {   
        public static MainPage MainPage { get; set; }

        public static LsitOfObjects LsitOfObjects { get; set; }

        public static SelectTypeOfWork SelectTypeOfWork { get; set; }

        public static ListOfInstrumentHolds ListOfInstrumentHolds { get; set; }


        public static OneInstrumentHold OneInstrumentHold { get; set; }

        public static OneInstrument OneInstrument { get; set; }

        public static ListOfMaterialHolds ListOfMaterialHolds { get; set; }
        
        public static OneMaterialHold OneMaterialHold { get; set; }

        public static OneMaterial OneMaterial { get; set; }



       

    }
}
