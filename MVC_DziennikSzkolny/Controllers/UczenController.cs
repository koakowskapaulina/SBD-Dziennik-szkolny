using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class UczenController : Controller
    {
        // GET: Uczen
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Profil()
        {
            //TODO: możliwość zmiany e-maila i hasła,telefonu
            return View();
        }
        public ActionResult Oceny()
        {
            return View();
        }
        public ActionResult Przedmioty()
        {
            return View();
        }


    }
}