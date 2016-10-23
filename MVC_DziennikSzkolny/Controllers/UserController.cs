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
            //  UczenController uczencontroller = new UczenController();
            if (u.email[0] == '1')//uczen
            {

                return View("~/Views/Uczen/Panel.cshtml");
            }
            else if (u.email[0] == '2')//rodzic
            {
                return View("~/Views/Rodzic/Panel.cshtml");

            }
            else if (u.email[0] == '3')//nauczyciel
            {
                return View("~/Views/Nauczyciel/Panel.cshtml");
            }
          //  else if (u.email[0] == '5')//admin
           // {
          //      return View("~/Views/Admin/Panel.cshtml");
          //  }
              else
            {
                ViewBag.Message = "Nieudane logowanie ";

                return View();
            }
        }


    }
}