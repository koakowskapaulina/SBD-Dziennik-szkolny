namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawkaNauczycielPrzedmiot : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "przedmiotID", "dbo.Przedmiots");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "nauczycielID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "przedmiotID" });
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID", c => c.Int(nullable: false));
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID");
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID", "dbo.ListaNauczycieliPrzedmiotus", "ID", cascadeDelete: true);
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "nauczycielID");
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "przedmiotID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "przedmiotID", c => c.Int(nullable: false));
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "nauczycielID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID", "dbo.ListaNauczycieliPrzedmiotus");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "nauczycielPrzedmiotID" });
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID");
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "przedmiotID");
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "nauczycielID");
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "przedmiotID", "dbo.Przedmiots", "przedmiotID", cascadeDelete: true);
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielID", "dbo.Nauczyciels", "nauczycielID", cascadeDelete: true);
        }
    }
}
