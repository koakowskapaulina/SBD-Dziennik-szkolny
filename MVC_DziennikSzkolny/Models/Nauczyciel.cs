using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Nauczyciel : User
    {
        public int nauczycielID { get; set; }

        public virtual ICollection<Klasa> Klasas { get; set; }
    //    public virtual Klasa klasa { get; set; }
    }
}