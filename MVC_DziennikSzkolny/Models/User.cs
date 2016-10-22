using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class User
    {
        public int id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Nr_telefonu { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        
        public string haslo { get; set; }


        
    }

}