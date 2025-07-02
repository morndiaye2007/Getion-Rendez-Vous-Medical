namespace APIRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncPatientTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Personnes", newName: "Patients");
        }
        
        public override void Down()
        {
            RenameTable(name: "Patients", newName: "Personnes");
        }
    }
}
