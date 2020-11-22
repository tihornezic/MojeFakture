namespace MojeFakture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPorezStavkaToFakturaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fakturas", "PorezId", c => c.Int(nullable: false));
            AddColumn("dbo.Fakturas", "StavkaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fakturas", "PorezId");
            CreateIndex("dbo.Fakturas", "StavkaId");
            AddForeignKey("dbo.Fakturas", "PorezId", "dbo.Porezs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fakturas", "StavkaId", "dbo.Stavkas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fakturas", "StavkaId", "dbo.Stavkas");
            DropForeignKey("dbo.Fakturas", "PorezId", "dbo.Porezs");
            DropIndex("dbo.Fakturas", new[] { "StavkaId" });
            DropIndex("dbo.Fakturas", new[] { "PorezId" });
            DropColumn("dbo.Fakturas", "StavkaId");
            DropColumn("dbo.Fakturas", "PorezId");
        }
    }
}
