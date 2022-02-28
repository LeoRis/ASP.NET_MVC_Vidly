namespace MVCVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'934fa94e-ce26-4607-8d84-25ba3b9caa96', N'test.different.basic@gmail.com', 0, N'APe6YHjXFyD0AjdMIppOQV7uOhXpPVgsbDCHZOagHjdNOo/v5wuVrJTWgA+K4KASrQ==', N'ef05d5f6-a073-4b05-9036-2d1f6604eb81', NULL, 0, 0, NULL, 1, 0, N'test.different.basic@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab10264a-cc06-4b78-887a-8b5f138c8581', N'admin@vidly.com', 0, N'AH2v7sci33E3MrQkQKTCOYlQgtQ9ulzv6+UAN0hL76CdICv4jSHRnsx7baGQSVZzTw==', N'3720640e-7365-4807-90fb-d57709d76408', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'88cb157c-98a5-4ceb-9b4e-2771e7ee793f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab10264a-cc06-4b78-887a-8b5f138c8581', N'88cb157c-98a5-4ceb-9b4e-2771e7ee793f')

");
        }
        
        public override void Down()
        {
        }
    }
}
