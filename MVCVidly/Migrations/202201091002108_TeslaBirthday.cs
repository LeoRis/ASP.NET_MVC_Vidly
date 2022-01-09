namespace MVCVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeslaBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1856/7/10' WHERE Name = 'Nikola Tesla'");
        }
        
        public override void Down()
        {
        }
    }
}
