using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Ogloszenie
    {
        //nauczyciel wysyła ogłoszenia dla rodziców dzieci których uczy

        public int ogloszenieID { get; set; }
        [Required]
        public String temat { get; set; }
        [Required]
        public String tresc { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime data_wystawienia { get; set; }
        //wystawione przez:
        public int nauczycielID { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }

        public int klasaID { get; set; }
        public virtual Klasa klasa { get; set; }


    }
}