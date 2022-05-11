
namespace FrmClub
{
    partial class FrmInformes
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
            this.btnMedallasSegunGenero = new System.Windows.Forms.Button();
            this.btnSocixsCompetitivos = new System.Windows.Forms.Button();
            this.btnDeporteNinixs = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMedallasSegunGenero
            // 
            this.btnMedallasSegunGenero.Location = new System.Drawing.Point(12, 12);
            this.btnMedallasSegunGenero.Name = "btnMedallasSegunGenero";
            this.btnMedallasSegunGenero.Size = new System.Drawing.Size(305, 58);
            this.btnMedallasSegunGenero.TabIndex = 0;
            this.btnMedallasSegunGenero.Text = "Porcentaje de medallas según género";
            this.btnMedallasSegunGenero.UseVisualStyleBackColor = true;
            this.btnMedallasSegunGenero.Click += new System.EventHandler(this.btnMedallasSegunGenero_Click);
            // 
            // btnSocixsCompetitivos
            // 
            this.btnSocixsCompetitivos.Location = new System.Drawing.Point(12, 76);
            this.btnSocixsCompetitivos.Name = "btnSocixsCompetitivos";
            this.btnSocixsCompetitivos.Size = new System.Drawing.Size(305, 58);
            this.btnSocixsCompetitivos.TabIndex = 1;
            this.btnSocixsCompetitivos.Text = "Porcentaje de Socixs competitivos según deporte";
            this.btnSocixsCompetitivos.UseVisualStyleBackColor = true;
            this.btnSocixsCompetitivos.Click += new System.EventHandler(this.btnSocixsCompetitivos_Click);
            // 
            // btnDeporteNinixs
            // 
            this.btnDeporteNinixs.Location = new System.Drawing.Point(12, 138);
            this.btnDeporteNinixs.Name = "btnDeporteNinixs";
            this.btnDeporteNinixs.Size = new System.Drawing.Size(305, 58);
            this.btnDeporteNinixs.TabIndex = 2;
            this.btnDeporteNinixs.Text = "Porcentaje de niñxs según deporte";
            this.btnDeporteNinixs.UseVisualStyleBackColor = true;
            this.btnDeporteNinixs.Click += new System.EventHandler(this.btnDeporteNinixs_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 202);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(305, 58);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 274);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnDeporteNinixs);
            this.Controls.Add(this.btnSocixsCompetitivos);
            this.Controls.Add(this.btnMedallasSegunGenero);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformes";
            this.Text = "Informes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMedallasSegunGenero;
        private System.Windows.Forms.Button btnSocixsCompetitivos;
        private System.Windows.Forms.Button btnDeporteNinixs;
        private System.Windows.Forms.Button btnSalir;
    }
}