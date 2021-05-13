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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
