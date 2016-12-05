using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class User
    {
     
        [MinLength(2)][Required]
        public string Imie { get; set; }
        [MinLength(2)]   [Required]
        public string Nazwisko { get; set; }
        [StringLength(11)] [Required]
        public string Pesel { get; set; }

        [StringLength(9)]      [Required]
        [DataType(DataType.PhoneNumber)]
        public string Nr_telefonu { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string haslo { get; set; }


        
    }
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string haslo { get; set; }


    }
    public class RegisterViewModel
    {
        [MinLength(2)]
        [Required]
        public string Imie { get; set; }
        [MinLength(2)]
        [Required]
        public string Nazwisko { get; set; }
        [StringLength(11)]
        [Required]
        public string Pesel { get; set; }

        [StringLength(9)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Nr_telefonu { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string haslo { get; set; }

    }



}