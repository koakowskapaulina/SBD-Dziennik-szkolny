using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Klasa
    {
        public int klasaID { get; set; }

        // [Range(2010, 2020)]
      
            [Display(Name ="Rok rozpoczęcia")]
        public int rok_rozpoczecia_toku_ksztalcenia { get; set; }
        public String symbol { get; set; }

        public virtual ICollection<Uczen> uczens { get; set; }
        public int nauczycielID { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }//wychowawca!

         public virtual ICollection<ListaPrzedmiotowKlasy> przedmioty { get; set; }
        public virtual ICollection<Ogloszenie> ogloszenia { get; set; }


    }
}