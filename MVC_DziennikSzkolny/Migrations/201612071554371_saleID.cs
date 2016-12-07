namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "salaLekcyjna_saleLekcyjneID", "dbo.SaleLekcyjnes");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "salaLekcyjna_saleLekcyjneID" });
            RenameColumn(table: "dbo.ZajetoscSalLekcyjnyches", name: "salaLekcyjna_saleLekcyjneID", newName: "saleLekcyjneID");
            AlterColumn("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", c => c.Int(nullable: false));
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID");
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", "dbo.SaleLekcyjnes", "saleLekcyjneID", cascadeDelete: true);
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "salaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "salaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", "dbo.SaleLekcyjnes");
            DropIndex("dbo.ZajetoscSalLekcyjnyches", new[] { "saleLekcyjneID" });
            AlterColumn("dbo.ZajetoscSalLekcyjnyches", "saleLekcyjneID", c => c.Int());
            RenameColumn(table: "dbo.ZajetoscSalLekcyjnyches", name: "saleLekcyjneID", newName: "salaLekcyjna_saleLekcyjneID");
            CreateIndex("dbo.ZajetoscSalLekcyjnyches", "salaLekcyjna_saleLekcyjneID");
            AddForeignKey("dbo.ZajetoscSalLekcyjnyches", "salaLekcyjna_saleLekcyjneID", "dbo.SaleLekcyjnes", "saleLekcyjneID");
        }
    }
}
