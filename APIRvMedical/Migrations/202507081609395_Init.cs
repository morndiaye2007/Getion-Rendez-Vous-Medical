namespace APIRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Agenda",
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
                .ForeignKey("Personnes", t => t.IdMedecin, cascadeDelete: true)
                .Index(t => t.IdMedecin);
            
            CreateTable(
                "Personnes",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Adresse = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Tel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Identifiant = c.String(maxLength: 20, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 250, storeType: "nvarchar"),
                        Statut = c.Boolean(),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 10, storeType: "nvarchar"),
                        GroupeSanguin = c.String(maxLength: 3, storeType: "nvarchar"),
                        taille = c.Single(),
                        Poids = c.Single(),
                        DateNaissance = c.DateTime(precision: 0),
                        TelphoneFixe = c.String(maxLength: 15, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Role_IdRole = c.Int(),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("Specialites", t => t.IdSpecialite)
                .ForeignKey("Roles", t => t.Role_IdRole)
                .Index(t => t.IdSpecialite)
                .Index(t => t.Role_IdRole);
            
            CreateTable(
                "Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        NomSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "RendezVous",
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
                .ForeignKey("Personnes", t => t.IdMedecin)
                .ForeignKey("Personnes", t => t.IdPatient)
                .ForeignKey("soin", t => t.IdSoin)
                .ForeignKey("Agenda", t => t.Agenda_IdAgenda)
                .Index(t => t.IdSoin)
                .Index(t => t.IdPatient)
                .Index(t => t.IdMedecin)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "soin",
                c => new
                    {
                        Idsoin = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Idsoin);
            
            CreateTable(
                "GroupeSanguins",
                c => new
                    {
                        IdGroupeSanguin = c.Int(nullable: false, identity: true),
                        CodeGroupeSanguin = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdGroupeSanguin);
            
            CreateTable(
                "Roles",
                c => new
                    {
                        IdRole = c.Int(nullable: false, identity: true),
                        NomRole = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Personnes", "Role_IdRole", "Roles");
            DropForeignKey("RendezVous", "Agenda_IdAgenda", "Agenda");
            DropForeignKey("RendezVous", "IdSoin", "soin");
            DropForeignKey("RendezVous", "IdPatient", "Personnes");
            DropForeignKey("RendezVous", "IdMedecin", "Personnes");
            DropForeignKey("Personnes", "IdSpecialite", "Specialites");
            DropForeignKey("Agenda", "IdMedecin", "Personnes");
            DropIndex("RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("RendezVous", new[] { "IdMedecin" });
            DropIndex("RendezVous", new[] { "IdPatient" });
            DropIndex("RendezVous", new[] { "IdSoin" });
            DropIndex("Personnes", new[] { "Role_IdRole" });
            DropIndex("Personnes", new[] { "IdSpecialite" });
            DropIndex("Agenda", new[] { "IdMedecin" });
            DropTable("Roles");
            DropTable("GroupeSanguins");
            DropTable("soin");
            DropTable("RendezVous");
            DropTable("Specialites");
            DropTable("Personnes");
            DropTable("Agenda");
        }
    }
}
