namespace WcfServiceRdv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RendezVous",
                c => new
                    {
                        IdRv = c.Int(nullable: false, identity: true),
                        DateRv = c.DateTime(nullable: false, precision: 0),
                        Statut = c.String(maxLength: 10, storeType: "nvarchar"),
                        IdSoin = c.Int(),
                        IdPatient = c.Int(),
                        IdMedecin = c.Int(),
                        Agenda_IdAgenda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRv)
                .ForeignKey("dbo.Agenda", t => t.Agenda_IdAgenda)
                .ForeignKey("dbo.Utilisateurs", t => t.IdMedecin)
                .ForeignKey("dbo.Patients", t => t.IdPatient)
                .ForeignKey("dbo.Soins", t => t.IdSoin)
                .Index(t => t.IdSoin)
                .Index(t => t.IdPatient)
                .Index(t => t.IdMedecin)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        Identifiant = c.String(maxLength: 20, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 250, storeType: "nvarchar"),
                        Statut = c.Boolean(nullable: false),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Adresse = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Tel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 10, storeType: "nvarchar"),
                        TelphoneFixe = c.String(maxLength: 15, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite)
                .Index(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        IdAgenda = c.Int(nullable: false, identity: true),
                        DatePlanifie = c.DateTime(precision: 0),
                        Titre = c.String(unicode: false),
                        HeureDebut = c.String(unicode: false),
                        HeureFin = c.String(unicode: false),
                        Creneau = c.Int(nullable: false),
                        Lieu = c.String(unicode: false),
                        Jour = c.String(unicode: false),
                        Statut = c.String(unicode: false),
                        IdMedecin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.Utilisateurs", t => t.IdMedecin, cascadeDelete: true)
                .Index(t => t.IdMedecin);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        NomSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        GroupeSanguin = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                        taille = c.Single(nullable: false),
                        Poids = c.Single(nullable: false),
                        DateNaissance = c.DateTime(precision: 0),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Adresse = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Tel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdU);
            
            CreateTable(
                "dbo.Soins",
                c => new
                    {
                        Idsoin = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Idsoin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Patients");
            DropForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.RendezVous", "Agenda_IdAgenda", "dbo.Agenda");
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Utilisateurs");
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            DropIndex("dbo.Utilisateurs", new[] { "IdSpecialite" });
            DropIndex("dbo.RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("dbo.RendezVous", new[] { "IdMedecin" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropTable("dbo.Soins");
            DropTable("dbo.Patients");
            DropTable("dbo.Specialites");
            DropTable("dbo.Agenda");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.RendezVous");
        }
    }
}
