using OtoHaber.MvcWebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Controllers
{
    [CustomAuthorizeFilter(Roles = "Admin")]
    public class HomeController : Controller
    {                
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}