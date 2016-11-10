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
        int idNauczyciela = 1;
        // GET: Nauczyciel
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Profil()
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(idNauczyciela);
            return View(nauczyciel);
        }
        public ActionResult Oceny()
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(idNauczyciela);

            return View(db.listaKlasaPrzedmiot.Where(kp => kp.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID).Include(kp => kp.klasa).Include(kp => kp.nauczycielPrzedmiot).Include(kp => kp.nauczycielPrzedmiot.przedmiot).Include(l => l.klasa.uczens));
            
        }
        public ActionResult WystawOcenyKlasie/*(int ?idKlasa)*/(int ?id)//idPrzedmiotKlasa
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(1);
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPrzedmiotowKlasy klasaPrzedmiot = db.listaKlasaPrzedmiot.Find(id);
            if (klasaPrzedmiot == null)
            {
                return HttpNotFound();
            }
            Klasa klasa = db.Klasas.Find(klasaPrzedmiot.klasaID);
            List<Ocena> nowe_oceny = new List<Ocena>();
            foreach(Uczen u in klasa.uczens)
            {
                Ocena o = new Ocena();
               
                o.nauczycielID = nauczyciel.nauczycielID;
                o.nauczyciel = nauczyciel;
                o.przedmiotID = klasaPrzedmiot.nauczycielPrzedmiot.przedmiotID;
                o.przedmiot = klasaPrzedmiot.nauczycielPrzedmiot.przedmiot;
                o.uczenID = u.uczenID;
                o.uczen = u;
                nowe_oceny.Add(o);
            }
          //  ViewBag.klasaID = klasaPrzedmiot.klasaID;
            ViewBag.klasaSymbol = klasaPrzedmiot.klasa.symbol;
           // ViewBag.nauczyciel = nauczyciel.Nazwisko + " " + nauczyciel.Imie;
         //   ViewBag.przedmiot = klasaPrzedmiot.nauczycielPrzedmiot.przedmiot;
            //  ViewBag.nauczycielID = klasaPrzedmiot.nauczycielPrzedmiot.nauczycielID;
            //  ViewBag.przedmiotID = klasaPrzedmiot.nauczycielPrzedmiot.przedmiotID;
            return View(nowe_oceny);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult WystawOcenyKlasie/*(int ?idKlasa)*/(IList<Ocena> oceny)
        {
            foreach (Ocena o in oceny)
            {
                // zapisz kazda ocene do bazy z aktualna data
                o.data_wystawienia = DateTime.Today;
                Console.WriteLine(o.uczen.Nazwisko);
            }

           

            return RedirectToAction("Panel");
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

            Nauczyciel nauczyciel = db.Nauczyciele.Find(idNauczyciela);
           
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
            Nauczyciel nauczyciel = db.Nauczyciele.Find(idNauczyciela);
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


        public ActionResult Uczniowie()//klasa wychowawcy
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(idNauczyciela);
            if(nauczyciel.klasa.Any() && nauczyciel.klasa!=null)//if nauczyciel jest wychowawcą
            {
                ViewBag.wychowawstwo = "Wychowawca klasy " + nauczyciel.klasa.First().symbol;
                return View(nauczyciel.klasa.First());
            }
            else
            {
                ViewBag.wychowawstwo = "Nie jesteś wychowawcą żadnej z klas";
            }
            return View();
        }

        public ActionResult DetailsUczen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczen uczen = db.Uczniowie.Find(id);
            if (uczen == null)
            {
                return HttpNotFound();
            }
            return View(uczen);

        }
    }
}