namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowaTabelaPNK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID", "dbo.Przedmiots");
            DropIndex("dbo.ListaPrzedmiotowKlasies", new[] { "Przedmiot_przedmiotID" });
            CreateTable(
                "dbo.PrzedmiotNauczycielKlasas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nauczycielID = c.Int(nullable: false),
                        przedmiotID = c.Int(nullable: false),
                        klasaID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Klasas", t => t.klasaID, cascadeDelete: true)
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID, cascadeDelete: true)
                .Index(t => t.nauczycielID)
                .Index(t => t.przedmiotID)
                .Index(t => t.klasaID);
            
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID", c => c.Int());
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.PrzedmiotNauczycielKlasas", "klasaID", "dbo.Klasas");
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "klasaID" });
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "przedmiotID" });
            DropIndex("dbo.PrzedmiotNauczycielKlasas", new[] { "nauczycielID" });
            DropTable("dbo.PrzedmiotNauczycielKlasas");
            CreateIndex("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID");
            AddForeignKey("dbo.ListaPrzedmiotowKlasies", "Przedmiot_przedmiotID", "dbo.Przedmiots", "przedmiotID");
        }
    }
}
