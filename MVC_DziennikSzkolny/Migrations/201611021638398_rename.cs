namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "nauczycielPrzedmiotID", newName: "nauczycielPrzedmiotID");
            RenameIndex(table: "dbo.ListaPrzedmiotowKlasies", name: "IX_nauczycielPrzedmiotID", newName: "IX_listaNauczycieliPrzedmiotuID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ListaPrzedmiotowKlasies", name: "IX_listaNauczycieliPrzedmiotuID", newName: "IX_nauczycielPrzedmiotID");
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "nauczycielPrzedmiotID", newName: "nauczycielPrzedmiotID");
        }
    }
}
