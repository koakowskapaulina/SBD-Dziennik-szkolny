namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianagodzinylekcyjnej : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "numerGodzinyLekcyjnej", c => c.Int(nullable: false));
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "poczatek");
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "koniec");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "koniec", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ZajetoscSalLekcyjnyches", "poczatek", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.ZajetoscSalLekcyjnyches", "numerGodzinyLekcyjnej");
        }
    }
}
