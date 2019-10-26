using System;
using System.Collections.Generic;
using System.Text;
using InventoryModels;
using Microsoft.EntityFrameworkCore;



namespace Revisor.Data
{
 public   class AppDataContext : DbContext
    {
        private string _databasePath;
        public DbSet<Hold> Holds { get; set; }

        public DbSet<TransactInstrument> TransactInstruments { get; set; }

        public DbSet<MaterialNomenclature> MaterialNomenclatures { get; set; }

        public DbSet<MaterialElement> MaterialElements { get; set; }

        public DbSet<ElementMaterialToUpload> ElementInstrumentToUploads { get; set; }

        public DbSet<ElementInstrumentToUpload> ElementMaterialToUploads { get; set; }

        public DbSet<KnownInstrument> KnowInstruments { get; set; }

        public DbSet<Nomenclature> Nomenclatures { get; set; }

        public DbSet<InventoryObject> InventoryObjects { get; set; }


        public AppDataContext(string databasePath)
        {
            _databasePath = databasePath;
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($"Data Source={_databasePath}");
        }



    }
}
