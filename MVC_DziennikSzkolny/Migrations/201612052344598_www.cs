namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class www : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ocenas", "opis", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ocenas", "opis", c => c.String());
        }
    }
}
