using System;

namespace MVC_DziennikSzkolny.Models
{
    public class Uczen : User
    {
        public DateTime Data_urodzenia { get; set; }
        public int Id_rodzica { get; set; }
        public int Id_klasy { get; set; }
    }
}