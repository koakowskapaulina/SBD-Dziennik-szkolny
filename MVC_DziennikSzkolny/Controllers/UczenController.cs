using MVC_DziennikSzkolny.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class UczenController : Controller
    {
        private MyDBContext db = new MyDBContext();


        // GET: Uczen
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Profil()
        {
            //TODO: możliwość zmiany e-maila i hasła,telefonu
            Uczen uczen = db.Uczniowie.Find(1);
            return View(uczen);
        }
        public ActionResult Oceny()
        {
            return View();
        }
        public ActionResult Przedmioty()
        {
            return View();
        }



        // GET:
        public ActionResult EditProfil()
        {
            Uczen uczen=db.Uczniowie.Find(1);
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);

            return View(uczen);
        }

        // POST: 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfil([Bind(Include = "uczenID,Data_urodzenia,rodzicID,klasaID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profil");
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);

            return View(uczen);
        }

    }
}