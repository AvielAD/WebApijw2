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
                        ReportId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Reports", t => t.ReportId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.ReportId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId)
                .Index(t => t.Editorial_MyProperty);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        BookId = c.Int(nullable: false),
                        BrochureId = c.Int(nullable: false),
                        MagazineId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                        TeatryId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Brochures", t => t.BrochureId)
                .ForeignKey("dbo.Magazines", t => t.MagazineId)
                .ForeignKey("dbo.Teatries", t => t.TeatryId)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .Index(t => t.BookId)
                .Index(t => t.BrochureId)
                .Index(t => t.MagazineId)
                .Index(t => t.VideoId)
                .Index(t => t.TeatryId)
                .Index(t => t.Editorial_MyProperty);
            
            CreateTable(
                "dbo.Editorials",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
            CreateTable(
                "dbo.Brochures",
                c => new
                    {
                        BrochureId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.BrochureId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId)
                .Index(t => t.Editorial_MyProperty);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MagazineId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.MagazineId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId)
                .Index(t => t.Editorial_MyProperty);
            
            CreateTable(
                "dbo.Teatries",
                c => new
                    {
                        TeatryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.TeatryId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId)
                .Index(t => t.Editorial_MyProperty);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        VisitId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        Editorial_MyProperty = c.Int(),
                    })
                .PrimaryKey(t => t.VideoId)
                .ForeignKey("dbo.Editorials", t => t.Editorial_MyProperty)
                .ForeignKey("dbo.Visits", t => t.VisitId)
                .Index(t => t.VisitId)
                .Index(t => t.Editorial_MyProperty);
            
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
                "dbo.VisitCategories",
                c => new
                    {
                        VisitCategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        VisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitCategoryId)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Users", "StateId", "dbo.States");
            DropForeignKey("dbo.VisitCategories", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Videos", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.UserVisiteds", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.UserVisiteds", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserVisiteds", "CityId", "dbo.Cities");
            DropForeignKey("dbo.UserVisiteds", "CircuitId", "dbo.Circuits");
            DropForeignKey("dbo.Teatries", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Visits", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.Magazines", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Brochures", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Books", "VisitId", "dbo.Visits");
            DropForeignKey("dbo.Videos", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Teatries", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "TeatryId", "dbo.Teatries");
            DropForeignKey("dbo.Magazines", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "MagazineId", "dbo.Magazines");
            DropForeignKey("dbo.Brochures", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "BrochureId", "dbo.Brochures");
            DropForeignKey("dbo.Books", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "Editorial_MyProperty", "dbo.Editorials");
            DropForeignKey("dbo.Authors", "BookId", "dbo.Books");
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
            DropIndex("dbo.VisitCategories", new[] { "VisitId" });
            DropIndex("dbo.UserVisiteds", new[] { "VisitId" });
            DropIndex("dbo.UserVisiteds", new[] { "CountryId" });
            DropIndex("dbo.UserVisiteds", new[] { "CityId" });
            DropIndex("dbo.UserVisiteds", new[] { "CircuitId" });
            DropIndex("dbo.Videos", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Videos", new[] { "VisitId" });
            DropIndex("dbo.Teatries", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Teatries", new[] { "VisitId" });
            DropIndex("dbo.Magazines", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Magazines", new[] { "VisitId" });
            DropIndex("dbo.Brochures", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Brochures", new[] { "VisitId" });
            DropIndex("dbo.Authors", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Authors", new[] { "TeatryId" });
            DropIndex("dbo.Authors", new[] { "VideoId" });
            DropIndex("dbo.Authors", new[] { "MagazineId" });
            DropIndex("dbo.Authors", new[] { "BrochureId" });
            DropIndex("dbo.Authors", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "Editorial_MyProperty" });
            DropIndex("dbo.Books", new[] { "VisitId" });
            DropIndex("dbo.Visits", new[] { "Category_CategoryId" });
            DropIndex("dbo.Visits", new[] { "ReportId" });
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
            DropTable("dbo.Categories");
            DropTable("dbo.VisitCategories");
            DropTable("dbo.UserVisiteds");
            DropTable("dbo.Videos");
            DropTable("dbo.Teatries");
            DropTable("dbo.Magazines");
            DropTable("dbo.Brochures");
            DropTable("dbo.Editorials");
            DropTable("dbo.Authors");
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
