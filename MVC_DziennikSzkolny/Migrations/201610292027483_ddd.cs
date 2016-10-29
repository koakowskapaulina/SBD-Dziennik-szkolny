namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uczens", "klasa_klasaID", "dbo.Klasas");
            DropForeignKey("dbo.Uczens", "rodzic_rodzicID", "dbo.Rodzics");
            DropIndex("dbo.Uczens", new[] { "klasa_klasaID" });
            DropIndex("dbo.Uczens", new[] { "rodzic_rodzicID" });
            RenameColumn(table: "dbo.Uczens", name: "klasa_klasaID", newName: "klasaID");
            RenameColumn(table: "dbo.Uczens", name: "rodzic_rodzicID", newName: "rodzicID");
            AlterColumn("dbo.Uczens", "klasaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Uczens", "rodzicID", c => c.Int(nullable: false));
            CreateIndex("dbo.Uczens", "rodzicID");
            CreateIndex("dbo.Uczens", "klasaID");
            AddForeignKey("dbo.Uczens", "klasaID", "dbo.Klasas", "klasaID", cascadeDelete: true);
            AddForeignKey("dbo.Uczens", "rodzicID", "dbo.Rodzics", "rodzicID", cascadeDelete: true);
            DropColumn("dbo.Uczens", "Id_rodzica");
            DropColumn("dbo.Uczens", "Id_klasy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uczens", "Id_klasy", c => c.Int(nullable: false));
            AddColumn("dbo.Uczens", "Id_rodzica", c => c.Int(nullable: false));
            DropForeignKey("dbo.Uczens", "rodzicID", "dbo.Rodzics");
            DropForeignKey("dbo.Uczens", "klasaID", "dbo.Klasas");
            DropIndex("dbo.Uczens", new[] { "klasaID" });
            DropIndex("dbo.Uczens", new[] { "rodzicID" });
            AlterColumn("dbo.Uczens", "rodzicID", c => c.Int());
            AlterColumn("dbo.Uczens", "klasaID", c => c.Int());
            RenameColumn(table: "dbo.Uczens", name: "rodzicID", newName: "rodzic_rodzicID");
            RenameColumn(table: "dbo.Uczens", name: "klasaID", newName: "klasa_klasaID");
            CreateIndex("dbo.Uczens", "rodzic_rodzicID");
            CreateIndex("dbo.Uczens", "klasa_klasaID");
            AddForeignKey("dbo.Uczens", "rodzic_rodzicID", "dbo.Rodzics", "rodzicID");
            AddForeignKey("dbo.Uczens", "klasa_klasaID", "dbo.Klasas", "klasaID");
        }
    }
}
