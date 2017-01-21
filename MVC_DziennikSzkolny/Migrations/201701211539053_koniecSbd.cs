namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class koniecSbd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "klasaID", "dbo.Klasas");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID", "dbo.ListaNauczycieliPrzedmiotus");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", "dbo.SaleLekcyjnes");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "saleLekcyjneID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "nauczycielPrzedmiotID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "klasaID" });
            DropTable("dbo.SaleLekcyjnes");
            DropTable("dbo.ZajetoscSalLekcyjnyches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZajetoscSalLekcyjnyches",
                c => new
                    {
                        zajetoscSalLekcyjnychID = c.Int(nullable: false, identity: true),
                        saleLekcyjneID = c.Int(nullable: false),
                        dzienTygodnia = c.Int(nullable: false),
                        numerGodzinyLekcyjnej = c.Int(nullable: false),
                        nauczycielPrzedmiotID = c.Int(nullable: false),
                        klasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.zajetoscSalLekcyjnychID);
            
            CreateTable(
                "dbo.SaleLekcyjnes",
                c => new
                    {
                        saleLekcyjneID = c.Int(nullable: false, identity: true),
                        numerSali = c.Int(nullable: false),
                        pietro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.saleLekcyjneID);
            
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "klasaID");
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID");
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID");
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", "dbo.SaleLekcyjnes", "saleLekcyjneID", cascadeDelete: true);
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielPrzedmiotID", "dbo.ListaNauczycieliPrzedmiotus", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "klasaID", "dbo.Klasas", "klasaID", cascadeDelete: true);
        }
    }
}
