using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyDB") { }

        public DbSet<Uczen> Uczniowie { get; set; }

        public DbSet<Rodzic> Rodzice { get; set; }

        public DbSet<Nauczyciel> Nauczyciele { get; set; }

        public System.Data.Entity.DbSet<MVC_DziennikSzkolny.Models.Klasa> Klasas { get; set; }
    }
}