namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanieOgloszenia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogloszenies",
                c => new
                    {
                        ogloszenieID = c.Int(nullable: false, identity: true),
                        temat = c.String(nullable: false),
                        tresc = c.String(nullable: false),
                        data_wystawienia = c.DateTime(nullable: false),
                        nauczycielID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ogloszenieID)
                .ForeignKey("dbo.Nauczyciels", t => t.nauczycielID, cascadeDelete: true)
                .Index(t => t.nauczycielID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogloszenies", "nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.Ogloszenies", new[] { "nauczycielID" });
            DropTable("dbo.Ogloszenies");
        }
    }
}
