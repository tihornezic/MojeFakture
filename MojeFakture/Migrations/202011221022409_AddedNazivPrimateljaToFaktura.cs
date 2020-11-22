namespace MojeFakture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNazivPrimateljaToFaktura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fakturas", "NazivPrimatelja", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fakturas", "NazivPrimatelja");
        }
    }
}
