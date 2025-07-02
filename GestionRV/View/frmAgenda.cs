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
using Newtonsoft.Json;

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

        private async void frmAgenda_Load(object sender, EventArgs e)
        {
            await ChargerMedecinAsync();
            await ResetFormAsync();
        }

        private async Task ChargerMedecinAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"Medecin/{idMedecin}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var medecin = JsonConvert.DeserializeObject<Medecin>(json);

                    if (medecin != null)
                    {
                        lblMedecin.Text = $"N Ordre: {medecin.NumeroOrdre}, Nom Prenom: {medecin.NomPrenom}";
                        lblIdMedecin.Text = medecin.IdU.ToString();
                        lblIdMedecin.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement du médecin.");
                }
            }
        }

        private async Task ResetFormAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Agenda");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var liste = JsonConvert.DeserializeObject<List<Agenda>>(json);

                    dgAgenda.DataSource = liste
                        .Where(a => a.DatePlanifie >= DateTime.Now && a.IdMedecin == idMedecin)
                        .Select(a => new
                        {
                            a.IdAgenda,
                            a.DatePlanifie,
                            a.Titre,
                            a.HeureDebut,
                            a.HeureFin,
                            a.Creneau,
                            a.Lieu,
                            a.Statut
                        }).ToList();
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement des agendas.");
                }
            }

            txtCreneau.Text = string.Empty;
            txtDateAgenda.Value = DateTime.Now;
            txtHeureDebut.Text = string.Empty;
            txtHeureFin.Text = string.Empty;
            txtTitre.Text = string.Empty;
            txtLieu.Text = string.Empty;
            txtTitre.Focus();
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            var newAgenda = new Agenda
            {
                Creneau = int.Parse(txtCreneau.Text),
                HeureDebut = txtHeureDebut.Text,
                HeureFin = txtHeureFin.Text,
                IdMedecin = idMedecin,
                DatePlanifie = txtDateAgenda.Value,
                Statut = "brouillon",
                Lieu = txtLieu.Text,
                Titre = txtTitre.Text
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(newAgenda);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("Agenda", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Agenda ajouté avec succès !");
                    await ResetFormAsync();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'agenda.");
                }
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
