using InventoryModels;
using Revisor.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Revisor.Service
{
     public  class LocalContextService
    {
        public LocalContextService(AppDataContext appDataBaseContext) => AppDataContext = appDataBaseContext;
        public AppDataContext AppDataContext { get; set; }


        
        public List<KnownInstrument> KnownInstrument { get { if (AppDataContext.KnowInstruments != null) return AppDataContext.KnowInstruments.ToList(); return new List<KnownInstrument>(); } }

        public List<Nomenclature> InstrumentNomenclatures { get { if (AppDataContext.Nomenclatures != null) return AppDataContext.Nomenclatures.ToList(); return new List<Nomenclature>(); } }
        public List<MaterialNomenclature> MaterialNomenclatures { get { if (AppDataContext.MaterialNomenclatures != null) return AppDataContext.MaterialNomenclatures.ToList(); return new List<MaterialNomenclature>(); } }

        public List<InventoryObject> InventoryObjects { get => AppDataContext.InventoryObjects.Include(x=>x.Holds).ToList(); }

        public InventoryObject CurrentInventoryObject { get; set; }

        public Hold CurrentHoldInstrument { get; set; }
        public Hold CurrentHoldMaterial { get; set; }


        public List<Hold> ListMaterialHolds { get { 
                if (CurrentInventoryObject != null && CurrentInventoryObject.Holds != null)
                    if (CurrentInventoryObject.Holds.Where(x=>x.Type==TypeOfHold.MaterialHold)!=null)
                    return CurrentInventoryObject.Holds.Where(x=>x.Type==TypeOfHold.MaterialHold).ToList(); 
                return new List<Hold>(); } }


        public List<Hold> ListInstrumentHolds
        {
            get
            {
                if (CurrentInventoryObject != null && CurrentInventoryObject.Holds != null)
                    if (CurrentInventoryObject.Holds.Where(x => x.Type == TypeOfHold.InstrumentHold) != null)
                        return CurrentInventoryObject.Holds.Where(x => x.Type == TypeOfHold.InstrumentHold).ToList();
                return new List<Hold>();
            }
        }


      /*  public List<ElementInstrumentToUpload> LocalSavedInstrumentsForOneHold
        {
            get
            {
                if (AppDataContext.InventoryListInstrumentToUpdate != null && CurrentHoldInstrument != null) return AppDataBaseContext.InventoryListInstrumentToUpdate.Include(x => x.InstrumnetHeader.Nomenclature).Include(x => x.Nomenclature).Where(x => x.HoldInstrument == CurrentHoldInstrument).ToList();
                return new List<ElementInstrumentToUpload>();
            }
        }

        public List<ElementMaterialToUpload> LocalSavedMaterialForOneHold
        {
            get
            {
                if (AppDataBaseContext.InventoryListMaterialToUpdate != null && CurrentHoldMaterial != null) return AppDataBaseContext.InventoryListMaterialToUpdate.Include(x => x.MaterialNomenclature).Include(x => x.HoldMaterial).Where(x => x.HoldMaterial == CurrentHoldMaterial && x.IsLoaded == false).ToList();
                return new List<ElementMaterialToUpload>();
            }
        }*/
        public void SetCurrentInventoryObject(int id)
        {
            CurrentInventoryObject = InventoryObjects.First(x => x.Id == id);
        }
        

        public void SetCurrentInstrumentHold(int id)
        {
            CurrentHoldInstrument = CurrentInventoryObject.Holds.First(x => x.Id == id);
        }

        public void SetCurrentMaterialHold(int id)
        {
            CurrentHoldMaterial = CurrentInventoryObject.Holds.First(x => x.Id == id);
        }

    }
}
