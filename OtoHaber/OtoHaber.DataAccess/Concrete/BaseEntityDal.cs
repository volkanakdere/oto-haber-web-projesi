using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete
{
    public abstract class BaseEntityDal<T> where T : class, new()
    {
        public void Ekle(T entity)
        {
            using (var context = new OtoHaberContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Guncelle(T entity)
        {
            using (var context = new OtoHaberContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Sil(T entity)
        {
            using (var context = new OtoHaberContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<T> GetirTumunu()
        {
            using (var context = new OtoHaberContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetirById(int id)
        {
            using (var context = new OtoHaberContext())
            {
                return context.Set<T>().Find(id);
            }
        }
    }
}
