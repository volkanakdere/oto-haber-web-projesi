using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete
{
    public class KullaniciDal : BaseEntityDal<Kullanici>
    {
        
        public List<KullaniciDetayDto> GetirKullaniciDetayDtoList()
        {
            using (var context = new OtoHaberContext())
            {
                var query = from kullanicilar in context.Kullanicilar
                            join roller in context.Roller
                            on kullanicilar.RolId equals roller.Id
                            select new KullaniciDetayDto
                            {
                                Adi = kullanicilar.Adi,
                                Eposta = kullanicilar.Eposta,
                                Id = kullanicilar.Id,
                                Rol = roller.RolAdi,
                                Soyadi = kullanicilar.Soyadi
                            };

                return query.ToList();
            }
        }

        public KullaniciDetayDto GetirKullaniciDetayDtoById(int kullaniciId)
        {
            using (var context = new OtoHaberContext())
            {
                var query = from kullanicilar in context.Kullanicilar
                            join roller in context.Roller
                            on kullanicilar.RolId equals roller.Id
                            where kullanicilar.Id == kullaniciId
                            select new KullaniciDetayDto
                            {
                                Adi = kullanicilar.Adi,
                                Eposta = kullanicilar.Eposta,
                                Id = kullanicilar.Id,
                                Rol = roller.RolAdi,
                                Soyadi = kullanicilar.Soyadi
                            };

                return query.FirstOrDefault();
            }
        }        
    }
}
