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
    public partial class frmMedecin : Form
    {
        public frmMedecin()
        {
            InitializeComponent();
        }


        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            Medecin m = new Medecin
            {
                Adresse = txtAdresse.Text,
                NumeroOrdre = txtNumeroOrdreMedecin.Text,
                Tel = txtTel.Text,
                Email = txtEmail.Text,
                NomPrenom = txtNomPrenom.Text,
                IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString()),
                Identifiant = txtIdentifiant.Text,
                Statut = false
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(m);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Medecin", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Médecin ajouté avec succès !");
                    await LoadMedecinsAsync();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l’ajout !");
                }
            }
        }
        private async Task LoadMedecinsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                var response = await client.GetAsync("Medecin");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var medecins = JsonConvert.DeserializeObject<List<Medecin>>(json);
                    dgMedecin.DataSource = medecins.Select(a => new {
                        a.IdU,
                        a.NumeroOrdre,
                        a.Identifiant,
                        a.Specialite?.NomSpecialite,
                        a.NomPrenom,
                        a.Tel,
                        a.Email
                    }).ToList();
                }
            }
        }

        private async Task ResetForm()
        {
            txtAdresse.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtIdentifiant.Text = String.Empty;
            txtNumeroOrdreMedecin.Text = String.Empty;
            txtNomPrenom.Text = String.Empty;
            txtTel.Text = String.Empty;

            // Charger combo Specialite depuis l'API
            cbbSpecialite.DataSource = await LoadCbbSpecialiteAsync();
            cbbSpecialite.ValueMember = "Value";
            cbbSpecialite.DisplayMember = "Text";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Medecin");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var medecins = JsonConvert.DeserializeObject<List<Medecin>>(json);

                    dgMedecin.DataSource = medecins.Select(a => new
                    {
                        a.IdU,
                        a.NumeroOrdre,
                        a.Identifiant,
                        Specialite = a.Specialite?.NomSpecialite,
                        a.NomPrenom,
                        a.Tel,
                        a.Email
                    }).ToList();
                }
            }

            txtNomPrenom.Focus();
        }


        private async void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                HttpResponseMessage response = await client.GetAsync($"Medecin/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var m = JsonConvert.DeserializeObject<Medecin>(json);

                    if (m != null)
                    {
                        txtAdresse.Text = m.Adresse;
                        txtEmail.Text = m.Email;
                        txtIdentifiant.Text = m.Identifiant;
                        txtNomPrenom.Text = m.NomPrenom;
                        txtNumeroOrdreMedecin.Text = m.NumeroOrdre;
                        cbbSpecialite.SelectedValue = m.IdSpecialite?.ToString();
                        txtTel.Text = m.Tel;
                    }
                }
            }
        }


        private async void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            Medecin m = new Medecin
            {
                IdU = id.Value,
                Adresse = txtAdresse.Text,
                NumeroOrdre = txtNumeroOrdreMedecin.Text,
                Tel = txtTel.Text,
                Email = txtEmail.Text,
                NomPrenom = txtNomPrenom.Text,
                IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString()),
                Identifiant = txtIdentifiant.Text
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(m);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"Medecin/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Médecin modifié !");
                    await LoadMedecinsAsync();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification !");
                }
            }
        }


        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                var response = await client.DeleteAsync($"Medecin/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Médecin supprimé !");
                    await LoadMedecinsAsync();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression !");
                }
            }
        }


        private void frmMedecin_Load(object sender, EventArgs e)
        {
            ResetForm();

        }

        private async Task<List<SelectListViewModel>> LoadCbbSpecialiteAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                var response = await client.GetAsync("Specialite");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var specialites = JsonConvert.DeserializeObject<List<Specialite>>(json);

                    List<SelectListViewModel> liste = new List<SelectListViewModel>
            {
                new SelectListViewModel { Text = "Selectionnez .......", Value = "" }
            };

                    foreach (var c in specialites)
                    {
                        liste.Add(new SelectListViewModel
                        {
                            Text = c.NomSpecialite,
                            Value = c.IdSpecialite.ToString()
                        });
                    }
                    return liste;
                }
                return new List<SelectListViewModel>();
            }
        }



        private void btnAgenda_Click(object sender, EventArgs e)
        {
            dgAgenda a = new dgAgenda();
            a.idMedecin = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            a.Show();
        }

       
    }
}
