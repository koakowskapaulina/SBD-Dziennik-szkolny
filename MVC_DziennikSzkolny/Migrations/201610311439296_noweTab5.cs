namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweTab5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrzedmiotKlasas", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.PrzedmiotKlasas", "Klasa_klasaID", "dbo.Klasas");
            DropForeignKey("dbo.PrzedmiotNauczyciels", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.PrzedmiotNauczyciels", "Nauczyciel_nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.PrzedmiotKlasas", new[] { "Przedmiot_przedmiotID" });
            DropIndex("dbo.PrzedmiotKlasas", new[] { "Klasa_klasaID" });
            DropIndex("dbo.PrzedmiotNauczyciels", new[] { "Przedmiot_przedmiotID" });
            DropIndex("dbo.PrzedmiotNauczyciels", new[] { "Nauczyciel_nauczycielID" });
            AddColumn("dbo.Przedmiots", "Nauczyciel_nauczycielID", c => c.Int());
            CreateIndex("dbo.Przedmiots", "Nauczyciel_nauczycielID");
            AddForeignKey("dbo.Przedmiots", "Nauczyciel_nauczycielID", "dbo.Nauczyciels", "nauczycielID");
            DropTable("dbo.PrzedmiotKlasas");
            DropTable("dbo.PrzedmiotNauczyciels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PrzedmiotNauczyciels",
                c => new
                    {
                        Przedmiot_przedmiotID = c.Int(nullable: false),
                        Nauczyciel_nauczycielID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Przedmiot_przedmiotID, t.Nauczyciel_nauczycielID });
            
            CreateTable(
                "dbo.PrzedmiotKlasas",
                c => new
                    {
                        Przedmiot_przedmiotID = c.Int(nullable: false),
                        Klasa_klasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Przedmiot_przedmiotID, t.Klasa_klasaID });
            
            DropForeignKey("dbo.Przedmiots", "Nauczyciel_nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.Przedmiots", new[] { "Nauczyciel_nauczycielID" });
            DropColumn("dbo.Przedmiots", "Nauczyciel_nauczycielID");
            CreateIndex("dbo.PrzedmiotNauczyciels", "Nauczyciel_nauczycielID");
            CreateIndex("dbo.PrzedmiotNauczyciels", "Przedmiot_przedmiotID");
            CreateIndex("dbo.PrzedmiotKlasas", "Klasa_klasaID");
            CreateIndex("dbo.PrzedmiotKlasas", "Przedmiot_przedmiotID");
            AddForeignKey("dbo.PrzedmiotNauczyciels", "Nauczyciel_nauczycielID", "dbo.Nauczyciels", "nauczycielID", cascadeDelete: true);
            AddForeignKey("dbo.PrzedmiotNauczyciels", "Przedmiot_przedmiotID", "dbo.Przedmiots", "przedmiotID", cascadeDelete: true);
            AddForeignKey("dbo.PrzedmiotKlasas", "Klasa_klasaID", "dbo.Klasas", "klasaID", cascadeDelete: true);
            AddForeignKey("dbo.PrzedmiotKlasas", "Przedmiot_przedmiotID", "dbo.Przedmiots", "przedmiotID", cascadeDelete: true);
        }
    }
}
