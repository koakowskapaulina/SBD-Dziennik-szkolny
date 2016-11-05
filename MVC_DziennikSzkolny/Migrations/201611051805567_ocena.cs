namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ocena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ocenas", "wartosc", c => c.Double(nullable: false));
            AddColumn("dbo.Ocenas", "opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ocenas", "opis");
            DropColumn("dbo.Ocenas", "wartosc");
        }
    }
}
