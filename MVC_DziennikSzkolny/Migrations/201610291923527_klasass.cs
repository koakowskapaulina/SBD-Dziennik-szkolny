namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klasass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Klasas", "wychowaca_nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.Klasas", new[] { "wychowaca_nauczycielID" });
            RenameColumn(table: "dbo.Klasas", name: "wychowaca_nauczycielID", newName: "nauczycielID");
            AlterColumn("dbo.Klasas", "nauczycielID", c => c.Int(nullable: false));
            CreateIndex("dbo.Klasas", "nauczycielID");
            AddForeignKey("dbo.Klasas", "nauczycielID", "dbo.Nauczyciels", "nauczycielID", cascadeDelete: true);
            DropColumn("dbo.Klasas", "id_wychowawcy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Klasas", "id_wychowawcy", c => c.Int(nullable: false));
            DropForeignKey("dbo.Klasas", "nauczycielID", "dbo.Nauczyciels");
            DropIndex("dbo.Klasas", new[] { "nauczycielID" });
            AlterColumn("dbo.Klasas", "nauczycielID", c => c.Int());
            RenameColumn(table: "dbo.Klasas", name: "nauczycielID", newName: "wychowaca_nauczycielID");
            CreateIndex("dbo.Klasas", "wychowaca_nauczycielID");
            AddForeignKey("dbo.Klasas", "wychowaca_nauczycielID", "dbo.Nauczyciels", "nauczycielID");
        }
    }
}
