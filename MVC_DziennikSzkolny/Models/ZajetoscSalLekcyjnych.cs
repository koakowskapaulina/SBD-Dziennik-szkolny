using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1,6)]
        public int numerGodzinyLekcyjnej { get; set; }

 
        public int nauczycielPrzedmiotID { get; set; }
        public virtual ListaNauczycieliPrzedmiotu nauczycielPrzedmiot { get; set; }
        

       
        public int klasaID { get; set; }
        public virtual Klasa klasa { get; set; }

     

    }
}