using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class ZajetoscSalLekcyjnych
    {
        public int zajetoscSalLekcyjnychID { get; set; }

        public int saleLekcyjneID { get; set; }
         public virtual SaleLekcyjne salaLekcyjna { get; set; }

        
        public DayOfWeek dzienTygodnia { get; set; }
        public TimeSpan poczatek { get; set; }
        public TimeSpan koniec { get; set; }

       
        public int nauczycielPrzedmiotID { get; set; }
        public virtual ListaNauczycieliPrzedmiotu nauczycielPrzedmiot { get; set; }
        

       
        public int klasaID { get; set; }
        public virtual Klasa klasa { get; set; }

     

    }
}