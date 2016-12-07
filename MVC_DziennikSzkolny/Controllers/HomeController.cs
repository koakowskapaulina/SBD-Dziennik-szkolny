using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Panel()
        {
            if (Request.Cookies["zalogowanyRola"] == null) return RedirectToAction("Index", "Home");

            string rola = Request.Cookies["zalogowanyRola"].Value;
           
            if (rola.Equals("admin"))
            {
                return RedirectToAction("Panel","Admin");
            }
            else if (rola.Equals("uczen"))
            {
                return RedirectToAction("Panel", "Uczen");
            }
            else if (rola.Equals("rodzic"))
            {
                return RedirectToAction("Panel", "Rodzic");
            }
            else if (rola.Equals("nauczyciel"))
            {
                return RedirectToAction("Panel", "Nauczyciel");
            }
            return RedirectToAction("Index", "Home");
        }

    
    }
}