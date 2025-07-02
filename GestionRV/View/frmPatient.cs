using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionRV.Model;
using System.Globalization;
using Newtonsoft.Json;

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
            txtAdresse.Text= string.Empty;
            txtEmail.Text= string.Empty;
            txtGroupeSanguin.Text= string.Empty;
            txtNomPrenom.Text= string.Empty;
            //txtPoids.Text= string.Empty;
            //txtTaille.Text= string.Empty;  
            txtTel.Text= string.Empty;
            txtDateNaissance.Value= DateTime.Now;
           dgPatient.DataSource= db.Patients.ToList();
            txtNomPrenom.Focus();
        }
        private async Task LoadPatientsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                var response = await client.GetAsync("Patient");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                    dgPatient.DataSource = patients;
                }
            }
        }


        private void frmPatient_Load(object sender, EventArgs e)
        {
           // ResetForm();
             LoadPatientsAsync();
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
           

                // Crée le patient avec les valeurs correctes
                Patient p = new Patient
                {
                    NomPrenom = txtNomPrenom.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    Tel = txtTel.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DateNaissance = txtDateNaissance.Value,
                    GroupeSanguin = txtGroupeSanguin.Text.Trim(),
                     
                };

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44338/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(p);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("Patient", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Patient ajouté avec succès !");
                        ResetForm();
                        await LoadPatientsAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Erreur lors de l’ajout : {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}");
            }
        }




        private void btnChoisir_Click(object sender, EventArgs e)
        {
            txtNomPrenom.Text = dgPatient.CurrentRow.Cells[5].Value.ToString();
            txtAdresse.Text = dgPatient.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = dgPatient.CurrentRow.Cells[7].Value.ToString();
            txtTel.Text = dgPatient.CurrentRow.Cells [8].Value.ToString();
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
                if (!float.TryParse(txtPoids.Text, out float poids))
                {
                    MessageBox.Show("Le format du poids est invalide.");
                    txtPoids.Focus();
                    return;
                }
                if (!float.TryParse(txtTaille.Text, out float taille))
                {
                    MessageBox.Show("Le format de la taille est invalide.");
                    txtTaille.Focus();
                    return;
                }

                var p = db.Patients.Find(id);
                p.NomPrenom = txtNomPrenom.Text;
                p.Adresse = txtAdresse.Text;
                p.Tel = txtTel.Text;
                p.Email = txtEmail.Text;
                p.DateNaissance = txtDateNaissance.Value;
                p.GroupeSanguin = txtGroupeSanguin.Text;
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
            /*var liste db.Patients.ToList();
            if (!string.IsNullOrEmpty(txtREmail.Text)) {
                liste = liste.Where(a => a.Email.toUpper())== txtREmail.Text.ToUpper();
            }

            if (!string.IsNullOrEmpty(txtRTel.Text))
            {
                liste = liste.Where(a => a.Telephone.toUpper()) == txtRTel.Text.ToUpper();
            }
            dgPatient.DataSource = liste.ToList();*/
        }

        private void btnRv_Click(object sender, EventArgs e)
        {
            frmRendezVous f = new frmRendezVous();
            f.Show();
            this.Enabled = false;
        }
    }
}
