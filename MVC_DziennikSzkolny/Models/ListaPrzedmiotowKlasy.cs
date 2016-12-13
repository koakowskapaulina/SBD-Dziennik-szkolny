using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class ListaPrzedmiotowKlasy
    {
        public int ID { get; set; }
        public int klasaID { get; set; }
        public virtual Klasa klasa { get; set; }

       
        public int nauczycielPrzedmiotID { get; set; }
        public virtual ListaNauczycieliPrzedmiotu nauczycielPrzedmiot { get; set; }

      
    }
}