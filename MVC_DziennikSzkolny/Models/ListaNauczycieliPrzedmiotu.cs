using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class ListaNauczycieliPrzedmiotu
    {
        public int ID { get; set; }

        public int nauczycielID { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }

        public int przedmiotID { get; set; }
        public virtual Przedmiot przedmiot { get; set; }

        public String ToString()
        {
            return nauczyciel.Nazwisko + " " + nauczyciel.Imie + " " + przedmiot.nazwa;

        }

    }
}