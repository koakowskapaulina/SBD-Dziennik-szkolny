namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweTab : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID, cascadeDelete: true)
                .ForeignKey("dbo.Uczens", t => t.uczenID, cascadeDelete: false)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ocenas", "uczenID", "dbo.Uczens");
            DropForeignKey("dbo.Ocenas", "przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.Ocenas", "nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.Ocenas", new[] { "przedmiotID" });
            DropIndex("dbo.Ocenas", new[] { "nauczycielID" });
            DropIndex("dbo.Ocenas", new[] { "uczenID" });
            DropTable("dbo.Przedmiots");
            DropTable("dbo.Ocenas");
        }
    }
}
