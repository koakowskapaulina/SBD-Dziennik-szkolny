namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klasa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klasas",
                c => new
                    {
                        klasaID = c.Int(nullable: false, identity: true),
                        rok_rozpoczecia_toku_ksztalcenia = c.Int(nullable: false),
                        symbol = c.String(),
                        id_wychowawcy = c.Int(nullable: false),
                        wychowaca_nauczycielID = c.Int(),
                    })
                .PrimaryKey(t => t.klasaID)
                .ForeignKey("dbo.Nauczyciels", t => t.wychowaca_nauczycielID)
                .Index(t => t.wychowaca_nauczycielID);
            
            AddColumn("dbo.Uczens", "klasa_klasaID", c => c.Int());
            CreateIndex("dbo.Uczens", "klasa_klasaID");
            AddForeignKey("dbo.Uczens", "klasa_klasaID", "dbo.Klasas", "klasaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Klasas", "wychowaca_nauczycielID", "dbo.Nauczyciels");
            DropForeignKey("dbo.Uczens", "klasa_klasaID", "dbo.Klasas");
            DropIndex("dbo.Klasas", new[] { "wychowaca_nauczycielID" });
            DropIndex("dbo.Uczens", new[] { "klasa_klasaID" });
            DropColumn("dbo.Uczens", "klasa_klasaID");
            DropTable("dbo.Klasas");
        }
    }
}
