namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zajetoscSaljeszczeraz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleLekcyjnes",
                c => new
                    {
                        saleLekcyjneID = c.Int(nullable: false, identity: true),
                        numerSali = c.Int(nullable: false),
                        pietro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.saleLekcyjneID);
            
            CreateTable(
                "dbo.ZajetoscSalLekcyjnyches",
                c => new
                    {
                        zajetoscSalLekcyjnychID = c.Int(nullable: false, identity: true),
                        salaID = c.Int(nullable: false),
                        dzienTygodnia = c.Int(nullable: false),
                        poczatek = c.Time(nullable: false, precision: 7),
                        koniec = c.Time(nullable: false, precision: 7),
                        nauczycielID = c.Int(nullable: false),
                        przedmiotID = c.Int(nullable: false),
                        klasaID = c.Int(nullable: false),
                        salaLekcyjna_saleLekcyjneID = c.Int(),
                    })
                .PrimaryKey(t => t.zajetoscSalLekcyjnychID)
                .ForeignKey("dbo.Klasas", t => t.klasaID, cascadeDelete: true)
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.przedmiotID, cascadeDelete: true)
                .ForeignKey("dbo.SaleLekcyjnes", t => t.salaLekcyjna_saleLekcyjneID)
                .Index(t => t.nauczycielID)
                .Index(t => t.przedmiotID)
                .Index(t => t.klasaID)
                .Index(t => t.salaLekcyjna_saleLekcyjneID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "salaLekcyjna_saleLekcyjneID", "dbo.SaleLekcyjnes");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "przedmiotID", "dbo.Przedmiots");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "klasaID", "dbo.Klasas");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "salaLekcyjna_saleLekcyjneID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "klasaID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "przedmiotID" });
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "nauczycielID" });
            DropTable("dbo.ZajetoscSalLekcyjnyches");
            DropTable("dbo.SaleLekcyjnes");
        }
    }
}
