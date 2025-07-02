namespace GestionRV.View
{
    partial class frmRendezVous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRendezVous = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbbPatient = new System.Windows.Forms.ComboBox();
            this.cbbMedecin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbSoin = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgenda
            // 
            this.btnAgenda.Location = new System.Drawing.Point(692, 21);
            this.btnAgenda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(86, 32);
            this.btnAgenda.TabIndex = 54;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = true;
            // 
            // btnChoisir
            // 
            this.btnChoisir.Location = new System.Drawing.Point(562, 21);
            this.btnChoisir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(72, 32);
            this.btnChoisir.TabIndex = 48;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(316, 549);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(107, 32);
            this.btnSupprimer.TabIndex = 51;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(186, 549);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(74, 32);
            this.btnModifier.TabIndex = 49;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(55, 549);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(72, 32);
            this.btnAjouter.TabIndex = 46;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Date RV";
            //this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Soin";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(52, 270);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(186, 26);
            this.txtEmail.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Patient";
            // 
            // dgRendezVous
            // 
            this.dgRendezVous.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgRendezVous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRendezVous.Location = new System.Drawing.Point(562, 61);
            this.dgRendezVous.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgRendezVous.Name = "dgRendezVous";
            this.dgRendezVous.RowHeadersWidth = 51;
            this.dgRendezVous.RowTemplate.Height = 24;
            this.dgRendezVous.Size = new System.Drawing.Size(747, 650);
            this.dgRendezVous.TabIndex = 35;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1216, 21);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 32);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(52, 494);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 56;
            // 
            // cbbPatient
            // 
            this.cbbPatient.FormattingEnabled = true;
            this.cbbPatient.Location = new System.Drawing.Point(56, 99);
            this.cbbPatient.Name = "cbbPatient";
            this.cbbPatient.Size = new System.Drawing.Size(182, 28);
            this.cbbPatient.TabIndex = 57;
            // 
            // cbbMedecin
            // 
            this.cbbMedecin.FormattingEnabled = true;
            this.cbbMedecin.Location = new System.Drawing.Point(56, 197);
            this.cbbMedecin.Name = "cbbMedecin";
            this.cbbMedecin.Size = new System.Drawing.Size(182, 28);
            this.cbbMedecin.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Medecin";
            // 
            // cbbSoin
            // 
            this.cbbSoin.FormattingEnabled = true;
            this.cbbSoin.Location = new System.Drawing.Point(55, 358);
            this.cbbSoin.Name = "cbbSoin";
            this.cbbSoin.Size = new System.Drawing.Size(182, 28);
            this.cbbSoin.TabIndex = 60;
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 790);
            this.ControlBox = false;
            this.Controls.Add(this.cbbSoin);
            this.Controls.Add(this.cbbMedecin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbPatient);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAgenda);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgRendezVous);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRendezVous";
            this.Text = "Rendez-Vous";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
//            this.Leave += new System.EventHandler(this.frmRendezVous_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRendezVous;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbbPatient;
        private System.Windows.Forms.ComboBox cbbMedecin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbSoin;
    }
}