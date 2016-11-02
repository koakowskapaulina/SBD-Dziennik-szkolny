namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nauczycielPrzedmiot : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "ListaNauczycieliPrzedmiotuID", "dbo.ListaNauczycieliPrzedmiotus");
            DropIndex("dbo.ListaPrzedmiotowKlasies", new[] { "Przedmiot_przedmiotID" });
            DropIndex("dbo.ListaPrzedmiotowKlasies", new[] { "ListaNauczycieliPrzedmiotuID" });
            AlterColumn("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID", c => c.Int(nullable: false));
            DropColumn("dbo.ListaPrzedmiotowKlasies", "ListaNauczycieliPrzedmiotuID");
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "Przedmiot_przedmiotID", newName: "przedmiotID");
            CreateIndex("dbo.ListaPrzedmiotowKlasies", "przedmiotID");
            AddForeignKey("dbo.ListaPrzedmiotowKlasies", "przedmiotID", "dbo.Przedmiots", "przedmiotID", cascadeDelete: true);
        }
    }
}
