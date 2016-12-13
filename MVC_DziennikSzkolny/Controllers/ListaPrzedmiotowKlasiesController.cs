using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_DziennikSzkolny.Models;

namespace MVC_DziennikSzkolny.Controllers
{
    public class ListaPrzedmiotowKlasiesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: ListaPrzedmiotowKlasies
        public ActionResult Index()
        {

            var listaKlasaPrzedmiot = db.listaKlasaPrzedmiot.Include(l => l.klasa).Include(l => l.nauczycielPrzedmiot);

            return RedirectToAction("Index", "Klasas");
        }

        // GET: ListaPrzedmiotowKlasies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPrzedmiotowKlasy listaPrzedmiotowKlasy = db.listaKlasaPrzedmiot.Find(id);
            if (listaPrzedmiotowKlasy == null)
            {
                return HttpNotFound();
            }
            return View(listaPrzedmiotowKlasy);
        }

        // GET: ListaPrzedmiotowKlasies/Create
        public ActionResult Create()
        {
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol");
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID");
            return View();
        }

        // POST: ListaPrzedmiotowKlasies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,klasaID,nauczycielPrzedmiotID")] ListaPrzedmiotowKlasy listaPrzedmiotowKlasy)
        {
            if (ModelState.IsValid)
            {
                db.listaKlasaPrzedmiot.Add(listaPrzedmiotowKlasy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", listaPrzedmiotowKlasy.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", listaPrzedmiotowKlasy.nauczycielPrzedmiotID);
            return View(listaPrzedmiotowKlasy);
        }

        // GET: ListaPrzedmiotowKlasies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPrzedmiotowKlasy listaPrzedmiotowKlasy = db.listaKlasaPrzedmiot.Find(id);
            if (listaPrzedmiotowKlasy == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", listaPrzedmiotowKlasy.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", listaPrzedmiotowKlasy.nauczycielPrzedmiotID);
            return View(listaPrzedmiotowKlasy);
        }

        // POST: ListaPrzedmiotowKlasies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,klasaID,nauczycielPrzedmiotID")] ListaPrzedmiotowKlasy listaPrzedmiotowKlasy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaPrzedmiotowKlasy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", listaPrzedmiotowKlasy.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", listaPrzedmiotowKlasy.nauczycielPrzedmiotID);
            return View(listaPrzedmiotowKlasy);
        }

        // GET: ListaPrzedmiotowKlasies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPrzedmiotowKlasy listaPrzedmiotowKlasy = db.listaKlasaPrzedmiot.Find(id);
            if (listaPrzedmiotowKlasy == null)
            {
                return HttpNotFound();
            }
            return View(listaPrzedmiotowKlasy);
        }

        // POST: ListaPrzedmiotowKlasies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaPrzedmiotowKlasy listaPrzedmiotowKlasy = db.listaKlasaPrzedmiot.Find(id);
            db.listaKlasaPrzedmiot.Remove(listaPrzedmiotowKlasy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }







        
        // GET: ListaPrzedmiotowKlasies/AddKlasa/5
        public ActionResult AddKlasa(int? id)//dostaje id przedmiotu
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
            ViewBag.przedmiot = przedmiot.nazwa;
          

            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot.Where(np=>np.przedmiotID==przedmiot.przedmiotID),"ID","nauczyciel.Nazwisko");
            ViewBag.klasaID = new SelectList(db.Klasas.Where(k=>k.przedmioty.All(p=>p.nauczycielPrzedmiot.przedmiotID!=przedmiot.przedmiotID)), "klasaID", "symbol");
          
            return View();
        }

        // POST: ListaNauczycieliPrzedmiotus/AddKlasa/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddKlasa([Bind(Include = "ID,klasaID,nauczycielPrzedmiotID")] ListaPrzedmiotowKlasy listaPrzedmiotowKlasy)
        {
            if (ModelState.IsValid)
            {
                
                db.listaKlasaPrzedmiot.Add(listaPrzedmiotowKlasy);
                db.SaveChanges();
                //     return RedirectToAction("Details", "Przedmiots", new { id = listaPrzedmiotowKlasy.nauczycielPrzedmiot.przedmiotID });
                return RedirectToAction("Index", "Przedmiots");
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", listaPrzedmiotowKlasy.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "nauczycielID.Nazwisko");
            return View(listaPrzedmiotowKlasy);
        }



      

        // GET: ListaPrzedmiotowKlasies/AddPrzedmiot/5
        public ActionResult AddPrzedmiot(int? id)//dostajemy id klasy
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasa=klasa.symbol+" "+klasa.rok_rozpoczecia_toku_ksztalcenia;
            ViewBag.klasaID =  klasa.klasaID;
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "przedmiot.nazwa");

            return View();
        }

        // POST: ListaNauczycieliPrzedmiotus/AddPrzedmiot/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPrzedmiot([Bind(Include = "ID,klasaID,nauczycielPrzedmiotID")] ListaPrzedmiotowKlasy listaPrzedmiotowKlasy)
        {
            if (ModelState.IsValid)
            {
                db.listaKlasaPrzedmiot.Add(listaPrzedmiotowKlasy);
                db.SaveChanges();
                return RedirectToAction("Details", "Klasas", new { id = listaPrzedmiotowKlasy.klasaID });
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", listaPrzedmiotowKlasy.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "nauczycielID");
            return View(listaPrzedmiotowKlasy);
        }


    



    }
}
