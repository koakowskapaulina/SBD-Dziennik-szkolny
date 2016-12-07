namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coskrzyczy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogloszenies", "klasaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ogloszenies", "klasaID");
            AddForeignKey("dbo.Ogloszenies", "klasaID", "dbo.Klasas", "klasaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogloszenies", "klasaID", "dbo.Klasas");
            DropIndex("dbo.Ogloszenies", new[] { "klasaID" });
            DropColumn("dbo.Ogloszenies", "klasaID");
        }
    }
}
