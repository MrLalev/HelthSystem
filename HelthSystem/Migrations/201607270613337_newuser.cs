namespace HelthSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "User_Id");
            AlterColumn("dbo.Appointments", "User_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "User_Id");
            AddForeignKey("dbo.Appointments", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Appointments", "DoctortId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DoctortId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "User_Id", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "User_Id" });
            AlterColumn("dbo.Appointments", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Appointments", name: "User_Id", newName: "PatientId");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
