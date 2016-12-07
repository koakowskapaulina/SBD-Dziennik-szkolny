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
    public class ZajetoscSalLekcyjnychesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: ZajetoscSalLekcyjnyches
        public ActionResult Index()
        {
            var zajetoscSalLekcyjnych = db.zajetoscSalLekcyjnych.Include(z => z.klasa).Include(z => z.nauczycielPrzedmiot).Include(z => z.salaLekcyjna);
            return View(zajetoscSalLekcyjnych.ToList());
        }

        // GET: ZajetoscSalLekcyjnyches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZajetoscSalLekcyjnych zajetoscSalLekcyjnych = db.zajetoscSalLekcyjnych.Find(id);
            if (zajetoscSalLekcyjnych == null)
            {
                return HttpNotFound();
            }
            return View(zajetoscSalLekcyjnych);
        }

        // GET: ZajetoscSalLekcyjnyches/Create
        public ActionResult Create()
        {
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol");
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID");
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "saleLekcyjneID");
            return View();
        }

        // POST: ZajetoscSalLekcyjnyches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zajetoscSalLekcyjnychID,saleLekcyjneID,dzienTygodnia,numerGodzinyLekcyjnej,nauczycielPrzedmiotID,klasaID")] ZajetoscSalLekcyjnych zajetoscSalLekcyjnych)
        {
            if (ModelState.IsValid)
            {
                db.zajetoscSalLekcyjnych.Add(zajetoscSalLekcyjnych);
                db.SaveChanges();
                return RedirectToAction("Index","SaleLekcyjnes");
            }

            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", zajetoscSalLekcyjnych.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", zajetoscSalLekcyjnych.nauczycielPrzedmiotID);
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "saleLekcyjneID", zajetoscSalLekcyjnych.saleLekcyjneID);
            return View(zajetoscSalLekcyjnych);
        }

        // GET: ZajetoscSalLekcyjnyches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZajetoscSalLekcyjnych zajetoscSalLekcyjnych = db.zajetoscSalLekcyjnych.Find(id);
            if (zajetoscSalLekcyjnych == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", zajetoscSalLekcyjnych.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", zajetoscSalLekcyjnych.nauczycielPrzedmiotID);
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "saleLekcyjneID", zajetoscSalLekcyjnych.saleLekcyjneID);
            return View(zajetoscSalLekcyjnych);
        }

        // POST: ZajetoscSalLekcyjnyches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "zajetoscSalLekcyjnychID,saleLekcyjneID,dzienTygodnia,numerGodzinyLekcyjnej,nauczycielPrzedmiotID,klasaID")] ZajetoscSalLekcyjnych zajetoscSalLekcyjnych)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zajetoscSalLekcyjnych).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", zajetoscSalLekcyjnych.klasaID);
            ViewBag.nauczycielPrzedmiotID = new SelectList(db.listaNauczycielPrzedmiot, "ID", "ID", zajetoscSalLekcyjnych.nauczycielPrzedmiotID);
            ViewBag.saleLekcyjneID = new SelectList(db.saleLekcyjne, "saleLekcyjneID", "saleLekcyjneID", zajetoscSalLekcyjnych.saleLekcyjneID);
            return View(zajetoscSalLekcyjnych);
        }

        // GET: ZajetoscSalLekcyjnyches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZajetoscSalLekcyjnych zajetoscSalLekcyjnych = db.zajetoscSalLekcyjnych.Find(id);
            if (zajetoscSalLekcyjnych == null)
            {
                return HttpNotFound();
            }
            return View(zajetoscSalLekcyjnych);
        }

        // POST: ZajetoscSalLekcyjnyches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZajetoscSalLekcyjnych zajetoscSalLekcyjnych = db.zajetoscSalLekcyjnych.Find(id);
            db.zajetoscSalLekcyjnych.Remove(zajetoscSalLekcyjnych);
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
