using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DziennikSzkolny.Controllers
{
    public class NauczycielController : Controller
    {
        // GET: Nauczyciel
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult Oceny()
        {
            //TODO: możliwość przejrzenia wystawionych przez nauczyciela LUB w przypadku wychowawcy wszystkich ocen swojej klasy
            return View();
        }
        public ActionResult WystawOceny()
        {
            //TODO : możliwości wystawienia jednej lub kilku ocen na raz: (1. wybór przedmiotu(o ile nauczyciel uczy więcej niż 1) 2. wybór klasy 3.wybór ucznia)
            
            return View();
        }
        public ActionResult Wiadomosci()
        {
            return View();
        }
        public ActionResult Ogloszenia()
        {
            return View();
        }
        public ActionResult Przedmioty()
        {
            //TODO : mozliwosc dodawania treści, plików i tworzenia testow
            return View();
        }
    }
}