using System.Web.Mvc;

namespace Mvc2App.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Home_default",
                "Home/{controller}/{action}/{id}",
                new { contorller="Home", action = "Index", id = UrlParameter.Optional },
                 new string[] { "Mvc2App.Areas.Home.Controllers" }
            );
        }
    }
}
