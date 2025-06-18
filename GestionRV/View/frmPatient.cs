using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // Ajout pour la gestion de la culture
using GestionRV.Model;

namespace GestionRV.View
{
    public partial class frmPatient : Form
    {
        public frmPatient()
        {
            InitializeComponent();
        }
        BdRvMedicalContext db = new BdRvMedicalContext();

        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGroupeSanguin.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtPoids.Text = string.Empty;
            txtTaille.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtDateNaissance.Value = DateTime.Now;
            dgPatient.DataSource = db.Patients.ToList();
            txtNomPrenom.Focus();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Validation Poids
            if (!float.TryParse(txtPoids.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float poids))
            {
                MessageBox.Show("Veuillez saisir un poids valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPoids.Focus();
                return;
            }

            // Validation Taille
            if (!float.TryParse(txtTaille.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float taille))
            {
                MessageBox.Show("Veuillez saisir une taille valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaille.Focus();
                return;
            }

            Patient p = new Patient();
            p.NomPrenom = txtNomPrenom.Text.Trim();
            p.Adresse = txtAdresse.Text.Trim();
            p.Tel = txtTel.Text.Trim();
            p.Email = txtEmail.Text.Trim();
            p.DateNaissance = txtDateNaissance.Value;
            p.GroupeSanguin = txtGroupeSanguin.Text.Trim();
            p.Poids = poids;
            p.taille = taille;

            db.Patients.Add(p);
            db.SaveChanges();
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            txtNomPrenom.Text = dgPatient.CurrentRow.Cells[5].Value.ToString();
            txtAdresse.Text = dgPatient.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = dgPatient.CurrentRow.Cells[7].Value.ToString();
            txtTel.Text = dgPatient.CurrentRow.Cells[8].Value.ToString();
            txtGroupeSanguin.Text = dgPatient.CurrentRow.Cells[0].Value.ToString();
            txtPoids.Text = dgPatient.CurrentRow.Cells[1].Value.ToString();
            txtTaille.Text = dgPatient.CurrentRow.Cells[2].Value.ToString();
            txtDateNaissance.Value = DateTime.Parse(dgPatient.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgPatient.CurrentRow.Cells[4].Value.ToString());
            if (id.HasValue)
            {
                // Validation Poids
                if (!float.TryParse(txtPoids.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float poids))
                {
                    MessageBox.Show("Veuillez saisir un poids valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPoids.Focus();
                    return;
                }

                // Validation Taille
                if (!float.TryParse(txtTaille.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float taille))
                {
                    MessageBox.Show("Veuillez saisir une taille valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaille.Focus();
                    return;
                }

                var p = db.Patients.Find(id);
                p.NomPrenom = txtNomPrenom.Text.Trim();
                p.Adresse = txtAdresse.Text.Trim();
                p.Tel = txtTel.Text.Trim();
                p.Email = txtEmail.Text.Trim();
                p.DateNaissance = txtDateNaissance.Value;
                p.GroupeSanguin = txtGroupeSanguin.Text.Trim();
                p.Poids = poids;
                p.taille = taille;
                db.SaveChanges();
                ResetForm();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgPatient.CurrentRow.Cells[4].Value.ToString());
            if (id.HasValue)
            {
                var p = db.Patients.Find(id);
                db.Patients.Remove(p);
                db.SaveChanges();
                ResetForm();
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            var liste = db.Patients.ToList();

            if (!string.IsNullOrEmpty(txtREmail.Text))
            {
                liste = liste.Where(a => a.Email != null && a.Email.ToUpper().Contains(txtREmail.Text.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(txtRTel.Text))
            {
                liste = liste.Where(a => a.Tel != null && a.Tel.ToUpper().Contains(txtRTel.Text.ToUpper())).ToList();
            }

            dgPatient.DataSource = liste;
        }


        private void btnRv_Click(object sender, EventArgs e)
        {
            frmRendezVous f = new frmRendezVous();
            f.Show();
            this.Enabled = false;
        }
    }
}
