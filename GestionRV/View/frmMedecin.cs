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
    public partial class frmMedecin : Form
    {
        BdRvMedicalContext db = new BdRvMedicalContext();
        public frmMedecin()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Medecin m = new Medecin();
            m.Adresse = txtAdresse.Text;
            m.NumeroOrdre = txtNumeroOrdreMedecin.Text;
            m.Tel = txtTel.Text;
            m.Email = txtEmail.Text;
            m.NomPrenom = txtNomPrenom.Text;
            m.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
            m.Identifiant = txtIdentifiant.Text;
            m.Statut = false;
            db.Medecins.Add(m);
            db.SaveChanges();
            ResetForm();
        }
        private void ResetForm()
        {
            txtAdresse.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtIdentifiant.Text = String.Empty;
            cbbSpecialite.SelectedValue = String.Empty;
            txtNumeroOrdreMedecin.Text = String.Empty;
            txtNomPrenom.Text = String.Empty;
            cbbSpecialite.DataSource = LoadcbbSpecialite();
            cbbSpecialite.ValueMember = "Value";
            cbbSpecialite.DisplayMember = "Text";
            dgMedecin.DataSource = db.Medecins.Select(a => new { a.IdU, a.NumeroOrdre, a.Identifiant, a.Specialite.NomSpecialite, a.NomPrenom, a.Tel, a.Email }).ToList();

            txtNomPrenom.Focus();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());


            var m = db.Medecins.Find(id);
            if (m != null)
            {
                txtAdresse.Text = m.Adresse;
                txtEmail.Text = m.Email;
                txtIdentifiant.Text = m.Identifiant;
                txtNomPrenom.Text = m.NomPrenom;
                txtNumeroOrdreMedecin.Text = m.NumeroOrdre;
                cbbSpecialite.SelectedValue = m.IdSpecialite;
                txtTel.Text = m.Tel;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //int? id;
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var m = db.Medecins.Find(id);
            m.Adresse = txtAdresse.Text;
            m.NumeroOrdre = txtNumeroOrdreMedecin.Text;
            m.Tel = txtTel.Text;
            m.Email = txtEmail.Text;
            m.NomPrenom = txtNomPrenom.Text;
            m.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
            m.Identifiant = txtIdentifiant.Text;

            db.SaveChanges();
            ResetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            
            var m = db.Medecins.Find(id);
            db.Medecins.Remove(m);

            db.SaveChanges();
            ResetForm();
        }

        private void frmMedecin_Load(object sender, EventArgs e)
        {
            ResetForm();

        }

        private List<SelectListViewModel> LoadcbbSpecialite()
        {
            var m = db.Specialites.ToList();
            List<SelectListViewModel> liste = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel();
            b.Text = "Selectionner...";
            b.Value = "";  
            liste.Add(b);

            foreach (var c in m)
            {
                SelectListViewModel a = new SelectListViewModel();
                a.Text = c.NomSpecialite;
                a.Text = c.IdSpecialite.ToString();
                liste.Add(a);
            }
            return liste;
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            dgAgenda a = new dgAgenda();
            a.idMedecin = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            a.Show();
        }

       
    }
}
