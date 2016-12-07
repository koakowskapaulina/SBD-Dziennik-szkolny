using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class SaleLekcyjne
    {
        public int saleLekcyjneID { get; set; }
        public int numerSali { get; set; }
        public int pietro { get; set; }

        public virtual ICollection<ZajetoscSalLekcyjnych> zajetoscSali { get; set; }
    }
}