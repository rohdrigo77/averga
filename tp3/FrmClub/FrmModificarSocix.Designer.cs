
namespace FrmClub
{
    partial class FrmModificarSocix
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
            this.lblCartel = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDatosSocix = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtMedallas = new System.Windows.Forms.TextBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.txtPartidosJugados = new System.Windows.Forms.TextBox();
            this.txtCantidadPeleas = new System.Windows.Forms.TextBox();
            this.chkNombre = new System.Windows.Forms.CheckBox();
            this.chkApellido = new System.Windows.Forms.CheckBox();
            this.chkGenero = new System.Windows.Forms.CheckBox();
            this.chkEdad = new System.Windows.Forms.CheckBox();
            this.chkValorCuota = new System.Windows.Forms.CheckBox();
            this.chkMedallas = new System.Windows.Forms.CheckBox();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.chkPosicion = new System.Windows.Forms.CheckBox();
            this.chkPartidosJugados = new System.Windows.Forms.CheckBox();
            this.chkPileta = new System.Windows.Forms.CheckBox();
            this.chkEstilo = new System.Windows.Forms.CheckBox();
            this.chkPeso = new System.Windows.Forms.CheckBox();
            this.chkCantidadPeleas = new System.Windows.Forms.CheckBox();
            this.cmbValorCuota = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbPileta = new System.Windows.Forms.ComboBox();
            this.cmbEstiloPreferido = new System.Windows.Forms.ComboBox();
            this.cmbPeso = new System.Windows.Forms.ComboBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.chkTipoSocix = new System.Windows.Forms.CheckBox();
            this.cmbTipoSocix = new System.Windows.Forms.ComboBox();
            this.btnDni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCartel
            // 
            this.lblCartel.AutoSize = true;
            this.lblCartel.Location = new System.Drawing.Point(12, 25);
            this.lblCartel.Name = "lblCartel";
            this.lblCartel.Size = new System.Drawing.Size(210, 15);
            this.lblCartel.TabIndex = 1;
            this.lblCartel.Text = "Introduzca el dni del socix a modificar:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(12, 43);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(139, 23);
            this.txtDNI.TabIndex = 2;
            // 
            // lblDatosSocix
            // 
            this.lblDatosSocix.AutoSize = true;
            this.lblDatosSocix.Location = new System.Drawing.Point(12, 90);
            this.lblDatosSocix.Name = "lblDatosSocix";
            this.lblDatosSocix.Size = new System.Drawing.Size(149, 15);
            this.lblDatosSocix.TabIndex = 3;
            this.lblDatosSocix.Text = "Datos de socix a modificar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(7, 546);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(154, 35);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(167, 546);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(154, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(163, 117);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 23);
            this.txtNombre.TabIndex = 7;
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(163, 144);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(157, 23);
            this.txtApellido.TabIndex = 8;
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Location = new System.Drawing.Point(163, 201);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(156, 23);
            this.txtEdad.TabIndex = 10;
            // 
            // txtMedallas
            // 
            this.txtMedallas.Location = new System.Drawing.Point(163, 291);
            this.txtMedallas.Name = "txtMedallas";
            this.txtMedallas.Size = new System.Drawing.Size(157, 23);
            this.txtMedallas.TabIndex = 12;
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(163, 349);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(157, 23);
            this.txtPosicion.TabIndex = 14;
            // 
            // txtPartidosJugados
            // 
            this.txtPartidosJugados.Location = new System.Drawing.Point(163, 378);
            this.txtPartidosJugados.Name = "txtPartidosJugados";
            this.txtPartidosJugados.Size = new System.Drawing.Size(156, 23);
            this.txtPartidosJugados.TabIndex = 15;
            // 
            // txtCantidadPeleas
            // 
            this.txtCantidadPeleas.Location = new System.Drawing.Point(163, 494);
            this.txtCantidadPeleas.Name = "txtCantidadPeleas";
            this.txtCantidadPeleas.Size = new System.Drawing.Size(157, 23);
            this.txtCantidadPeleas.TabIndex = 19;
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Location = new System.Drawing.Point(22, 121);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(68, 19);
            this.chkNombre.TabIndex = 20;
            this.chkNombre.Text = "nombre";
            this.chkNombre.UseVisualStyleBackColor = true;
            this.chkNombre.CheckedChanged += new System.EventHandler(this.chkNombre_CheckedChanged);
            // 
            // chkApellido
            // 
            this.chkApellido.AutoSize = true;
            this.chkApellido.Location = new System.Drawing.Point(22, 148);
            this.chkApellido.Name = "chkApellido";
            this.chkApellido.Size = new System.Drawing.Size(68, 19);
            this.chkApellido.TabIndex = 21;
            this.chkApellido.Text = "apellido";
            this.chkApellido.UseVisualStyleBackColor = true;
            this.chkApellido.CheckedChanged += new System.EventHandler(this.chkApellido_CheckedChanged);
            // 
            // chkGenero
            // 
            this.chkGenero.AutoSize = true;
            this.chkGenero.Location = new System.Drawing.Point(22, 176);
            this.chkGenero.Name = "chkGenero";
            this.chkGenero.Size = new System.Drawing.Size(63, 19);
            this.chkGenero.TabIndex = 22;
            this.chkGenero.Text = "genero";
            this.chkGenero.UseVisualStyleBackColor = true;
            this.chkGenero.CheckedChanged += new System.EventHandler(this.chkGenero_CheckedChanged);
            // 
            // chkEdad
            // 
            this.chkEdad.AutoSize = true;
            this.chkEdad.Location = new System.Drawing.Point(22, 205);
            this.chkEdad.Name = "chkEdad";
            this.chkEdad.Size = new System.Drawing.Size(52, 19);
            this.chkEdad.TabIndex = 23;
            this.chkEdad.Text = "edad";
            this.chkEdad.UseVisualStyleBackColor = true;
            this.chkEdad.CheckedChanged += new System.EventHandler(this.chkEdad_CheckedChanged);
            // 
            // chkValorCuota
            // 
            this.chkValorCuota.AutoSize = true;
            this.chkValorCuota.Location = new System.Drawing.Point(22, 234);
            this.chkValorCuota.Name = "chkValorCuota";
            this.chkValorCuota.Size = new System.Drawing.Size(84, 19);
            this.chkValorCuota.TabIndex = 24;
            this.chkValorCuota.Text = "valorCuota";
            this.chkValorCuota.UseVisualStyleBackColor = true;
            this.chkValorCuota.CheckedChanged += new System.EventHandler(this.chkValorCuota_CheckedChanged);
            // 
            // chkMedallas
            // 
            this.chkMedallas.AutoSize = true;
            this.chkMedallas.Location = new System.Drawing.Point(22, 295);
            this.chkMedallas.Name = "chkMedallas";
            this.chkMedallas.Size = new System.Drawing.Size(73, 19);
            this.chkMedallas.TabIndex = 25;
            this.chkMedallas.Text = "medallas";
            this.chkMedallas.UseVisualStyleBackColor = true;
            this.chkMedallas.CheckedChanged += new System.EventHandler(this.chkMedallas_CheckedChanged);
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Location = new System.Drawing.Point(22, 324);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(75, 19);
            this.chkCategoria.TabIndex = 26;
            this.chkCategoria.Text = "categoria";
            this.chkCategoria.UseVisualStyleBackColor = true;
            this.chkCategoria.CheckedChanged += new System.EventHandler(this.chkCategoria_CheckedChanged);
            // 
            // chkPosicion
            // 
            this.chkPosicion.AutoSize = true;
            this.chkPosicion.Location = new System.Drawing.Point(22, 353);
            this.chkPosicion.Name = "chkPosicion";
            this.chkPosicion.Size = new System.Drawing.Size(71, 19);
            this.chkPosicion.TabIndex = 27;
            this.chkPosicion.Text = "posicion";
            this.chkPosicion.UseVisualStyleBackColor = true;
            this.chkPosicion.CheckedChanged += new System.EventHandler(this.chkPosicion_CheckedChanged);
            // 
            // chkPartidosJugados
            // 
            this.chkPartidosJugados.AutoSize = true;
            this.chkPartidosJugados.Location = new System.Drawing.Point(22, 382);
            this.chkPartidosJugados.Name = "chkPartidosJugados";
            this.chkPartidosJugados.Size = new System.Drawing.Size(112, 19);
            this.chkPartidosJugados.TabIndex = 28;
            this.chkPartidosJugados.Text = "partidosJugados";
            this.chkPartidosJugados.UseVisualStyleBackColor = true;
            this.chkPartidosJugados.CheckedChanged += new System.EventHandler(this.chkPartidosJugados_CheckedChanged);
            // 
            // chkPileta
            // 
            this.chkPileta.AutoSize = true;
            this.chkPileta.Location = new System.Drawing.Point(22, 411);
            this.chkPileta.Name = "chkPileta";
            this.chkPileta.Size = new System.Drawing.Size(55, 19);
            this.chkPileta.TabIndex = 29;
            this.chkPileta.Text = "pileta";
            this.chkPileta.UseVisualStyleBackColor = true;
            this.chkPileta.CheckedChanged += new System.EventHandler(this.chkTipoPileta_CheckedChanged);
            // 
            // chkEstilo
            // 
            this.chkEstilo.AutoSize = true;
            this.chkEstilo.Location = new System.Drawing.Point(22, 440);
            this.chkEstilo.Name = "chkEstilo";
            this.chkEstilo.Size = new System.Drawing.Size(102, 19);
            this.chkEstilo.TabIndex = 30;
            this.chkEstilo.Text = "estiloPreferido";
            this.chkEstilo.UseVisualStyleBackColor = true;
            this.chkEstilo.CheckedChanged += new System.EventHandler(this.chkEstilo_CheckedChanged);
            // 
            // chkPeso
            // 
            this.chkPeso.AutoSize = true;
            this.chkPeso.Location = new System.Drawing.Point(22, 469);
            this.chkPeso.Name = "chkPeso";
            this.chkPeso.Size = new System.Drawing.Size(51, 19);
            this.chkPeso.TabIndex = 31;
            this.chkPeso.Text = "peso";
            this.chkPeso.UseVisualStyleBackColor = true;
            this.chkPeso.CheckedChanged += new System.EventHandler(this.chkCategoriaPeso_CheckedChanged);
            // 
            // chkCantidadPeleas
            // 
            this.chkCantidadPeleas.AutoSize = true;
            this.chkCantidadPeleas.Location = new System.Drawing.Point(22, 498);
            this.chkCantidadPeleas.Name = "chkCantidadPeleas";
            this.chkCantidadPeleas.Size = new System.Drawing.Size(105, 19);
            this.chkCantidadPeleas.TabIndex = 32;
            this.chkCantidadPeleas.Text = "cantidadPeleas";
            this.chkCantidadPeleas.UseVisualStyleBackColor = true;
            this.chkCantidadPeleas.CheckedChanged += new System.EventHandler(this.chkCantidadPeleas_CheckedChanged);
            // 
            // cmbValorCuota
            // 
            this.cmbValorCuota.FormattingEnabled = true;
            this.cmbValorCuota.Location = new System.Drawing.Point(163, 230);
            this.cmbValorCuota.Name = "cmbValorCuota";
            this.cmbValorCuota.Size = new System.Drawing.Size(156, 23);
            this.cmbValorCuota.TabIndex = 33;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(163, 320);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(156, 23);
            this.cmbCategoria.TabIndex = 34;
            // 
            // cmbPileta
            // 
            this.cmbPileta.FormattingEnabled = true;
            this.cmbPileta.Location = new System.Drawing.Point(163, 407);
            this.cmbPileta.Name = "cmbPileta";
            this.cmbPileta.Size = new System.Drawing.Size(157, 23);
            this.cmbPileta.TabIndex = 35;
            // 
            // cmbEstiloPreferido
            // 
            this.cmbEstiloPreferido.FormattingEnabled = true;
            this.cmbEstiloPreferido.Location = new System.Drawing.Point(163, 436);
            this.cmbEstiloPreferido.Name = "cmbEstiloPreferido";
            this.cmbEstiloPreferido.Size = new System.Drawing.Size(157, 23);
            this.cmbEstiloPreferido.TabIndex = 36;
            // 
            // cmbPeso
            // 
            this.cmbPeso.FormattingEnabled = true;
            this.cmbPeso.Location = new System.Drawing.Point(163, 466);
            this.cmbPeso.Name = "cmbPeso";
            this.cmbPeso.Size = new System.Drawing.Size(157, 23);
            this.cmbPeso.TabIndex = 37;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(164, 172);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(156, 23);
            this.cmbGenero.TabIndex = 38;
            // 
            // chkTipoSocix
            // 
            this.chkTipoSocix.AutoSize = true;
            this.chkTipoSocix.Location = new System.Drawing.Point(22, 263);
            this.chkTipoSocix.Name = "chkTipoSocix";
            this.chkTipoSocix.Size = new System.Drawing.Size(75, 19);
            this.chkTipoSocix.TabIndex = 39;
            this.chkTipoSocix.Text = "tipoSocix";
            this.chkTipoSocix.UseVisualStyleBackColor = true;
            this.chkTipoSocix.CheckedChanged += new System.EventHandler(this.chkTipoSocix_CheckedChanged);
            // 
            // cmbTipoSocix
            // 
            this.cmbTipoSocix.FormattingEnabled = true;
            this.cmbTipoSocix.Location = new System.Drawing.Point(163, 259);
            this.cmbTipoSocix.Name = "cmbTipoSocix";
            this.cmbTipoSocix.Size = new System.Drawing.Size(156, 23);
            this.cmbTipoSocix.TabIndex = 40;
            // 
            // btnDni
            // 
            this.btnDni.Location = new System.Drawing.Point(163, 43);
            this.btnDni.Name = "btnDni";
            this.btnDni.Size = new System.Drawing.Size(156, 23);
            this.btnDni.TabIndex = 41;
            this.btnDni.Text = "Verificar";
            this.btnDni.UseVisualStyleBackColor = true;
            this.btnDni.Click += new System.EventHandler(this.btnDni_Click);
            // 
            // FrmModificarSocix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 593);
            this.Controls.Add(this.btnDni);
            this.Controls.Add(this.cmbTipoSocix);
            this.Controls.Add(this.chkTipoSocix);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.cmbPeso);
            this.Controls.Add(this.cmbEstiloPreferido);
            this.Controls.Add(this.cmbPileta);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbValorCuota);
            this.Controls.Add(this.chkCantidadPeleas);
            this.Controls.Add(this.chkPeso);
            this.Controls.Add(this.chkEstilo);
            this.Controls.Add(this.chkPileta);
            this.Controls.Add(this.chkPartidosJugados);
            this.Controls.Add(this.chkPosicion);
            this.Controls.Add(this.chkCategoria);
            this.Controls.Add(this.chkMedallas);
            this.Controls.Add(this.chkValorCuota);
            this.Controls.Add(this.chkEdad);
            this.Controls.Add(this.chkGenero);
            this.Controls.Add(this.chkApellido);
            this.Controls.Add(this.chkNombre);
            this.Controls.Add(this.txtCantidadPeleas);
            this.Controls.Add(this.txtPartidosJugados);
            this.Controls.Add(this.txtPosicion);
            this.Controls.Add(this.txtMedallas);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDatosSocix);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblCartel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarSocix";
            this.Text = "FrmModificarSocix";
            this.Load += new System.EventHandler(this.FrmModificarSocix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCartel;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDatosSocix;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtMedallas;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.TextBox txtPartidosJugados;
        private System.Windows.Forms.TextBox txtCantidadPeleas;
        private System.Windows.Forms.CheckBox chkNombre;
        private System.Windows.Forms.CheckBox chkApellido;
        private System.Windows.Forms.CheckBox chkGenero;
        private System.Windows.Forms.CheckBox chkEdad;
        private System.Windows.Forms.CheckBox chkValorCuota;
        private System.Windows.Forms.CheckBox chkMedallas;
        private System.Windows.Forms.CheckBox chkCategoria;
        private System.Windows.Forms.CheckBox chkPosicion;
        private System.Windows.Forms.CheckBox chkPartidosJugados;
        private System.Windows.Forms.CheckBox chkPileta;
        private System.Windows.Forms.CheckBox chkEstilo;
        private System.Windows.Forms.CheckBox chkPeso;
        private System.Windows.Forms.CheckBox chkCantidadPeleas;
        private System.Windows.Forms.ComboBox cmbValorCuota;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbPileta;
        private System.Windows.Forms.ComboBox cmbEstiloPreferido;
        private System.Windows.Forms.ComboBox cmbPeso;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.CheckBox chkTipoSocix;
        private System.Windows.Forms.ComboBox cmbTipoSocix;
        private System.Windows.Forms.Button btnDni;
    }
}