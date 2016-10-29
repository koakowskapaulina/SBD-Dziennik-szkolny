namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nazwa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nauczyciels",
                c => new
                    {
                        nauczycielID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        Nr_telefonu = c.String(),
                        email = c.String(nullable: false),
                        haslo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.nauczycielID);
            
            CreateTable(
                "dbo.Rodzics",
                c => new
                    {
                        rodzicID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        Nr_telefonu = c.String(),
                        email = c.String(nullable: false),
                        haslo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.rodzicID);
            
            CreateTable(
                "dbo.Uczens",
                c => new
                    {
                        uczenID = c.Int(nullable: false, identity: true),
                        Data_urodzenia = c.DateTime(nullable: false),
                        Id_rodzica = c.Int(nullable: false),
                        Id_klasy = c.Int(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        Nr_telefonu = c.String(),
                        email = c.String(nullable: false),
                        haslo = c.String(nullable: false),
                        rodzic_rodzicID = c.Int(),
                    })
                .PrimaryKey(t => t.uczenID)
                .ForeignKey("dbo.Rodzics", t => t.rodzic_rodzicID)
                .Index(t => t.rodzic_rodzicID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uczens", "rodzic_rodzicID", "dbo.Rodzics");
            DropIndex("dbo.Uczens", new[] { "rodzic_rodzicID" });
            DropTable("dbo.Uczens");
            DropTable("dbo.Rodzics");
            DropTable("dbo.Nauczyciels");
        }
    }
}
