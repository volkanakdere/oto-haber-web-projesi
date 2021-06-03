using OtoHaber.DataAccess.Concrete;
using OtoHaber.Entities.DTOs;
using OtoHaber.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtoHaber.MvcWebUI.Controllers
{
    public class AuthController : Controller
    {
        KullaniciDal kullaniciDal = new KullaniciDal();

        [HttpGet]
        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(AuthUyeOlViewModel model)
        {
            var yeniKullanici = model.Kullanici;
            yeniKullanici.RolId = 2;
            kullaniciDal.Ekle(yeniKullanici);
            var kullaniciRolAdi = kullaniciDal.GetirKullaniciRolByKullanici(yeniKullanici);
            var authTicket = new FormsAuthenticationTicket(
                1,
                yeniKullanici.Eposta,
                DateTime.Now,
                DateTime.Now.AddDays(3),
                false,
                kullaniciRolAdi);

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {
            var kullanici = kullaniciDal.GetirByEpostaVeParola(loginDto.Email, loginDto.Password);
            if (kullanici == null)
            {
                ModelState.AddModelError("", "kullanıcı bulunamadı");
                return View();
            }
            var kullaniciRolAdi = kullaniciDal.GetirKullaniciRolByKullanici(kullanici);
            var authTicket = new FormsAuthenticationTicket(
                1,
                kullanici.Eposta,
                DateTime.Now,
                DateTime.Now.AddDays(3),
                false,
                kullaniciRolAdi);

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}