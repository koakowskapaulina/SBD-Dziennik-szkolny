using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Przedmiot
    {
        public int przedmiotID { get; set; }
        public String nazwa { get; set;}

        public virtual ICollection<Ocena> oceny { get; set; }

        //    public virtual ICollection<ListaPrzedmiotowKlasy> klasy { get; set; }

         public virtual ICollection<ListaNauczycieliPrzedmiotu> nauczyciele { get; set; }
       

    }
}