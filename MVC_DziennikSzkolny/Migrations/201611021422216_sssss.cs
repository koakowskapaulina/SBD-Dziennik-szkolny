namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssss : DbMigration
    {
        public override void Up()
        {


            RenameColumn(table: "dbo.Uczens", name: "rodzic_rodzicID", newName: "rodzicID");
            RenameColumn(table: "dbo.Uczens", name: "klasa_klasaID", newName: "klasaID");

        }

        public override void Down()
        {
        }
    }
}
