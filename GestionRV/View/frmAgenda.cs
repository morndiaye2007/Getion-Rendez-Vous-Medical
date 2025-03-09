using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionRV.Model;

namespace GestionRV.View
{
    public partial class dgAgenda : Form
    {
        public int idMedecin;
        public dgAgenda()
        {
            InitializeComponent();
        }
        BdRvMedicalContext db = new BdRvMedicalContext();

        public static object DataSource { get; private set; }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            var m = db.Medecins.Find(idMedecin);
            
            lblMedecin.Text = String.Format("N Ordre:{0}, Nom Prenom: {1}", m.NumeroOrdre, m.NomPrenom);
            lblIdMedecin.Text = m.IdU.ToString();
            lblIdMedecin.Visible = false;
            ResetForm();
        }

        private void ResetForm()
        {
            dgAgenda.DataSource = db.Agenda.Where(a => a.DatePlanifie >= DateTime.Now && a.IdMedecin == idMedecin).ToList();
            txtCreneau.Text = string.Empty;
            txtDateAgenda.Value = DateTime.Now;
            txtHeureDebut.Text = string.Empty;
            txtHeureFin.Text = string.Empty;
            txtHeureFin.Visible = true;

            txtTitre.Text = string.Empty;
            txtTitre.Focus();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Agenda a = new Agenda();
            a.Creneau = int.Parse(txtCreneau.Text);
            a.HeureDebut = txtCreneau.Text;
            a.HeureFin = txtHeureFin.Text;
            a.IdMedecin = idMedecin;
            a.DatePlanifie = txtDateAgenda.Value;
            a.Statut = "brouillon";
            a.Lieu = txtLieu.Text;
            a.Titre = txtTitre.Text;

            db.Agenda.Add(a);
            db.SaveChanges();
            ResetForm();
        }
    }
}
