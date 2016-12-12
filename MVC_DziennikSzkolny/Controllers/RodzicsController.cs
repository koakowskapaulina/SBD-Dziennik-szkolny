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
    public class RodzicsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Rodzics
        public ActionResult Index()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien","Admin");
            }
            return View(db.Rodzice.OrderBy(r=>r.Nazwisko).ToList());
        }

        // GET: Rodzics/Details/5
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
            Rodzic rodzic = db.Rodzice.Find(id);
            if (rodzic == null)
            {
                return HttpNotFound();
            }
            return View(rodzic);
        }

        // GET: Rodzics/Create
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

        // POST: Rodzics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rodzicID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Rodzic rodzic)
        {
            if (ModelState.IsValid)
            {
                if (db.Uczniowie.Where(u => u.email.Equals(rodzic.email)).Any() || db.Rodzice.Where(r => r.email.Equals(rodzic.email)).Any() || db.Nauczyciele.Where(n => n.email.Equals(rodzic.email)).Any())
                {
                    ViewBag.EmailJuzIstnieje = "Podany email już istniej w bazie. Musisz podać inny";
                }
                else
                {
                    db.Rodzice.Add(rodzic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(rodzic);
        }

        // GET: Rodzics/Edit/5
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
            Rodzic rodzic = db.Rodzice.Find(id);
            if (rodzic == null)
            {
                return HttpNotFound();
            }
            return View(rodzic);
        }

        // POST: Rodzics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rodzicID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Rodzic rodzic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rodzic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rodzic);
        }

        // GET: Rodzics/Delete/5
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
            Rodzic rodzic = db.Rodzice.Find(id);
            if (rodzic == null)
            {
                return HttpNotFound();
            }
            if(rodzic.uczens.Count>0)
            {
                return RedirectToAction("NiemoznaUsunac","Rodzics");
            }
            return View(rodzic);
        }

        // POST: Rodzics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rodzic rodzic = db.Rodzice.Find(id);
            db.Rodzice.Remove(rodzic);
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
        public ActionResult NiemoznaUsunac()
        {
          
            return View();
        }

    }
}
