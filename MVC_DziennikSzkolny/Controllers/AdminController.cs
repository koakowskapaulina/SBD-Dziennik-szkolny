using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Panel()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return Redirect("BrakUprawnien");
            }
            return View();
            
        }
        public ActionResult BrakUprawnien()
        {
            return View();
        }
    }
}