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

            
            Uczen uczen = db.Uczniowie.Find(Int32.Parse(Request.Cookies["zalogowanyID"].Value));
                return View(uczen);
           
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