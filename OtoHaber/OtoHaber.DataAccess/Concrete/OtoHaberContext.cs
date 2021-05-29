using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete
{
    public class OtoHaberContext : DbContext
    {
        public OtoHaberContext()
        {
            Database.SetInitializer<OtoHaberContext>(null);
        }

        public DbSet<Haber> Haberler { get; set; }
        public DbSet<HaberResim> HaberResimler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
