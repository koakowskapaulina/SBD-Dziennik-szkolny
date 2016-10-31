namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweTab6 : DbMigration
    {
        public override void Up()
        {
         
        }
        
        public override void Down()
        {
            AddColumn("dbo.Przedmiots", "Nauczyciel_nauczycielID", c => c.Int());
            DropForeignKey("dbo.ListaNauczycieliPrzedmiotus", "nauczycielID", "dbo.Nauczyciels");
            RenameColumn(table: "dbo.ListaNauczycieliPrzedmiotus", name: "nauczycielID", newName: "Nauczyciel_nauczycielID");
            AddColumn("dbo.ListaNauczycieliPrzedmiotus", "nauczycielID", c => c.Int(nullable: false));
            CreateIndex("dbo.Przedmiots", "Nauczyciel_nauczycielID");
            AddForeignKey("dbo.Przedmiots", "Nauczyciel_nauczycielID", "dbo.Nauczyciels", "nauczycielID");
        }
    }
}
