using System.Web.Mvc;

namespace Mvc2App.Areas.ExamCenter
{
    public class ExamCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ExamCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ExamCenter_default",
                "ExamCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
