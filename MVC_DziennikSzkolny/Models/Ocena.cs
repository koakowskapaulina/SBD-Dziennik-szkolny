using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Ocena
    {
        public int ocenaID { get; set; }
        public DateTime data_wystawienia { get; set; }

        public int UczenID { get; set; }
        public virtual Uczen uczen { get; set; }

        public int nauczycielID { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }

        public int przedmiotID { get; set; }
        public virtual Przedmiot przedmiot { get; set; }


    }
}