using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_DziennikSzkolny.Models
{
    public class Uczen : User
    {
        public int uczenID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_urodzenia { get; set; }

        public int rodzicID { get; set; }
        public virtual Rodzic rodzic { get; set; }

        public int klasaID { get; set; }
       public virtual Klasa klasa { get; set; }

        public virtual ICollection<Ocena> oceny { get; set; }
    }
    

}