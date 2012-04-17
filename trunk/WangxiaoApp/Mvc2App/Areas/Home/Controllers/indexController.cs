using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc2App.Areas.Home.Controllers
{
    public class indexController : Controller
    {
        //
        // GET: /Home/index/

        public ActionResult Login()
        {
            ViewData["title"] = "Home/index/Login";
            return View();
        }

    }
}
