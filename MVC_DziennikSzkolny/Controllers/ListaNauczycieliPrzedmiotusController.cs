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
    public class ListaNauczycieliPrzedmiotusController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: ListaNauczycieliPrzedmiotus
        public ActionResult Index()
        {
            var listaNauczycielPrzedmiot = db.listaNauczycielPrzedmiot.Include(l => l.nauczyciel).Include(l => l.przedmiot);
            return RedirectToAction("Index","Nauczyciels");
        }

        // GET: ListaNauczycieliPrzedmiotus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu = db.listaNauczycielPrzedmiot.Find(id);
            if (listaNauczycieliPrzedmiotu == null)
            {
                return HttpNotFound();
            }
            return View(listaNauczycieliPrzedmiotu);
        }

        // GET: ListaNauczycieliPrzedmiotus/Create
        public ActionResult Create()
        {
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko");
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa");
            return View();
        }

        // POST: ListaNauczycieliPrzedmiotus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nauczycielID,przedmiotID")] ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu)
        {
            if (ModelState.IsValid)
            {
                db.listaNauczycielPrzedmiot.Add(listaNauczycieliPrzedmiotu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", listaNauczycieliPrzedmiotu.nauczycielID);
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa", listaNauczycieliPrzedmiotu.przedmiotID);
            return View(listaNauczycieliPrzedmiotu);
        }

        // GET: ListaNauczycieliPrzedmiotus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu = db.listaNauczycielPrzedmiot.Find(id);
            if (listaNauczycieliPrzedmiotu == null)
            {
                return HttpNotFound();
            }
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", listaNauczycieliPrzedmiotu.nauczycielID);
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa", listaNauczycieliPrzedmiotu.przedmiotID);
            return View(listaNauczycieliPrzedmiotu);
        }

        // POST: ListaNauczycieliPrzedmiotus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nauczycielID,przedmiotID")] ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaNauczycieliPrzedmiotu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", listaNauczycieliPrzedmiotu.nauczycielID);
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa", listaNauczycieliPrzedmiotu.przedmiotID);
            return View(listaNauczycieliPrzedmiotu);
        }

        // GET: ListaNauczycieliPrzedmiotus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu = db.listaNauczycielPrzedmiot.Find(id);
            if (listaNauczycieliPrzedmiotu == null)
            {
                return HttpNotFound();
            }
            return View(listaNauczycieliPrzedmiotu);
        }

        // POST: ListaNauczycieliPrzedmiotus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu = db.listaNauczycielPrzedmiot.Find(id);
            db.listaNauczycielPrzedmiot.Remove(listaNauczycieliPrzedmiotu);
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






        
        // GET: ListaNauczycieliPrzedmiotus/AddNauczyciel/5
        public ActionResult AddNauczyciel(int? id)//dostajemy id przedmiotu
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
            
          //  ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko");
         //   ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa",przedmiot.przedmiotID);

            ViewBag.przedmiotID = przedmiot.przedmiotID;
            ViewBag.przedmiot = przedmiot.nazwa;
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele.Where(n => n.przedmioty.All(p => p.przedmiotID != przedmiot.przedmiotID)), "nauczycielID", "Nazwisko");

            return View();
        }

        // POST: ListaNauczycieliPrzedmiotus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNauczyciel([Bind(Include = "ID,nauczycielID,przedmiotID")] ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu)
        {
            if (ModelState.IsValid)
            {
                db.listaNauczycielPrzedmiot.Add(listaNauczycieliPrzedmiotu);
                db.SaveChanges();
                return RedirectToAction("Details", "Przedmiots", new { id = listaNauczycieliPrzedmiotu.przedmiotID });
            }
             
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", listaNauczycieliPrzedmiotu.nauczycielID);
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa", listaNauczycieliPrzedmiotu.przedmiotID);
            return View(listaNauczycieliPrzedmiotu);
        }






        // GET: ListaNauczycieliPrzedmiotus/AddPrzedmiot/5
        public ActionResult AddPrzedmiot(int? id)//id nauczyciela
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nauczyciel nauczyciel = db.Nauczyciele.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }

            ViewBag.nauczycielID = nauczyciel.nauczycielID;
            ViewBag.nauczyciel = nauczyciel.Imie + " " + nauczyciel.Nazwisko;
             ViewBag.przedmiotID = new SelectList(db.Przedmioty.Where(p=>p.nauczyciele.All(n=>n.nauczycielID!=nauczyciel.nauczycielID)), "przedmiotID", "nazwa");
              return View();
        }

        // POST: ListaNauczycieliPrzedmiotus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPrzedmiot([Bind(Include = "ID,nauczycielID,przedmiotID")] ListaNauczycieliPrzedmiotu listaNauczycieliPrzedmiotu)
        {
            if (ModelState.IsValid)
            {
                db.listaNauczycielPrzedmiot.Add(listaNauczycieliPrzedmiotu);
                db.SaveChanges();
                return RedirectToAction("Details", "Nauczyciels", new { id = listaNauczycieliPrzedmiotu.nauczycielID });
            }

            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", listaNauczycieliPrzedmiotu.nauczycielID);
            ViewBag.przedmiotID = new SelectList(db.Przedmioty, "przedmiotID", "nazwa", listaNauczycieliPrzedmiotu.przedmiotID);
            return View(listaNauczycieliPrzedmiotu);
        }

    }
}
