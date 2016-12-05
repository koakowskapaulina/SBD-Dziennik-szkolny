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
    public class UczenController : Controller
    {
        private MyDBContext db = new MyDBContext();


        // GET: Uczen
        public ActionResult Panel()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
            {
                return Redirect("BrakUprawnien");
            }

            return View();
        }
        public ActionResult Profil()
        {
            //TODO: możliwość zmiany e-maila i hasła,telefonu

            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
            {
                return Redirect("BrakUprawnien");
            }

            Uczen uczen = db.Uczniowie.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
                return View(uczen);
            
               
        }
        public ActionResult Oceny()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
            {
                return Redirect("BrakUprawnien");
            }

            //TODO:
            Uczen uczen = db.Uczniowie.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
                return View();
           
        }
        public ActionResult Przedmioty()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
            {
                return Redirect("BrakUprawnien");
            }


            Uczen uczen = db.Uczniowie.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
                return View(uczen);
          
        }



        // GET:
        public ActionResult EditProfil()
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
            {
                return Redirect("BrakUprawnien");
            }



            Uczen uczen = db.Uczniowie.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);

            return View(uczen);
           
           
        }

        // POST: 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfil([Bind(Include = "uczenID,Data_urodzenia,rodzicID,klasaID,Imie,Nazwisko,Pesel,Nr_telefonu,email,haslo")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profil");
            }
            ViewBag.klasaID = new SelectList(db.Klasas, "klasaID", "symbol", uczen.klasaID);
            ViewBag.rodzicID = new SelectList(db.Rodzice, "rodzicID", "Imie", uczen.rodzicID);

            return View(uczen);
        }
        public ActionResult DetailsPrzedmiot(int? id)
        {
            if (Request.Cookies["zalogowanyID"] == null)
            {
                return RedirectToAction("Logowanie", "User");
            }
            if (!Request.Cookies["zalogowanyRola"].Value.Equals("uczen"))
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
        public ActionResult BrakUprawnien()
        {
            return View();
        }

    }
}