using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class NauczycielController : Controller
    {
        // GET: Nauczyciel
        public ActionResult Panel()
        {
            return View();
        }
    }
}