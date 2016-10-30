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
            //TODO : możliwość zmiany emaila, hasła, telefonu
            return View();
        }
        public ActionResult ProfilUcznia()
        {
            //TODO : wziąć pod uwagę możliwość posiadania kilkorga dzieci
            return View();
        }
        public ActionResult Oceny()
        {
            //TODO : wziąć pod uwagę możliwość posiadania kilkorga dzieci
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