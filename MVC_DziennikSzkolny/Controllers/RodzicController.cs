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
            
            return View();
        }
        public ActionResult ProfilRodzica()
        {
            //TODO : możliwość zmiany emaila, hasła, telefonu
            Rodzic rodzic = db.Rodzice.Find(1);
            return View(rodzic);
        }
        public ActionResult ProfilUcznia()
        {
            Rodzic rodzic = db.Rodzice.Find(1);

            IEnumerable<Uczen> uczniowie =db.Uczniowie.Where(a => a.rodzicID == rodzic.rodzicID).Include(u => u.klasa);
            
            return View(uczniowie);
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

        // GET:
        public ActionResult EditProfil()
        {
            Rodzic rodzic = db.Rodzice.Find(1);
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
    }
}