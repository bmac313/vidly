namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Free' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Ultimate' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
