namespace WebApijw2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                        Sex = c.String(),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CircuitId = c.Int(nullable: false),
                        CongregationId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorId)
                .ForeignKey("dbo.Circuits", t => t.CircuitId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Congregations", t => t.CongregationId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.CircuitId)
                .Index(t => t.CongregationId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Circuits",
                c => new
                    {
                        CircuitId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CircuitId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Congregations",
                c => new
                    {
                        CongregationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Decription = c.String(),
                        CircuitId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CongregationId)
                .ForeignKey("dbo.Circuits", t => t.CircuitId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CircuitId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Sex = c.String(),
                        Address = c.String(),
                        CircuitId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CongregationId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Circuits", t => t.CircuitId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Congregations", t => t.CongregationId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CircuitId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.CongregationId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Stop = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        UserId = c.Int(nullable: false),
                        CongregationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Congregations", t => t.CongregationId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CongregationId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Reports", t => t.ReportId)
                .Index(t => t.CategoryId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Brochures",
                c => new
                    {
                        BrochureId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrochureId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MagazineId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagazineId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Teatries",
                c => new
                    {
                        TeatryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeatryId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.UserVisiteds",
                c => new
                    {
                        UserVisitedId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        CircuitId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserVisitedId)
                .ForeignKey("dbo.Circuits", t => t.CircuitId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.CircuitId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoId)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "StateId", "dbo.States");
            DropForeignKey("dbo.Videos", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.UserVisiteds", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.UserVisiteds", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserVisiteds", "CityId", "dbo.Cities");
            DropForeignKey("dbo.UserVisiteds", "CircuitId", "dbo.Circuits");
            DropForeignKey("dbo.Teatries", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Visits", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.Magazines", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Visits", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Brochures", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Books", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Reports", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reports", "CongregationId", "dbo.Congregations");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Users", "CongregationId", "dbo.Congregations");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Users", "CircuitId", "dbo.Circuits");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Congregations", "StateId", "dbo.States");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.Administrators", "StateId", "dbo.States");
            DropForeignKey("dbo.Congregations", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Administrators", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Congregations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Congregations", "CircuitId", "dbo.Circuits");
            DropForeignKey("dbo.Administrators", "CongregationId", "dbo.Congregations");
            DropForeignKey("dbo.Circuits", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Administrators", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Administrators", "CircuitId", "dbo.Circuits");
            DropIndex("dbo.Videos", new[] { "VisitId" });
            DropIndex("dbo.UserVisiteds", new[] { "VisitId" });
            DropIndex("dbo.UserVisiteds", new[] { "CountryId" });
            DropIndex("dbo.UserVisiteds", new[] { "CityId" });
            DropIndex("dbo.UserVisiteds", new[] { "CircuitId" });
            DropIndex("dbo.Teatries", new[] { "VisitId" });
            DropIndex("dbo.Magazines", new[] { "VisitId" });
            DropIndex("dbo.Brochures", new[] { "VisitId" });
            DropIndex("dbo.Books", new[] { "VisitId" });
            DropIndex("dbo.Visits", new[] { "ReportId" });
            DropIndex("dbo.Visits", new[] { "CategoryId" });
            DropIndex("dbo.Reports", new[] { "CongregationId" });
            DropIndex("dbo.Reports", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "StateId" });
            DropIndex("dbo.Users", new[] { "CongregationId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Users", new[] { "CircuitId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Congregations", new[] { "StateId" });
            DropIndex("dbo.Congregations", new[] { "CountryId" });
            DropIndex("dbo.Congregations", new[] { "CityId" });
            DropIndex("dbo.Congregations", new[] { "CircuitId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.Circuits", new[] { "CityId" });
            DropIndex("dbo.Administrators", new[] { "StateId" });
            DropIndex("dbo.Administrators", new[] { "CongregationId" });
            DropIndex("dbo.Administrators", new[] { "CircuitId" });
            DropIndex("dbo.Administrators", new[] { "CountryId" });
            DropIndex("dbo.Administrators", new[] { "CityId" });
            DropTable("dbo.Videos");
            DropTable("dbo.UserVisiteds");
            DropTable("dbo.Teatries");
            DropTable("dbo.Magazines");
            DropTable("dbo.Categories");
            DropTable("dbo.Brochures");
            DropTable("dbo.Books");
            DropTable("dbo.Visits");
            DropTable("dbo.Reports");
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Congregations");
            DropTable("dbo.Cities");
            DropTable("dbo.Circuits");
            DropTable("dbo.Administrators");
        }
    }
}
