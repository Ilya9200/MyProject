namespace DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operation", "Code", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operation", "Code");
        }
    }
}
