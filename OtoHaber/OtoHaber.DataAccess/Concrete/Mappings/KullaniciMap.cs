using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete.Mappings
{
    public class KullaniciMap : EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMap()
        {
            ToTable(@"Kullanicilar", @"dbo");
            HasKey(x => x.Id);
        }
    }
}
