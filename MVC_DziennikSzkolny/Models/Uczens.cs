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
    
    public partial class Uczens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uczens()
        {
            this.Ocenas = new HashSet<Ocenas>();
        }
    
        public int uczenID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Nr_telefonu { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public System.DateTime Data_urodzenia { get; set; }
        public Nullable<int> rodzicID { get; set; }
        public Nullable<int> klasaID { get; set; }
    
        public virtual Klasas Klasas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocenas> Ocenas { get; set; }
        public virtual Rodzics Rodzics { get; set; }
    }
}
