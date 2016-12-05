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

        // GET: Rodzic

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
            //TODO : możliwość zmiany emaila, hasła, telefonu
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
            //TODO:
            return View();
        }
        public ActionResult Wiadomosci()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("rodzic"))
            {
                return Redirect("BrakUprawnien");
            }
            //TODO: 
            return View();
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
            //TODO:
            return View();
        }

        // GET:
        public ActionResult EditProfil()
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

        // POST:
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfil([Bind(Include = "rodzicID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Rodzic rodzic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rodzic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfilRodzica");
            }
            return View(rodzic);
        }
        public ActionResult BrakUprawnien()
        {
            return View();
        }

    }
}