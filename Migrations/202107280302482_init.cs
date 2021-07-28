namespace DeptEmployeeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        SalaryAmount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Employees", t => t.EmpId)
                .Index(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Salaries", "EmpId", "dbo.Employees");
            DropIndex("dbo.Salaries", new[] { "EmpId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
