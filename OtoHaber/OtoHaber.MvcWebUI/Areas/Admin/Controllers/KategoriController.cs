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
    public class KategoriController : Controller
    {
        KategoriDal kategoriDal = new KategoriDal();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new KategoriIndexViewModel();
            model.Kategoriler = kategoriDal.GetirTumunu();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KategoriEkleViewModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Ekle(KategoriEkleViewModel model)
        {
            var kategori = model.Kategori;
            kategoriDal.Ekle(kategori);
            TempData["Mesaj"] = $"{kategori.KategoriAdi} kategorisi başarıyla eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var model = new KategoriDuzenleViewModel();
            model.Kategori = kategoriDal.GetirById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Duzenle(KategoriDuzenleViewModel model)
        {
            var kategori = model.Kategori;
            kategoriDal.Guncelle(kategori);
            TempData["Mesaj"] = $"{kategori.KategoriAdi} kategorisi başarıyla güncellendi";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Sil(int kategoriId)
        {
            var kategori = kategoriDal.GetirById(kategoriId);
            kategoriDal.Sil(kategori);
            return Json("Kategori başarıyla silindi");
        }
    }
}