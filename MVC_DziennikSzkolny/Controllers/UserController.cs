using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Logowanie()
        {
            return View();
        }
    }
}