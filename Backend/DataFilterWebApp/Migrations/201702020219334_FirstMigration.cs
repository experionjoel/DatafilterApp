namespace DataFilterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Designation = c.String(),
                        Band = c.String(),
                        DateOfJoining = c.DateTime(),
                        EmployeeNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FieldOperators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(),
                        OperatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operators", t => t.OperatorId, cascadeDelete: true)
                .Index(t => t.OperatorId);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatorSymbol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FieldOperators", "OperatorId", "dbo.Operators");
            DropIndex("dbo.FieldOperators", new[] { "OperatorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Operators");
            DropTable("dbo.FieldOperators");
            DropTable("dbo.Employees");
        }
    }
}
