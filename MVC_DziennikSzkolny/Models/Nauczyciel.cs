using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Nauczyciel : User
    {
        public int nauczycielID { get; set; }


        //  public int klasaID { get; set; }
      //  [ForeignKey("Klasa")]
        public virtual ICollection<Klasa> klasa { get; set; } //tu miała być jedna klasa wychowawcy ale DB nie chciała wspolpracowac przy relacji 1-1

        public virtual ICollection<Ocena> oceny { get; set; }

           public virtual ICollection<ListaNauczycieliPrzedmiotu> przedmioty { get; set; }

        public virtual ICollection<Ogloszenie> ogloszenia { get; set; }
    }
}