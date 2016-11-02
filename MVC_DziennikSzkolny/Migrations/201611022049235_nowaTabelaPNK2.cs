namespace MVC_DziennikSzkolny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowaTabelaPNK2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "listaNauczycieliPrzedmiotuID", newName: "nauczycielPrzedmiotID");
            RenameIndex(table: "dbo.ListaPrzedmiotowKlasies", name: "IX_listaNauczycieliPrzedmiotuID", newName: "IX_nauczycielPrzedmiotID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ListaPrzedmiotowKlasies", name: "IX_nauczycielPrzedmiotID", newName: "IX_listaNauczycieliPrzedmiotuID");
            RenameColumn(table: "dbo.ListaPrzedmiotowKlasies", name: "nauczycielPrzedmiotID", newName: "listaNauczycieliPrzedmiotuID");
        }
    }
}
