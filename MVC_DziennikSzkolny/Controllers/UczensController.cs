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
    public class UczensController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Uczens
        public ActionResult Index()
        {
            var uczniowie = db.Uczniowie.Include(u => u.klasa).Include(u => u.rodzic);
            return View(uczniowie.ToList());
        }

        // GET: Uczens/Details/5
        public ActionResult Details(int? id)
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

        // GET: Uczens/Create
        public ActionResult Create()
        {
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol");
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie");
            return View();
        }

        // POST: Uczens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uczenID,Data_urodzenia,rodzicID,klasaID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Uczniowie.Add(uczen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);
            return View(uczen);
        }

        // GET: Uczens/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);
            return View(uczen);
        }

        // POST: Uczens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uczenID,Data_urodzenia,rodzicID,klasaID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);
            return View(uczen);
        }

        // GET: Uczens/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Uczens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uczen uczen = db.Uczniowie.Find(id);
            db.Uczniowie.Remove(uczen);
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
