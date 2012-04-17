using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WangxiaoCN;

namespace Mvc2App.Areas.Admin.Controllers
{
    public class indexController : Controller
    {
        //
        // GET: /Admin/index/

        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult test()
        {
            
            ViewData["title"] = Request.Form["productname"];
            return View("login");
        }
    }
}
