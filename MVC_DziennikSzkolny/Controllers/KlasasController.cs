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
    public class KlasasController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Klasas
        public ActionResult Index()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            var klasas = db.Klasas.Include(k => k.nauczyciel);
            return View(klasas.ToList());
        }

        // GET: Klasas/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
            
        }

        // GET: Klasas/Create
        public ActionResult Create()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Imie");
            return View();
        }

        // POST: Klasas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "klasaID,rok_rozpoczecia_toku_ksztalcenia,symbol,nauczycielID")] Klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Klasas.Add(klasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Nazwisko", klasa.nauczycielID);
            return View(klasa);
        }

        // GET: Klasas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            
            if (klasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Imie", klasa.nauczycielID);
            return View(klasa);
        }

        // POST: Klasas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "klasaID,rok_rozpoczecia_toku_ksztalcenia,symbol,nauczycielID")] Klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nauczycielID = new SelectList(db.Nauczyciele, "nauczycielID", "Imie", klasa.nauczycielID);
            return View(klasa);
        }

        // GET: Klasas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        // POST: Klasas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klasa klasa = db.Klasas.Find(id);
            db.Klasas.Remove(klasa);
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

     
    }
}
