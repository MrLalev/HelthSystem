namespace HelthSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Time = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        Doctor_UserId = c.Int(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_UserId)
                .ForeignKey("dbo.Users", t => t.Patient_Id)
                .Index(t => t.Doctor_UserId)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Position = c.String(),
                        Description = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                        AdminRole = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Doctor_UserId", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
