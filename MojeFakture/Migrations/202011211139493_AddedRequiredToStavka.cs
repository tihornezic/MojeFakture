namespace MojeFakture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToStavka : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stavkas", "Naziv", c => c.String(nullable: true, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stavkas", "Naziv", c => c.String());
        }
    }
}
