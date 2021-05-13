using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete.Mappings
{
    public class HaberMap : EntityTypeConfiguration<Haber>
    {
        public HaberMap()
        {
            ToTable(@"Haberler", @"dbo");
            HasKey(x => x.Id);
        }
    }
}
