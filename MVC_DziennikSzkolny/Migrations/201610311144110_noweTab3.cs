namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweTab3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaPrzedmiotowKlasies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        klasaID = c.Int(nullable: false),
                        przedmiotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Klasas", t => t.klasaID, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID, cascadeDelete: true)
                .Index(t => t.klasaID)
                .Index(t => t.przedmiotID);
            
            CreateTable(
                "dbo.ListaNauczycieliPrzedmiotus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nauczycielID = c.Int(nullable: false),
                        przedmiotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID, cascadeDelete: true)
                .Index(t => t.nauczycielID)
                .Index(t => t.przedmiotID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListaNauczycieliPrzedmiotus", "przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.ListaNauczycieliPrzedmiotus", "nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "klasaID", "dbo.Klasas");
            DropIndex("dbo.ListaNauczycieliPrzedmiotus", new[] { "przedmiotID" });
            DropIndex("dbo.ListaNauczycieliPrzedmiotus", new[] { "nauczycielID" });
            DropIndex("dbo.ListaPrzedmiotowKlasies", new[] { "przedmiotID" });
            DropIndex("dbo.ListaPrzedmiotowKlasies", new[] { "klasaID" });
            DropTable("dbo.ListaNauczycieliPrzedmiotus");
            DropTable("dbo.ListaPrzedmiotowKlasies");
        }
    }
}
