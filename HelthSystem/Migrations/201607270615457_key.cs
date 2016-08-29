namespace HelthSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Doctor_UserId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "User_Id", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "Doctor_UserId" });
            DropIndex("dbo.Appointments", new[] { "User_Id" });
            RenameColumn(table: "dbo.Appointments", name: "Doctor_UserId", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "UserId");
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "UserId" });
            AlterColumn("dbo.Appointments", "UserId", c => c.Int());
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int());
            RenameColumn(table: "dbo.Appointments", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "Doctor_UserId");
            CreateIndex("dbo.Appointments", "User_Id");
            CreateIndex("dbo.Appointments", "Doctor_UserId");
            AddForeignKey("dbo.Appointments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Appointments", "Doctor_UserId", "dbo.Doctors", "UserId");
        }
    }
}
