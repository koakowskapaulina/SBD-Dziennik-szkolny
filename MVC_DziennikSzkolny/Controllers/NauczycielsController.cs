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
    public class NauczycielsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Nauczyciels
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
            return View(db.Nauczyciele.OrderBy(r => r.Nazwisko).ToList());
        }

        // GET: Nauczyciels/Details/5
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
            Nauczyciel nauczyciel = db.Nauczyciele.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // GET: Nauczyciels/Create
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
            return View();
        }

        // POST: Nauczyciels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nauczycielID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                if (db.Uczniowie.Where(u => u.email.Equals(nauczyciel.email)).Any()  || db.Rodzice.Where(r => r.email.Equals(nauczyciel.email)).Any() || db.Nauczyciele.Where(n => n.email.Equals(nauczyciel.email)).Any())
                {
                    ViewBag.EmailJuzIstnieje = "Podany email już istniej w bazie. Musisz podać inny";
                }
                else
                {

                    db.Nauczyciele.Add(nauczyciel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(nauczyciel);
        }

        // GET: Nauczyciels/Edit/5
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
            Nauczyciel nauczyciel = db.Nauczyciele.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // POST: Nauczyciels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nauczycielID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nauczyciel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nauczyciel);
        }

        // GET: Nauczyciels/Delete/5
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
            Nauczyciel nauczyciel = db.Nauczyciele.Find(id);
            if (nauczyciel == null)
            {
                return HttpNotFound();
            }
            return View(nauczyciel);
        }

        // POST: Nauczyciels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nauczyciel nauczyciel = db.Nauczyciele.Find(id);
            db.Nauczyciele.Remove(nauczyciel);
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
