
namespace FrmClub
{
    partial class FrmClub
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.cargarSocixBtn = new System.Windows.Forms.Button();
            this.listSocixsBtn = new System.Windows.Forms.Button();
            this.informesBtn = new System.Windows.Forms.Button();
            this.modificarSocixBtn = new System.Windows.Forms.Button();
            this.btnCargarListaArchivo = new System.Windows.Forms.Button();
            this.btnGuardarListaArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(487, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(8, 8);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // cargarSocixBtn
            // 
            this.cargarSocixBtn.Location = new System.Drawing.Point(12, 12);
            this.cargarSocixBtn.Name = "cargarSocixBtn";
            this.cargarSocixBtn.Size = new System.Drawing.Size(264, 73);
            this.cargarSocixBtn.TabIndex = 4;
            this.cargarSocixBtn.Text = "Cargar Socix";
            this.cargarSocixBtn.UseVisualStyleBackColor = true;
            this.cargarSocixBtn.Click += new System.EventHandler(this.cargarSocixBtn_Click);
            // 
            // listSocixsBtn
            // 
            this.listSocixsBtn.Location = new System.Drawing.Point(12, 170);
            this.listSocixsBtn.Name = "listSocixsBtn";
            this.listSocixsBtn.Size = new System.Drawing.Size(264, 73);
            this.listSocixsBtn.TabIndex = 8;
            this.listSocixsBtn.Text = "Listar Socixs";
            this.listSocixsBtn.UseVisualStyleBackColor = true;
            this.listSocixsBtn.Click += new System.EventHandler(this.listSocixsBtn_Click);
            // 
            // informesBtn
            // 
            this.informesBtn.Location = new System.Drawing.Point(12, 249);
            this.informesBtn.Name = "informesBtn";
            this.informesBtn.Size = new System.Drawing.Size(264, 73);
            this.informesBtn.TabIndex = 9;
            this.informesBtn.Text = "Informes";
            this.informesBtn.UseVisualStyleBackColor = true;
            this.informesBtn.Click += new System.EventHandler(this.informesBtn_Click);
            // 
            // modificarSocixBtn
            // 
            this.modificarSocixBtn.Location = new System.Drawing.Point(12, 91);
            this.modificarSocixBtn.Name = "modificarSocixBtn";
            this.modificarSocixBtn.Size = new System.Drawing.Size(264, 73);
            this.modificarSocixBtn.TabIndex = 10;
            this.modificarSocixBtn.Text = "Modificar Socix";
            this.modificarSocixBtn.UseVisualStyleBackColor = true;
            this.modificarSocixBtn.Click += new System.EventHandler(this.modificarSocixBtn_Click);
            // 
            // btnCargarListaArchivo
            // 
            this.btnCargarListaArchivo.Location = new System.Drawing.Point(12, 328);
            this.btnCargarListaArchivo.Name = "btnCargarListaArchivo";
            this.btnCargarListaArchivo.Size = new System.Drawing.Size(264, 72);
            this.btnCargarListaArchivo.TabIndex = 11;
            this.btnCargarListaArchivo.Text = "Cargar lista de socixs desde archivo";
            this.btnCargarListaArchivo.UseVisualStyleBackColor = true;
            this.btnCargarListaArchivo.Click += new System.EventHandler(this.btnCargarListaArchivo_Click);
            // 
            // btnGuardarListaArchivo
            // 
            this.btnGuardarListaArchivo.Location = new System.Drawing.Point(13, 407);
            this.btnGuardarListaArchivo.Name = "btnGuardarListaArchivo";
            this.btnGuardarListaArchivo.Size = new System.Drawing.Size(263, 72);
            this.btnGuardarListaArchivo.TabIndex = 12;
            this.btnGuardarListaArchivo.Text = "Guardar lista de socixs a archivo";
            this.btnGuardarListaArchivo.UseVisualStyleBackColor = true;
            this.btnGuardarListaArchivo.Click += new System.EventHandler(this.btnGuardarListaArchivo_Click);
            // 
            // FrmClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 491);
            this.Controls.Add(this.btnGuardarListaArchivo);
            this.Controls.Add(this.btnCargarListaArchivo);
            this.Controls.Add(this.modificarSocixBtn);
            this.Controls.Add(this.informesBtn);
            this.Controls.Add(this.listSocixsBtn);
            this.Controls.Add(this.cargarSocixBtn);
            this.Controls.Add(this.button4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClub";
            this.Text = "Club Social Los Puentes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClub_FormClosing);
            this.Load += new System.EventHandler(this.FrmClub_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cargarSocixBtn;
        private System.Windows.Forms.Button listSocixsBtn;
        private System.Windows.Forms.Button informesBtn;
        private System.Windows.Forms.Button modificarSocixBtn;
        private System.Windows.Forms.Button btnCargarListaArchivo;
        private System.Windows.Forms.Button btnGuardarListaArchivo;
    }
}

