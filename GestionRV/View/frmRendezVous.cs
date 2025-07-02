using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionRV.Model;
using Newtonsoft.Json;

namespace GestionRV.View
{
    public partial class frmRendezVous : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "https://localhost:44338/api/rendezvous";

        public frmRendezVous()
        {
            InitializeComponent();
        }

        private async void frmRendezVous_Load(object sender, EventArgs e)
        {
            await LoadComboBoxesAsync();
            await LoadRendezVousAsync();
        }

        private async Task LoadComboBoxesAsync()
        {
            // Charge Patients
            var responsePatient = await client.GetAsync("https://localhost:44338/api/patient");
            if (responsePatient.IsSuccessStatusCode)
            {
                var json = await responsePatient.Content.ReadAsStringAsync();
                var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                cbbPatient.DataSource = patients;
                cbbPatient.DisplayMember = "NomPrenom";
                cbbPatient.ValueMember = "IdU";
            }

            // Charge Médecins
            var responseMedecin = await client.GetAsync("https://localhost:44338/api/medecin");
            if (responseMedecin.IsSuccessStatusCode)
            {
                var json = await responseMedecin.Content.ReadAsStringAsync();
                var medecins = JsonConvert.DeserializeObject<List<Medecin>>(json);
                cbbMedecin.DataSource = medecins;
                cbbMedecin.DisplayMember = "NomPrenom";
                cbbMedecin.ValueMember = "IdU";
            }

            // Charge Soins
            var responseSoin = await client.GetAsync("https://localhost:44338/api/soin");
            if (responseSoin.IsSuccessStatusCode)
            {
                var json = await responseSoin.Content.ReadAsStringAsync();
                var soins = JsonConvert.DeserializeObject<List<Soin>>(json);
                cbbSoin.DataSource = soins;
                cbbSoin.DisplayMember = "Libelle";
                cbbSoin.ValueMember = "IdSoin";
            }
        }

        private async Task LoadRendezVousAsync()
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<RendezVous>>(json);
                dgRendezVous.DataSource = data;
            }
            else
            {
                MessageBox.Show("Erreur chargement rendez-vous !");
            }
        }

        

        

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            var rv = new RendezVous()
            {
                Statut = "brouillon",
                DateRv = DateTime.Now,
                IdPatient = (int)cbbPatient.SelectedValue,
                IdMedecin = (int)cbbMedecin.SelectedValue,
                IdSoin = (int)cbbSoin.SelectedValue
            };

            var json = JsonConvert.SerializeObject(rv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Rendez-vous ajouté !");
                await LoadRendezVousAsync();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout !");
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgRendezVous.CurrentRow == null) return;

            int id = int.Parse(dgRendezVous.CurrentRow.Cells[0].Value.ToString());
            var rv = new RendezVous()
            {
                IdRv = id,
                Statut = "modifié",
                DateRv = DateTime.Now,
                IdPatient = (int)cbbPatient.SelectedValue,
                IdMedecin = (int)cbbMedecin.SelectedValue,
                IdSoin = (int)cbbSoin.SelectedValue
            };

            var json = JsonConvert.SerializeObject(rv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"{apiUrl}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Modifié !");
                await LoadRendezVousAsync();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification !");
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgRendezVous.CurrentRow == null) return;

            int id = int.Parse(dgRendezVous.CurrentRow.Cells[0].Value.ToString());
            HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Supprimé !");
                await LoadRendezVousAsync();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression !");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
