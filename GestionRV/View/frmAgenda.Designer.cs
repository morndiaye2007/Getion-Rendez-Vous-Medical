﻿namespace GestionRV.View
{
    partial class dgAgenda
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
            this.btnChoisir = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeureFin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeureDebut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgMedecin = new System.Windows.Forms.DataGridView();
            this.txtDateAgenda = new System.Windows.Forms.DateTimePicker();
            this.btnFermer = new System.Windows.Forms.Button();
            this.txtCreneau = new System.Windows.Forms.TextBox();
            this.lblMedecin = new System.Windows.Forms.Label();
            this.lblIdMedecin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedecin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoisir
            // 
            this.btnChoisir.Location = new System.Drawing.Point(640, 31);
            this.btnChoisir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(98, 32);
            this.btnChoisir.TabIndex = 48;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(299, 680);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(98, 32);
            this.btnSupprimer.TabIndex = 51;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(169, 680);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(98, 32);
            this.btnModifier.TabIndex = 49;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(38, 680);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(98, 32);
            this.btnAjouter.TabIndex = 46;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Creneau";
            // 
            // txtLieu
            // 
            this.txtLieu.Location = new System.Drawing.Point(35, 450);
            this.txtLieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLieu.Name = "txtLieu";
            this.txtLieu.Size = new System.Drawing.Size(258, 26);
            this.txtLieu.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Lieu";
            // 
            // txtHeureFin
            // 
            this.txtHeureFin.Location = new System.Drawing.Point(35, 365);
            this.txtHeureFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeureFin.Name = "txtHeureFin";
            this.txtHeureFin.Size = new System.Drawing.Size(258, 26);
            this.txtHeureFin.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Heure Fin";
            // 
            // txtHeureDebut
            // 
            this.txtHeureDebut.Location = new System.Drawing.Point(35, 280);
            this.txtHeureDebut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeureDebut.Name = "txtHeureDebut";
            this.txtHeureDebut.Size = new System.Drawing.Size(258, 26);
            this.txtHeureDebut.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Heure Debut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Date";
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(35, 110);
            this.txtTitre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(258, 26);
            this.txtTitre.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Titre";
            // 
            // dgMedecin
            // 
            this.dgMedecin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgMedecin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMedecin.Location = new System.Drawing.Point(640, 71);
            this.dgMedecin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgMedecin.Name = "dgMedecin";
            this.dgMedecin.RowHeadersWidth = 51;
            this.dgMedecin.RowTemplate.Height = 24;
            this.dgMedecin.Size = new System.Drawing.Size(819, 650);
            this.dgMedecin.TabIndex = 36;
            // 
            // txtDateAgenda
            // 
            this.txtDateAgenda.Location = new System.Drawing.Point(35, 198);
            this.txtDateAgenda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDateAgenda.Name = "txtDateAgenda";
            this.txtDateAgenda.Size = new System.Drawing.Size(258, 26);
            this.txtDateAgenda.TabIndex = 56;
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(1332, 31);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(98, 32);
            this.btnFermer.TabIndex = 58;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // txtCreneau
            // 
            this.txtCreneau.Location = new System.Drawing.Point(35, 555);
            this.txtCreneau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreneau.Name = "txtCreneau";
            this.txtCreneau.Size = new System.Drawing.Size(258, 26);
            this.txtCreneau.TabIndex = 59;
            // 
            // lblMedecin
            // 
            this.lblMedecin.AutoSize = true;
            this.lblMedecin.Location = new System.Drawing.Point(35, 605);
            this.lblMedecin.Name = "lblMedecin";
            this.lblMedecin.Size = new System.Drawing.Size(0, 20);
            this.lblMedecin.TabIndex = 60;
            // 
            // lblIdMedecin
            // 
            this.lblIdMedecin.AutoSize = true;
            this.lblIdMedecin.Location = new System.Drawing.Point(151, 605);
            this.lblIdMedecin.Name = "lblIdMedecin";
            this.lblIdMedecin.Size = new System.Drawing.Size(0, 20);
            this.lblIdMedecin.TabIndex = 61;
            // 
            // dgAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 754);
            this.ControlBox = false;
            this.Controls.Add(this.lblIdMedecin);
            this.Controls.Add(this.lblMedecin);
            this.Controls.Add(this.txtCreneau);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.txtDateAgenda);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHeureFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeureDebut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgMedecin);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "dgAgenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.frmAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMedecin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHeureFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeureDebut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgMedecin;
        private System.Windows.Forms.DateTimePicker txtDateAgenda;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.TextBox txtCreneau;
        private System.Windows.Forms.Label lblMedecin;
        private System.Windows.Forms.Label lblIdMedecin;
    }
}