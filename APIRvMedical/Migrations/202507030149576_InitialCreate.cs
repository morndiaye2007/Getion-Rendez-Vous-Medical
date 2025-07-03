namespace APIRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        IdAgenda = c.Int(nullable: false, identity: true),
                        DatePlanifie = c.DateTime(),
                        Titre = c.String(),
                        HeureDebut = c.String(),
                        HeureFin = c.String(),
                        Creneau = c.Int(nullable: false),
                        Lieu = c.String(),
                        Jour = c.String(),
                        Statut = c.String(),
                        IdMedecin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin, cascadeDelete: true)
                .Index(t => t.IdMedecin);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160),
                        Adresse = c.String(nullable: false, maxLength: 160),
                        Email = c.String(nullable: false, maxLength: 80),
                        Tel = c.String(nullable: false, maxLength: 200),
                        Identifiant = c.String(maxLength: 20),
                        MotDePasse = c.String(maxLength: 250),
                        Statut = c.Boolean(),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 10),
                        GroupeSanguin = c.String(maxLength: 3),
                        taille = c.Single(),
                        Poids = c.Single(),
                        DateNaissance = c.DateTime(),
                        TelphoneFixe = c.String(maxLength: 15),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite)
                .Index(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 100),
                        NomSpecialite = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.RendezVous",
                c => new
                    {
                        IdRv = c.Int(nullable: false, identity: true),
                        DateRv = c.DateTime(nullable: false),
                        Statut = c.String(maxLength: 10),
                        IdSoin = c.Int(),
                        IdPatient = c.Int(),
                        IdMedecin = c.Int(),
                        Agenda_IdAgenda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRv)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin)
                .ForeignKey("dbo.Personnes", t => t.IdPatient)
                .ForeignKey("dbo.soin", t => t.IdSoin)
                .ForeignKey("dbo.Agenda", t => t.Agenda_IdAgenda)
                .Index(t => t.IdSoin)
                .Index(t => t.IdPatient)
                .Index(t => t.IdMedecin)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "dbo.soin",
                c => new
                    {
                        Idsoin = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Idsoin);
            
            CreateTable(
                "dbo.GroupeSanguins",
                c => new
                    {
                        IdGroupeSanguin = c.Int(nullable: false, identity: true),
                        CodeGroupeSanguin = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.IdGroupeSanguin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "Agenda_IdAgenda", "dbo.Agenda");
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.soin");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes");
            DropForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes");
            DropIndex("dbo.RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("dbo.RendezVous", new[] { "IdMedecin" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropIndex("dbo.Personnes", new[] { "IdSpecialite" });
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            DropTable("dbo.GroupeSanguins");
            DropTable("dbo.soin");
            DropTable("dbo.RendezVous");
            DropTable("dbo.Specialites");
            DropTable("dbo.Personnes");
            DropTable("dbo.Agenda");
        }
    }
}
