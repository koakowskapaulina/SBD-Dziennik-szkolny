using MVC_DziennikSzkolny.Models;
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
        [HttpPost]
        public ActionResult Logowanie(User u)
        {
            ViewBag.Message = "Zalogowano jako: " + u.email;
            return View();
        }


    }
}