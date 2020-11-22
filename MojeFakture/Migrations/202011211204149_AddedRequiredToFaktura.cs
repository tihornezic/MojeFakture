namespace MojeFakture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToFaktura : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fakturas", "Opis", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Fakturas", "DatumStvaranja", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Fakturas", "DatumDospijeca", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fakturas", "DatumDospijeca", c => c.String());
            AlterColumn("dbo.Fakturas", "DatumStvaranja", c => c.String());
            AlterColumn("dbo.Fakturas", "Opis", c => c.String());
        }
    }
}
