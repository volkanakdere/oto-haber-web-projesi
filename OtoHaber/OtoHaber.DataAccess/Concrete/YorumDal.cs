using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete
{
    public class YorumDal : BaseEntityDal<Yorum>
    {
        public List<YorumDetayDto> GetirYorumDetayDtoList()
        {
            using (var context = new OtoHaberContext())
            {
                var query = from yorumlar in context.Yorumlar
                            join kullanicilar in context.Kullanicilar
                            on yorumlar.KullaniciId equals kullanicilar.Id
                            select new YorumDetayDto
                            {
                                Id = yorumlar.Id,
                                KullaniciAdSoyad = kullanicilar.Adi + " "+ kullanicilar.Soyadi,
                                KullaniciId = yorumlar.KullaniciId,
                                OnaylandiMi = yorumlar.OnaylandiMi,
                                YorumMetni = yorumlar.YorumMetni,
                                YorumTarihi = yorumlar.YorumTarihi
                            };

                return query.ToList();
            }
        }
    }
}
