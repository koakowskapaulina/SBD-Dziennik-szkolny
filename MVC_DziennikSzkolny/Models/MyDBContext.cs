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

        public DbSet<Klasa> Klasas { get; set; }

        public DbSet<Przedmiot> Przedmioty {get;   set;}

        public DbSet<Ocena> Oceny { get; set; }

        public DbSet<ListaNauczycieliPrzedmiotu> listaNauczycielPrzedmiot { get; set; }

        public DbSet<ListaPrzedmiotowKlasy> listaKlasaPrzedmiot { get; set; }

        public DbSet<Ogloszenie> Ogloszenia { get; set; }
       
        public DbSet<SaleLekcyjne> saleLekcyjne { get; set; }

        public DbSet<ZajetoscSalLekcyjnych> zajetoscSalLekcyjnych { get; set; }
    }
}