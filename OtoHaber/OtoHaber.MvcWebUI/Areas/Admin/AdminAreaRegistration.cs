using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="Home",action = "Dashboard", id = UrlParameter.Optional },
                new[] { "OtoHaber.MvcWebUI.Areas.Admin.Controllers" }
            );
        }
    }
}