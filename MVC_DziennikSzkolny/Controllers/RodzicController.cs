using MVC_DziennikSzkolny.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class RodzicController : Controller
    {

        private MyDBContext db = new MyDBContext();

        public ActionResult Panel()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }

            return View();
        }
        public ActionResult ProfilRodzica()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }

            Rodzic rodzic = db.Rodzice.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
            return View(rodzic);
        }
        public ActionResult ProfilUcznia()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }

            Rodzic rodzic = db.Rodzice.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            IEnumerable<Uczen> uczniowie =db.Uczniowie.Where(a => a.rodzicID == rodzic.rodzicID).Include(u => u.klasa);
            
            return View(uczniowie);
        }
        public ActionResult Oceny()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }
            Rodzic rodzic = db.Rodzice.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            return View(rodzic);
        }
        
        public ActionResult Ogloszenia()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }
           
            Rodzic rodzic = db.Rodzice.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
            
            return View(rodzic.uczens);
        }

      
        public ActionResult BrakUprawnien()
        {
            return View();
        }

    }
}