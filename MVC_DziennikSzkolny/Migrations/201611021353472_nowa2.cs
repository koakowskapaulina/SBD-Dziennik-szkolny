namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Nauczyciels",
             c => new
             {
                 nauczycielID = c.Int(nullable: false, identity: true),
                 Imie = c.String(nullable: false),
                 Nazwisko = c.String(nullable: false),
                 Pesel = c.String(nullable: false, maxLength: 11),
                 Nr_telefonu = c.String(nullable: false, maxLength: 9),
                 email = c.String(nullable: false),
                 haslo = c.String(nullable: false),

             })
             .PrimaryKey(t => t.nauczycielID);
           

            CreateTable(
                "dbo.Rodzics",
                c => new
                {
                    rodzicID = c.Int(nullable: false, identity: true),
                    Imie = c.String(nullable: false),
                    Nazwisko = c.String(nullable: false),
                    Pesel = c.String(nullable: false, maxLength: 11),
                    Nr_telefonu = c.String(nullable: false, maxLength:9),
                    email = c.String(nullable: false),
                    haslo = c.String(nullable: false),
                })
                .PrimaryKey(t => t.rodzicID);

            CreateTable(
                "dbo.Uczens",
                c => new
                {
                    uczenID = c.Int(nullable: false, identity: true),

                    Imie = c.String(nullable: false),
                    Nazwisko = c.String(nullable: false),
                    Pesel = c.String(nullable: false, maxLength: 11),
                    Nr_telefonu = c.String(nullable: false, maxLength:

9),
                    email = c.String(nullable: false),
                    haslo = c.String(nullable: false),

                    Data_urodzenia = c.DateTime(nullable: false),

                    rodzic_rodzicID = c.Int(),
                    klasa_klasaID = c.Int(),
                })
                .PrimaryKey(t => t.uczenID)
                .ForeignKey("dbo.Rodzics", t => t.rodzic_rodzicID,

cascadeDelete: false)
                .Index(t => t.rodzic_rodzicID)
                .ForeignKey("dbo.Klasas", t => t.klasa_klasaID,

cascadeDelete: false)
                .Index(t => t.klasa_klasaID);

            CreateTable(
               "dbo.Klasas",
               c => new
               {
                   klasaID = c.Int(nullable: false, identity: true),
                   rok_rozpoczecia_toku_ksztalcenia = c.Int(nullable:

false),
                   symbol = c.String(),
                   nauczycielID = c.Int(),

               })
               .PrimaryKey(t => t.klasaID)
               .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID,

cascadeDelete: false)
               .Index(t => t.nauczycielID);






            CreateTable(
               "dbo.Ocenas",
               c => new
               {
                   ocenaID = c.Int(nullable: false, identity: true),
                   data_wystawienia = c.DateTime(nullable: false),
                   uczenID = c.Int(nullable: false),
                   nauczycielID = c.Int(nullable: false),
                   przedmiotID = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.ocenaID)
               .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID,

cascadeDelete: true)
               .ForeignKey("dbo.Przedmiots", t => t.przedmiotID,

cascadeDelete: true)
               .ForeignKey("dbo.Uczens", t => t.uczenID, cascadeDelete:

true)
               .Index(t => t.uczenID)
               .Index(t => t.nauczycielID)
               .Index(t => t.przedmiotID);

            CreateTable(
                "dbo.Przedmiots",
                c => new
                {
                    przedmiotID = c.Int(nullable: false, identity: true),
                    nazwa = c.String(),
                })
                .PrimaryKey(t => t.przedmiotID);




            CreateTable(
               "dbo.ListaPrzedmiotowKlasies",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   klasaID = c.Int(nullable: false),
                   nauczycielPrzedmiotID = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.ID)
               .ForeignKey("dbo.Klasas", t => t.klasaID, cascadeDelete:

true)
               .ForeignKey("dbo.ListaNauczycieliPrzedmiotus", t =>

t.nauczycielPrzedmiotID, cascadeDelete: true)
               .Index(t => t.klasaID)
               .Index(t => t.nauczycielPrzedmiotID);

            CreateTable(
                "dbo.ListaNauczycieliPrzedmiotus",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    nauczycielID = c.Int(nullable: false),
                    przedmiotID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID,

cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID,

cascadeDelete: true)
                .Index(t => t.nauczycielID)
                .Index(t => t.przedmiotID);


        }

        public override void Down()
        {
            AddColumn("dbo.ListaNauczycieliPrzedmiotus", "nauczycielPrzedmiotID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ListaPrzedmiotowKlasies", "listaPrzedmiotowKlasyID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "nauczycielPrzedmiotID", "dbo.ListaNauczycieliPrzedmiotus");
            DropIndex("dbo.Ocenas", new[] { "uczenID" });
            DropPrimaryKey("dbo.ListaNauczycieliPrzedmiotus");
            DropPrimaryKey("dbo.ListaPrzedmiotowKlasies");
            DropColumn("dbo.ListaNauczycieliPrzedmiotus", "ID");
            DropColumn("dbo.ListaPrzedmiotowKlasies", "ID");
            AddPrimaryKey("dbo.ListaNauczycieliPrzedmiotus", "nauczycielPrzedmiotID");
            AddPrimaryKey("dbo.ListaPrzedmiotowKlasies", "listaPrzedmiotowKlasyID");
            RenameIndex(table: "dbo.ListaPrzedmiotowKlasies", name: "IX_nauczycielPrzedmiotID", newName: "IX_ListaNauczycieliPrzedmiotuID");
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "nauczycielPrzedmiotID", newName: "ListaNauczycieliPrzedmiotuID");
            CreateIndex("dbo.Ocenas", "UczenID");
            AddForeignKey("dbo.ListaPrzedmiotowKlasies", "ListaNauczycieliPrzedmiotuID", "dbo.ListaNauczycieliPrzedmiotus", "nauczycielPrzedmiotID", cascadeDelete: true);
        }
    }
}
