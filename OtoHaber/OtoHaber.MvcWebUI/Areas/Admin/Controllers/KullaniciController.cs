using OtoHaber.DataAccess.Concrete;
using OtoHaber.MvcWebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        OtoHaberContext context = new OtoHaberContext();
        KullaniciDal kullaniciDal = new KullaniciDal();
        [HttpGet]
        public ActionResult Index()
        {
            var model = new KullaniciIndexViewModel();
            model.Kullanicilar = kullaniciDal.GetirKullaniciDetayDtoList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KullaniciEkleViewModel();
            model.Roller = context.Roller.Select(x=> new SelectListItem { 
                Text = x.RolAdi,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public ActionResult Ekle(KullaniciEkleViewModel model)
        {
            var yeniKullanici = model.Kullanici;
            yeniKullanici.Sifre = "123456";

            kullaniciDal.Ekle(yeniKullanici);
            TempData["Mesaj"] = $"{yeniKullanici.Adi} {yeniKullanici.Soyadi} kullanicisi başarıyla eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var model = new KullaniciDuzenleViewModel();
            model.Kullanici = context.Kullanicilar.SingleOrDefault(x => x.Id == id);
            model.Roller = context.Roller.Select(x => new SelectListItem
            {
                Text = x.RolAdi,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Duzenle(KullaniciDuzenleViewModel model)
        {
            var kullanici = model.Kullanici;
            kullaniciDal.Guncelle(kullanici);
            TempData["Mesaj"] = $"{kullanici.Adi} {kullanici.Soyadi} kullanicisi başarıyla güncellendi";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Sil(int kullaniciId)
        {
            var kullanici = kullaniciDal.GetirKullaniciById(kullaniciId);
            kullaniciDal.Sil(kullanici);            
            return Json("Kullanıcı başarıyla silindi");
        }
    }
}