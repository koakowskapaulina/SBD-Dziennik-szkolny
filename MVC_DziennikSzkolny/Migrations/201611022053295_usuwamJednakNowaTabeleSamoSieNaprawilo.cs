namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuwamJednakNowaTabeleSamoSieNaprawilo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "klasaID", "dbo.Klasas");
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "przedmiotID", "dbo.Przedmiots");
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "nauczycielID" });
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "przedmiotID" });
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "klasaID" });
            DropTable("dbo.PrzedmiotNauczycielKlasas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PrzedmiotNauczycielKlasas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nauczycielID = c.Int(nullable: false),
                        przedmiotID = c.Int(nullable: false),
                        klasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.PrzedmiotNauczycielKlasas", "klasaID");
            CreateIndex("dbo.PrzedmiotNauczycielKlasas", "przedmiotID");
            CreateIndex("dbo.PrzedmiotNauczycielKlasas", "nauczycielID");
            AddForeignKey("dbo.PrzedmiotNauczycielKlasas", "przedmiotID", "dbo.Przedmiots", "przedmiotID", cascadeDelete: true);
            AddForeignKey("dbo.PrzedmiotNauczycielKlasas", "nauczycielID", "dbo.Nauczyciels", "nauczycielID", cascadeDelete: true);
            AddForeignKey("dbo.PrzedmiotNauczycielKlasas", "klasaID", "dbo.Klasas", "klasaID", cascadeDelete: true);
        }
    }
}
