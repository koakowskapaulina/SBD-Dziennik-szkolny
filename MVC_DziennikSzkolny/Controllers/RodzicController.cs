using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class RodzicController : Controller
    {
        // GET: Rodzic
      
        public ActionResult Panel()
        {
            
            return View();
        }
        public ActionResult ProfilRodzica()
        {
            return View();
        }
        public ActionResult ProfilUcznia()
        {
            return View();
        }
        public ActionResult Oceny()
        {
            return View();
        }
        public ActionResult Wiadomosci()
        {
            return View();
        }
        public ActionResult Ogloszenia()
        {
            return View();
        }

    }
}