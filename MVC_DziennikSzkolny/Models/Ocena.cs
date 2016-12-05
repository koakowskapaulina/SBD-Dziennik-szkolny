using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Ocena
    {
        public int ocenaID { get; set; }

        [DataType(DataType.DateTime)][Required]
        public DateTime data_wystawienia { get; set; }

        [Required]
        public int uczenID { get; set; }
        public virtual Uczen uczen { get; set; }

        [Required]
        public int nauczycielID { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }

        [Required]
        public int przedmiotID { get; set; }
        public virtual Przedmiot przedmiot { get; set; }

        [Required]
        public double wartosc { get; set; }
        [Required]
        public string opis { get; set; }

        public String ToString()
        {
           
            return  uczen.Nazwisko + " " + wartosc;
        }
    }
}