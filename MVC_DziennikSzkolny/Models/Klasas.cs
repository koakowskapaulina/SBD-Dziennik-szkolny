//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_DziennikSzkolny.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klasas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klasas()
        {
            this.ListaPrzedmiotowKlasies = new HashSet<ListaPrzedmiotowKlasies>();
            this.Ogloszenies = new HashSet<Ogloszenies>();
            this.Uczens = new HashSet<Uczens>();
            this.ZajetoscSalLekcyjnyches = new HashSet<ZajetoscSalLekcyjnyches>();
        }
    
        public int klasaID { get; set; }
        public int rok_rozpoczecia_toku_ksztalcenia { get; set; }
        public string symbol { get; set; }
        public Nullable<int> nauczycielID { get; set; }
    
        public virtual Nauczyciels Nauczyciels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaPrzedmiotowKlasies> ListaPrzedmiotowKlasies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogloszenies> Ogloszenies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uczens> Uczens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZajetoscSalLekcyjnyches> ZajetoscSalLekcyjnyches { get; set; }
    }
}
