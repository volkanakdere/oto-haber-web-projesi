using OtoHaber.DataAccess.Concrete;
using OtoHaber.Entities.Domains;
using OtoHaber.MvcWebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Controllers
{
    public class HaberController : Controller
    {
        KategoriDal kategoriDal = new KategoriDal();
        YazarDal yazarDal = new YazarDal();
        HaberDal haberDal = new HaberDal();
        HaberResimDal haberResimDal = new HaberResimDal();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new HaberIndexViewModel();
            model.HaberDetayDtoList = haberDal.GetirHaberDetayDtoList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new HaberEkleViewModel();
            model.Kategoriler = kategoriDal.GetirTumunu().Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.Id.ToString()
            }).ToList();

            model.Yazarlar = yazarDal.GetirTumunu().Select(x => new SelectListItem
            {
                Text = x.YazarAdi +" "+ x.YazarSoyadi,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(HaberEkleViewModel model)
        {
            var resim = model.Resim;
            if (resim == null || resim.ContentLength == 0)
            {
                model.Kategoriler = kategoriDal.GetirTumunu().Select(x => new SelectListItem
                {
                    Text = x.KategoriAdi,
                    Value = x.Id.ToString()
                }).ToList();
                model.Yazarlar = yazarDal.GetirTumunu().Select(x => new SelectListItem
                {
                    Text = x.YazarAdi + " " + x.YazarSoyadi,
                    Value = x.Id.ToString()
                }).ToList();
                return View(model);
            }
            var haber = model.Haber;
            haber.Tarih = DateTime.Now;
            haber.Icerik = model.HaberIcerik;
            haberDal.Ekle(haber);

            var fileName =
                    Path.GetRandomFileName().Replace('.', '-')
                    + Path.GetExtension(resim.FileName);
            var path = Path.Combine(Server.MapPath("~/Uploads/HaberResimler"), fileName);
            resim.SaveAs(path);

            var haberResim = new HaberResim
            {
                HaberId = haber.Id,
                ResimDosyaYolu = fileName
            };

            haberResimDal.Ekle(haberResim);

            TempData["Mesaj"] = $" Haber başarıyla eklendi";
            return RedirectToAction("Index");
        }
    }
}