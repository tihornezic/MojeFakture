namespace MojeFakture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePorezes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Porezs (VrstaPoreza, VrijednostPoreza) VALUES ('PDV 25%', 0.25)");
            Sql("INSERT INTO Porezs (VrstaPoreza, VrijednostPoreza) VALUES ('PDV 17%', 0.17)");
            Sql("INSERT INTO Porezs (VrstaPoreza, VrijednostPoreza) VALUES ('PDV 20%', 0.20)");
            Sql("INSERT INTO Porezs (VrstaPoreza, VrijednostPoreza) VALUES ('PDV 19%', 0.19)");
        }
        
        public override void Down()
        {
        }
    }
}
