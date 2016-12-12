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
    public class SaleLekcyjnesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SaleLekcyjnes
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
            return View(db.saleLekcyjne.ToList());
        }

        // GET: SaleLekcyjnes/Details/5
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
            SaleLekcyjne saleLekcyjne = db.saleLekcyjne.Find(id);
            if (saleLekcyjne == null)
            {
                return HttpNotFound();
            }
            return View(saleLekcyjne);
        }

        // GET: SaleLekcyjnes/Create
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

        // POST: SaleLekcyjnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "saleLekcyjneID,numerSali,pietro")] SaleLekcyjne saleLekcyjne)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.saleLekcyjne.Add(saleLekcyjne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleLekcyjne);
        }

        // GET: SaleLekcyjnes/Edit/5
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
            SaleLekcyjne saleLekcyjne = db.saleLekcyjne.Find(id);
            if (saleLekcyjne == null)
            {
                return HttpNotFound();
            }
            return View(saleLekcyjne);
        }

        // POST: SaleLekcyjnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "saleLekcyjneID,numerSali,pietro")] SaleLekcyjne saleLekcyjne)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(saleLekcyjne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleLekcyjne);
        }

        // GET: SaleLekcyjnes/Delete/5
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
            SaleLekcyjne saleLekcyjne = db.saleLekcyjne.Find(id);
            if (saleLekcyjne == null)
            {
                return HttpNotFound();
            }
            return View(saleLekcyjne);
        }

        // POST: SaleLekcyjnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("admin"))
            {
                return RedirectToAction("BrakUprawnien", "Admin");
            }
            SaleLekcyjne saleLekcyjne = db.saleLekcyjne.Find(id);
            db.saleLekcyjne.Remove(saleLekcyjne);
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
