namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweTab4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrzedmiotKlasas",
                c => new
                    {
                        Przedmiot_przedmiotID = c.Int(nullable: false),
                        Klasa_klasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Przedmiot_przedmiotID, t.Klasa_klasaID })
                .ForeignKey("dbo.Przedmiots", t => t.Przedmiot_przedmiotID, cascadeDelete: true)
                .ForeignKey("dbo.Klasas", t => t.Klasa_klasaID, cascadeDelete: true)
                .Index(t => t.Przedmiot_przedmiotID)
                .Index(t => t.Klasa_klasaID);
            
            CreateTable(
                "dbo.PrzedmiotNauczyciels",
                c => new
                    {
                        Przedmiot_przedmiotID = c.Int(nullable: false),
                        Nauczyciel_nauczycielID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Przedmiot_przedmiotID, t.Nauczyciel_nauczycielID })
                .ForeignKey("dbo.Przedmiots", t => t.Przedmiot_przedmiotID, cascadeDelete: true)
                .ForeignKey("dbo.Nauczyciels", t => t.Nauczyciel_nauczycielID, cascadeDelete: true)
                .Index(t => t.Przedmiot_przedmiotID)
                .Index(t => t.Nauczyciel_nauczycielID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrzedmiotNauczyciels", "Nauczyciel_nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.PrzedmiotNauczyciels", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.PrzedmiotKlasas", "Klasa_klasaID", "dbo.Klasas");
            DropForeignKey("dbo.PrzedmiotKlasas", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropIndex("dbo.PrzedmiotNauczyciels", new[] { "Nauczyciel_nauczycielID" });
            DropIndex("dbo.PrzedmiotNauczyciels", new[] { "Przedmiot_przedmiotID" });
            DropIndex("dbo.PrzedmiotKlasas", new[] { "Klasa_klasaID" });
            DropIndex("dbo.PrzedmiotKlasas", new[] { "Przedmiot_przedmiotID" });
            DropTable("dbo.PrzedmiotNauczyciels");
            DropTable("dbo.PrzedmiotKlasas");
        }
    }
}
