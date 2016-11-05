using MVC_DziennikSzkolny.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class NauczycielController : Controller
    {

        private  MyDBContext db = new MyDBContext();
      
        // GET: Nauczyciel
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Profil()
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);
            return View(nauczyciel);
        }
        public ActionResult Oceny()
        {
            //TODO: możliwość przejrzenia wystawionych przez nauczyciela LUB w przypadku wychowawcy wszystkich ocen swojej klasy
            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);

            return View(db.listaKlasaPrzedmiot.Where(kp => kp.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID).Include(kp => kp.klasa).Include(kp => kp.nauczycielPrzedmiot).Include(kp => kp.nauczycielPrzedmiot.przedmiot).Include(l => l.klasa.uczens));
            
        }
        public ActionResult WystawOceny()
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);
            
            return View(db.listaKlasaPrzedmiot.Where(kp => kp.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID).Include(kp => kp.klasa).Include(kp => kp.nauczycielPrzedmiot).Include(kp=>kp.nauczycielPrzedmiot.przedmiot).Include(l=>l.klasa.uczens));
        }
        public ActionResult Wiadomosci()
        {
            return View();
        }
        public ActionResult Ogloszenia()
        {
            return View();
        }
        public ActionResult Przedmioty()
        {
            //TODO : mozliwosc dodawania treści, plików i tworzenia testow

            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);
           
            return View(nauczyciel.przedmioty);
        }

        public ActionResult DetailsPrzedmiot(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmioty.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
           
        }

        // GET:
        public ActionResult EditProfil()
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);
            return View(nauczyciel);
        }

        // POST: Nauczyciels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfil([Bind(Include = "nauczycielID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nauczyciel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profil");
            }
            return View(nauczyciel);
        }
    }
}