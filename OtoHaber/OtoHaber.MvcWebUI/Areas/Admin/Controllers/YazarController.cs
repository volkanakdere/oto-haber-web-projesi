using OtoHaber.DataAccess.Concrete;
using OtoHaber.MvcWebUI.Areas.Admin.Models;
using OtoHaber.MvcWebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Controllers
{
    [CustomAuthorizeFilter(Roles = "Admin")]
    public class YazarController : Controller
    {
        YazarDal yazarDal = new YazarDal();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new YazarIndexViewModel();
            model.Yazarlar = yazarDal.GetirTumunu();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new YazarEkleViewModel();            
            return View(model);
        }


        [HttpPost]
        public ActionResult Ekle(YazarEkleViewModel model)
        {
            var yeniYazar = model.Yazar;
            yazarDal.Ekle(yeniYazar);
            TempData["Mesaj"] = $"{yeniYazar.YazarAdi} {yeniYazar.YazarSoyadi} yazarı başarıyla eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var model = new YazarDuzenleViewModel();
            model.Yazar = yazarDal.GetirById(id);            
            return View(model);
        }

        [HttpPost]
        public ActionResult Duzenle(YazarDuzenleViewModel model)
        {
            var yazar = model.Yazar;
            yazarDal.Guncelle(yazar);
            TempData["Mesaj"] = $"{yazar.YazarAdi} {yazar.YazarSoyadi} yazarı başarıyla güncellendi";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Sil(int yazarId)
        {
            var yazar = yazarDal.GetirById(yazarId);
            yazarDal.Sil(yazar);
            return Json("Yazar başarıyla silindi");
        }
    }
}