using OtoHaber.DataAccess.Concrete;
using OtoHaber.MvcWebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Controllers
{
    public class YorumController : Controller
    {
        YorumDal yorumDal = new YorumDal();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new YorumIndexViewModel();
            model.YorumDetayDtoList = yorumDal.GetirYorumDetayDtoList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Sil(int yorumId)
        {
            var yorum = yorumDal.GetirById(yorumId);
            yorumDal.Sil(yorum);
            return Json("Yorum başarıyla silindi");
        }

        [HttpPost]
        public JsonResult Onayla(int yorumId)
        {
            var yorum = yorumDal.GetirById(yorumId);
            yorum.OnaylandiMi = true;
            yorumDal.Guncelle(yorum);
            return Json("Yorum başarıyla onaylandı.");
        }
    }
}