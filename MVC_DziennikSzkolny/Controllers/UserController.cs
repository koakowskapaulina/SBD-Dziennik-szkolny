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
        [ValidateAntiForgeryToken]
        public ActionResult Logowanie([Bind(Include = "email,haslo")] User u)
        {
            if (ModelState.IsValid)
            {
                //TODO: nie działa jak trzeba 

                if (u.email[0] == '1')//uczen
                {
                    return RedirectToAction("Panel", "Uczen");

                    //  return View("~/Views/Uczen/Panel.cshtml");
                }
                else if (u.email[0] == '2')//rodzic
                {
                    return View("~/Views/Rodzic/Panel.cshtml");

                }
                else if (u.email[0] == '3')//nauczyciel
                {
                    return View("~/Views/Nauczyciel/Panel.cshtml");
                }
                else if (u.email[0] == '5')//admin
                {
                    return View("~/Views/Admin/Panel.cshtml");
                }
                else
                {
                    ViewBag.Message = "Nieudane logowanie ";

                    return View();
                }

            }
            else
            {
                ViewBag.Message = "not isValid ";
                return View();
            }
        }


    }
}