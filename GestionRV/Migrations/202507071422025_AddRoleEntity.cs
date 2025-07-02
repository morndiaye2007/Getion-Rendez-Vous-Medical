namespace GestionRV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRole = c.Int(nullable: false, identity: true),
                        NomRole = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdRole);
            
            AddColumn("dbo.Personnes", "IdRole", c => c.Int());
            CreateIndex("dbo.Personnes", "IdRole");
            AddForeignKey("dbo.Personnes", "IdRole", "dbo.Roles", "IdRole");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "IdRole", "dbo.Roles");
            DropIndex("dbo.Personnes", new[] { "IdRole" });
            DropColumn("dbo.Personnes", "IdRole");
            DropTable("dbo.Roles");
        }
    }
}
