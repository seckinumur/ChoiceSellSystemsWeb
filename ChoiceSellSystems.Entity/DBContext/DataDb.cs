namespace ChoiceSellSystems.Entity.DBContext
{
    using ChoiceSellSystems.Entity.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataDb : DbContext
    {
        public DataDb()
            : base("name=DataDb")
        {
        }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Uruncinsi> Uruncinsi { get; set; }
        public virtual DbSet<UrunKategori> UrunKategori { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
    }
}