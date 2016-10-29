namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klasas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nauczyciels", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Nauczyciels", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Nauczyciels", "Pesel", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Nauczyciels", "Nr_telefonu", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Rodzics", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Rodzics", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Rodzics", "Pesel", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Rodzics", "Nr_telefonu", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Uczens", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Uczens", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Uczens", "Pesel", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Uczens", "Nr_telefonu", c => c.String(nullable: false, maxLength: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uczens", "Nr_telefonu", c => c.String());
            AlterColumn("dbo.Uczens", "Pesel", c => c.String());
            AlterColumn("dbo.Uczens", "Nazwisko", c => c.String());
            AlterColumn("dbo.Uczens", "Imie", c => c.String());
            AlterColumn("dbo.Rodzics", "Nr_telefonu", c => c.String());
            AlterColumn("dbo.Rodzics", "Pesel", c => c.String());
            AlterColumn("dbo.Rodzics", "Nazwisko", c => c.String());
            AlterColumn("dbo.Rodzics", "Imie", c => c.String());
            AlterColumn("dbo.Nauczyciels", "Nr_telefonu", c => c.String());
            AlterColumn("dbo.Nauczyciels", "Pesel", c => c.String());
            AlterColumn("dbo.Nauczyciels", "Nazwisko", c => c.String());
            AlterColumn("dbo.Nauczyciels", "Imie", c => c.String());
        }
    }
}
