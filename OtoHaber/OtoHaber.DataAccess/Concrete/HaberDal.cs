using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.DataAccess.Concrete
{
    public class HaberDal : BaseEntityDal<Haber>
    {
        public List<HaberDetayDto> GetirHaberDetayDtoList()
        {
            using (var context = new OtoHaberContext())
            {
                var query = from haberler in context.Haberler
                            join yazarlar in context.Yazarlar
                            on haberler.YazarId equals yazarlar.Id
                            //join haberResimler in context.HaberResimler
                            //on haberler.Id equals haberResimler.HaberId
                            select new HaberDetayDto
                            {
                                Baslik = haberler.Baslik,
                                HaberOzeti = haberler.HaberOzeti,
                                OkunmaSayisi = haberler.OkunmaSayisi,
                                Id = haberler.Id,
                                Tarih = haberler.Tarih,
                                YazarAdSoyad = yazarlar.YazarAdi + " " + yazarlar.YazarSoyadi,
                                KategoriId = haberler.KategoriId,
                                HaberResmi = context.HaberResimler.Where(x => x.HaberId == haberler.Id).FirstOrDefault().ResimDosyaYolu
                            };

                return query.ToList();
            }
        }

        public List<HaberDetayDto> GetirHaberDetayDtoListByCount(int count)
        {
            using (var context = new OtoHaberContext())
            {
                var query = from haberler in context.Haberler
                            join yazarlar in context.Yazarlar
                            on haberler.YazarId equals yazarlar.Id    
                            orderby haberler.Id descending
                            select new HaberDetayDto
                            {
                                Baslik = haberler.Baslik,
                                HaberOzeti = haberler.HaberOzeti,
                                OkunmaSayisi = haberler.OkunmaSayisi,
                                Id = haberler.Id,
                                Tarih = haberler.Tarih,
                                YazarAdSoyad = yazarlar.YazarAdi + " " + yazarlar.YazarSoyadi,
                                KategoriId=haberler.KategoriId,
                                HaberResmi = context.HaberResimler.Where(x => x.HaberId == haberler.Id).FirstOrDefault().ResimDosyaYolu
                            };

                return query.Take(count).ToList();
            }
        }

        public List<HaberDetayDto> GetirHaberDetayDtoListByCount(int count, int kategoriId)
        {
            using (var context = new OtoHaberContext())
            {
                var query = from haberler in context.Haberler
                            join yazarlar in context.Yazarlar
                            on haberler.YazarId equals yazarlar.Id
                            where haberler.KategoriId == kategoriId
                            orderby haberler.Id descending
                            select new HaberDetayDto
                            {
                                Baslik = haberler.Baslik,
                                HaberOzeti = haberler.HaberOzeti,
                                OkunmaSayisi = haberler.OkunmaSayisi,
                                Id = haberler.Id,
                                Tarih = haberler.Tarih,
                                YazarAdSoyad = yazarlar.YazarAdi + " " + yazarlar.YazarSoyadi,
                                KategoriId = haberler.KategoriId,
                                HaberResmi = context.HaberResimler.Where(x => x.HaberId == haberler.Id).FirstOrDefault().ResimDosyaYolu
                            };

                return query.Take(count).ToList();
            }
        }
    }
}
