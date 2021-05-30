using OtoHaber.Entities.Domains;
using System.Linq;

namespace OtoHaber.DataAccess.Concrete
{
    public class HaberResimDal : BaseEntityDal<HaberResim>
    {
        public HaberResim GetirByHaberId(int haberId)
        {
            using (var context = new OtoHaberContext())
            {
                return context.HaberResimler.Where(x => x.HaberId == haberId).FirstOrDefault();
            }
        }
    }
}
