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

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }
            return View();
        }
        public ActionResult Profil()
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
            return View(nauczyciel);
        }
        public ActionResult Oceny()
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            return View(db.listaKlasaPrzedmiot.Where(kp => kp.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID).Include(kp => kp.klasa).Include(kp => kp.nauczycielPrzedmiot).Include(kp => kp.nauczycielPrzedmiot.przedmiot).Include(l => l.klasa.uczens));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Oceny(int przedmiotID,int uczenID,string opis,string options)
        {
           
            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            Ocena o = new Ocena();
            o.nauczycielID = nauczyciel.nauczycielID;
            o.przedmiotID = przedmiotID;
            o.uczenID = uczenID;
            o.opis = opis;
            o.wartosc= Int32.Parse(options);
            o.data_wystawienia = DateTime.Now;

            db.Oceny.Add(o);
            db.SaveChanges();

         
            return View(db.listaKlasaPrzedmiot.Where(kp => kp.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID).Include(kp => kp.klasa).Include(kp => kp.nauczycielPrzedmiot).Include(kp => kp.nauczycielPrzedmiot.przedmiot).Include(l => l.klasa.uczens));

        }
     
        public ActionResult Ogloszenia()
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }
            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            //wybieramy listę klas które uczy zalogowany nauczyciel
            ViewBag.klasaID = new SelectList(db.Klasas.Where(k=> k.przedmioty.Any(n=>n.nauczycielPrzedmiot.nauczycielID==nauczyciel.nauczycielID)), "klasaID", "symbol");

            //ogloszenia wystawione przez zalogowanego nauczyciela
            return View(nauczyciel.ogloszenia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ogloszenia(string temat, string tresc, int klasaID)
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }
            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            //wybieramy listę klas które uczy zalogowany nauczyciel
            ViewBag.klasaID = new SelectList(db.Klasas.Where(k => k.przedmioty.Any(n => n.nauczycielPrzedmiot.nauczycielID == nauczyciel.nauczycielID)), "klasaID", "symbol");

            Ogloszenie og = new Ogloszenie();

            og.nauczycielID = nauczyciel.nauczycielID;
            og.data_wystawienia = DateTime.Now;
            og.klasaID = klasaID;
            og.temat = temat;
            og.tresc = tresc;
         
            db.Ogloszenia.Add(og);
            db.SaveChanges();
            nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            return View(nauczyciel.ogloszenia);
        }
        public ActionResult Przedmioty()
        {
          
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
           
            return View(nauczyciel.przedmioty);
        }

        public ActionResult DetailsPrzedmiot(int ?id)
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

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


        public ActionResult Uczniowie()//klasa wychowawcy
        {

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
            if(nauczyciel.klasa.Any() && nauczyciel.klasa!=null)//if nauczyciel jest wychowawcą
            {
                ViewBag.wychowawstwo = "Jesteś wychowacą klasy " + nauczyciel.klasa.First().rok_rozpoczecia_toku_ksztalcenia+" "+nauczyciel.klasa.First().symbol;
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

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }

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
        public ActionResult Sale()
        {
           
            return View(db.saleLekcyjne.ToList());
        }
        public ActionResult DetailsSale(int? id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLekcyjne saleLekcyjne = db.saleLekcyjne.Find(id);
            if (saleLekcyjne == null)
            {
                return HttpNotFound();
            }
            return View(saleLekcyjne);
        }
        // GET: ZajetoscSalLekcyjnyches/Create
        public ActionResult RezerwujSale()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("nauczyciel"))
            {
                return Redirect("BrakUprawnien");
            }
            Nauczyciel nauczyciel = db.Nauczyciele.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol");
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot.Where(np=>np.nauczycielID==nauczyciel.nauczycielID), "ID", "przedmiot.nazwa");
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "numerSali");
            return View();
        }

        // POST: ZajetoscSalLekcyjnyches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RezerwujSale([Bind(Include = "zajetoscSalLekcyjnychID,saleLekcyjneID,dzienTygodnia,numerGodzinyLekcyjnej,nauczycielPrzedmiotID,klasaID")] ZajetoscSalLekcyjnych zajetoscSalLekcyjnych)
        {
            if (ModelState.IsValid)
            {
                db.zajetoscSalLekcyjnych.Add(zajetoscSalLekcyjnych);
                db.SaveChanges();
                return RedirectToAction("Panel", "Nauczyciel");
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", zajetoscSalLekcyjnych.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "przedmiotID");
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "numerSali");
            return View(zajetoscSalLekcyjnych);
        }
        public ActionResult BrakUprawnien()
        {
            return View();
        }
    }
}