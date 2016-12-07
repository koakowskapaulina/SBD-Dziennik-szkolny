using MVC_DziennikSzkolny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class UserController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: User
        public ActionResult Logowanie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logowanie([Bind(Include = "email,haslo")] LoginViewModel u)
        {
            if (ModelState.IsValid)
            {
                if(u.email.Equals("admin@admin.com") && u.haslo.Equals("12345Admin"))

                {
                    HttpCookie cookie1;
                    cookie1 = new HttpCookie("zalogowanyID");
                    cookie1.Expires = DateTime.Now.AddSeconds(600);
                    cookie1.Value = "admin";
                    Response.Cookies.Add(cookie1);

                    HttpCookie cookie2;
                    cookie2 = new HttpCookie("zalogowanyRola");
                    cookie2.Expires = DateTime.Now.AddSeconds(600);
                    cookie2.Value = "admin";
                    Response.Cookies.Add(cookie2);

                    return RedirectToAction("Panel", "Admin");
                }
                Uczen zalogowanyUczen;
                if (db.Uczniowie.Where(a => a.email == u.email).Any())
                    zalogowanyUczen = db.Uczniowie.Where(a => a.email == u.email).First();
                else zalogowanyUczen = null;
                if (zalogowanyUczen != null && zalogowanyUczen.haslo.Equals(u.haslo))
                {
                    HttpCookie cookie1;
                    cookie1 = new HttpCookie("zalogowanyID");
                    cookie1.Expires = DateTime.Now.AddSeconds(600);
                    cookie1.Value = zalogowanyUczen.uczenID.ToString();
                    Response.Cookies.Add(cookie1);

                    HttpCookie cookie2;
                    cookie2 = new HttpCookie("zalogowanyRola");
                    cookie2.Expires = DateTime.Now.AddSeconds(600);
                    cookie2.Value = "uczen";
                    Response.Cookies.Add(cookie2);

                    return RedirectToAction("Panel", "Uczen");
                }
                else
                {
                    Rodzic zalogowanyRodzic;
                    if (db.Rodzice.Where(a => a.email == u.email).Any())
                        zalogowanyRodzic = db.Rodzice.Where(a => a.email == u.email).First();
                    else zalogowanyRodzic = null;
                    
                    if (zalogowanyRodzic != null && zalogowanyRodzic.haslo.Equals(u.haslo))
                    {
                        HttpCookie cookie1;
                        cookie1 = new HttpCookie("zalogowanyID");
                        cookie1.Expires = DateTime.Now.AddSeconds(600);
                        cookie1.Value = zalogowanyRodzic.rodzicID.ToString();
                        Response.Cookies.Add(cookie1);

                        HttpCookie cookie2;
                        cookie2 = new HttpCookie("zalogowanyRola");
                        cookie2.Expires = DateTime.Now.AddSeconds(600);
                        cookie2.Value = "rodzic";
                        Response.Cookies.Add(cookie2);

                        return RedirectToAction("Panel", "Rodzic");
                    }
                   else
                    {
                        Nauczyciel zalogowanyNauczyciel;
                        if (db.Nauczyciele.Where(a => a.email == u.email).Any())
                            zalogowanyNauczyciel = db.Nauczyciele.Where(a => a.email == u.email).First();
                        else zalogowanyNauczyciel = null;

                      
                        if (zalogowanyNauczyciel != null && zalogowanyNauczyciel.haslo.Equals(u.haslo))
                        {
                            HttpCookie cookie1;
                            cookie1 = new HttpCookie("zalogowanyID");
                            cookie1.Expires = DateTime.Now.AddSeconds(600);
                            cookie1.Value = zalogowanyNauczyciel.nauczycielID.ToString();
                            Response.Cookies.Add(cookie1);

                            HttpCookie cookie2;
                            cookie2 = new HttpCookie("zalogowanyRola");
                            cookie2.Expires = DateTime.Now.AddSeconds(600);
                            cookie2.Value = "nauczyciel";
                            Response.Cookies.Add(cookie2);

                            return RedirectToAction("Panel", "Nauczyciel");
                        }
                        else
                        {
                            ViewBag.Message = "Niepoprawny email/hasło";

                            return View();
                        }
                    }
                }
                
                

            }
            else
            {
                //ViewBag.Message = "not isValid ";
                return View();
            }
        }

        public ActionResult Wylogowanie()
        {
            HttpCookie cookie1;
            cookie1 = new HttpCookie("zalogowanyID");
            cookie1.Expires = DateTime.Now.AddYears(-10);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2;
            cookie2 = new HttpCookie("zalogowanyRola");
            cookie2.Expires = DateTime.Now.AddYears(-10);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Index","Home");
        }
    }
}