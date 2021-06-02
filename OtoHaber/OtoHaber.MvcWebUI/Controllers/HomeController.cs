using OtoHaber.DataAccess.Concrete;
using OtoHaber.Entities.Domains;
using OtoHaber.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        KategoriDal kategoriDal = new KategoriDal();
        YazarDal yazarDal = new YazarDal();
        HaberDal haberDal = new HaberDal();
        HaberResimDal haberResimDal = new HaberResimDal();
        YorumDal yorumDal = new YorumDal();

        [HttpGet]
        public ActionResult Index(int? id)
        {
            var model = new HomeIndexViewModel();
            model.Kategoriler = kategoriDal.GetirTumunu();
            if (id.HasValue)
            {
                model.HaberDetayDtos = haberDal.GetirHaberDetayDtoListByCount(15, id.Value);
                return View(model);
            }
            model.HaberDetayDtos = haberDal.GetirHaberDetayDtoListByCount(15);
            return View(model);
        }

        [HttpGet]
        public ActionResult HaberDetay(int id)
        {
            var model = new HaberDetayViewModel();
            var haber = haberDal.GetirById(id);
            var haberResim = haberResimDal.GetirByHaberId(haber.Id);

            model.Haber = haber;
            model.HaberResim = haberResim;
            model.HaberYazar = yazarDal.GetirById(haber.YazarId);
            model.HaberYorumlar = yorumDal.GetirYorumDetayDtoListByHaberId(haber.Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult YorumYap(string yorumMetni, int haberId)
        {
            var yorum = new Yorum
            {
                HaberId = haberId,
                YorumMetni= yorumMetni,
                YorumTarihi = DateTime.Now,
                KullaniciId = 1
            };
            yorumDal.Ekle(yorum);
            return Redirect("/Home/HaberDetay/" + haberId);
        }
    }
}