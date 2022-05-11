using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Data.SqlClient;

namespace FrmClub
{
    
    public partial class FrmModificarSocix : Form
    {
        List<TextBox> cajasDeTexto = new List<TextBox>();
        List<ComboBox> comboCajas = new List<ComboBox>();
        List<CheckBox> cajasCheck = new List<CheckBox>();      
        FrmListDatos frmListDatos = new FrmListDatos("Select * from Socixs");
        public event ActualizarDataGrid actualizarDG;
        public event ActualizarDataGridConDni actualizarDGDni;
        Socix socix;
        List<Socix> listaSocix;
        Task tarea;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FrmModificarSocix()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// Metodo manejador que verifica que los campos de los txtBox esten completados, asigna los valores validandolos, muestra un cuadro de texto con los datos modificados y solicita confirmacion para guardar el socix modificado en la base de datos y en la lista de socixs actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder camposModificados = new StringBuilder();
            StringBuilder stringValue = new StringBuilder();
            string txtValue = "";

            camposModificados.AppendLine("Campos modificados:");
            camposModificados.AppendLine(" ");


            try 
            {
                for (int i = 0; i < cajasCheck.Count; i++)
                {
                    if (cajasCheck[i].CheckState == CheckState.Checked)
                    {

                        stringValue.AppendLine($"{cajasCheck[i].Text} = ");

                        foreach (TextBox cajita in cajasDeTexto)
                        {
                            string resto = cajasCheck[i].Text.Remove(0, 1);
                            bool contains = cajita.Name.IndexOf($"txt{char.ToUpper(cajasCheck[i].Text[0])}{resto}", StringComparison.OrdinalIgnoreCase) == 0;

                            if (contains)
                            {
                                txtValue = cajita.Text;
                                switch (cajasCheck[i].Text)
                                {
                                    case "nombre":
                                        socix.Nombre = cajita.Text;
                                        break;
                                    case "apellido":
                                        socix.Apellido = cajita.Text;
                                        break;
                                    case "edad":
                                        socix.Edad = int.Parse(cajita.Text);
                                        break;
                                    case "medallas":
                                        socix.CantidadMedallas = int.Parse(cajita.Text);
                                        break;
                                    case "posicion":
                                        ((Futbolista)socix).Posicion = int.Parse(cajita.Text);
                                        break;
                                    case "partidosJugados":
                                        ((Futbolista)socix).PartidosJugados = int.Parse(cajita.Text);
                                        break;
                                    case "cantidadPeleas":
                                        ((Pugilista)socix).CantidadPeleas = int.Parse(cajita.Text);
                                        break;
                                }
                                stringValue.Append($"{txtValue}");
                                break;
                            }
                        }

                        foreach (ComboBox cajita in comboCajas)
                        {
                            string resto = cajasCheck[i].Text.Remove(0, 1);
                            bool contains = cajita.Name.IndexOf($"cmb{char.ToUpper(cajasCheck[i].Text[0])}{resto}", StringComparison.OrdinalIgnoreCase) == 0;

                            if (contains)
                            {
                                txtValue = cajita.Text;
                                switch (cajasCheck[i].Text)
                                {
                                    case "genero":
                                        socix.Genero = Enum.Parse<EGenero>(cajita.Text);
                                        break;
                                    case "valorCuota":
                                        socix.ValorCuota = Enum.Parse<ECuota>(cajita.Text);
                                        break;
                                    case "tipoSocix":
                                        socix.TipoSocix = Enum.Parse<ETipoSocix>(cajita.Text);
                                        break;
                                    case "categoria":
                                        ((Futbolista)socix).Categoria = Enum.Parse<ECategoria>(cajita.Text);
                                        break;
                                    case "pileta":
                                        ((Nadador)socix).TipoPileta = Enum.Parse<EPileta>(cajita.Text);
                                        break;
                                    case "estiloPreferido":
                                        ((Nadador)socix).EstiloPreferido = Enum.Parse<EEstilos>(cajita.Text);
                                        break;
                                    case "peso":
                                        ((Pugilista)socix).CategoriaPeso = Enum.Parse<EPeso>(cajita.Text);
                                        break;
                                }
                                break;
                            }
                        }

                        camposModificados.AppendLine($" {cajasCheck[i].Text} = {txtValue}");

                        if (!(i == cajasCheck.Count -1))
                        {
                            camposModificados.Append(",");
                        }

                    }
                }

                camposModificados.AppendLine("");
                camposModificados.AppendLine("¿Guardar Cambios?");

                if (MessageBox.Show($"{camposModificados}", "Socix Modificado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    (new GestorBaseDeDatos()).ActualizarSocix(socix);

                    Task tareaDos = Task.Run(() => this.ActualizarEventDni(int.Parse(txtDNI.Text)));
                    
                    MessageBox.Show("Socix modificadx exitosamente.", "Socix Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        /// <summary>
        /// Metodo manejador que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chkCantidadPeleas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCantidadPeleas.CheckState == CheckState.Checked)
            {
                txtCantidadPeleas.Enabled = true;
            }
            else
            {
                txtCantidadPeleas.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNombre.CheckState == CheckState.Checked)
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkApellido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApellido.CheckState == CheckState.Checked)
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenero.CheckState == CheckState.Checked)
            {
                cmbGenero.Enabled = true;
            }
            else
            {
                cmbGenero.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEdad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdad.CheckState == CheckState.Checked)
            {
                txtEdad.Enabled = true;
            }
            else
            {
                txtEdad.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkValorCuota_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValorCuota.CheckState == CheckState.Checked)
            {
                cmbValorCuota.Enabled = true;
            }
            else
            {
                cmbValorCuota.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chkMedallas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMedallas.CheckState == CheckState.Checked)
            {
                txtMedallas.Enabled = true;
            }
            else
            {
                txtMedallas.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.CheckState == CheckState.Checked)
            {
                cmbCategoria.Enabled = true;
            }
            else
            {
                cmbCategoria.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPosicion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPosicion.CheckState == CheckState.Checked)
            {
                txtPosicion.Enabled = true;
            }
            else
            {
                txtPosicion.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPartidosJugados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPartidosJugados.CheckState == CheckState.Checked)
            {
                txtPartidosJugados.Enabled = true;
            }
            else
            {
                txtPartidosJugados.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTipoPileta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPileta.CheckState == CheckState.Checked)
            {
                cmbPileta.Enabled = true;
            }
            else
            {
                cmbPileta.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chkEstilo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstilo.CheckState == CheckState.Checked)
            {
                cmbEstiloPreferido.Enabled = true;
            }
            else
            {
                cmbEstiloPreferido.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCategoriaPeso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeso.CheckState == CheckState.Checked)
            {
                cmbPeso.Enabled = true;
            }
            else
            {
                cmbPeso.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que puebla los cmb con enumerados, agrega a las listas de boxes sus diferentes tipos existentes, agrega manejadores a los eventos, instancia el atributo listaSocix y lanza el formulario de mostrardatos en un hilo paralelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FrmModificarSocix_Load(object sender, EventArgs e)
        {
            try
            {
                cajasDeTexto.Add(txtNombre);
                cajasDeTexto.Add(txtApellido);
                cajasDeTexto.Add(txtEdad);
                cajasDeTexto.Add(txtMedallas);
                cajasDeTexto.Add(txtPosicion);
                cajasDeTexto.Add(txtPartidosJugados);
                cajasDeTexto.Add(txtCantidadPeleas);

                comboCajas.Add(cmbGenero);
                comboCajas.Add(cmbCategoria);
                comboCajas.Add(cmbValorCuota);
                comboCajas.Add(cmbTipoSocix);
                comboCajas.Add(cmbPileta);
                comboCajas.Add(cmbEstiloPreferido);
                comboCajas.Add(cmbPeso);

                cajasCheck.Add(chkNombre);
                cajasCheck.Add(chkApellido);
                cajasCheck.Add(chkEdad);
                cajasCheck.Add(chkMedallas);
                cajasCheck.Add(chkPosicion);
                cajasCheck.Add(chkPartidosJugados);
                cajasCheck.Add(chkCantidadPeleas);
                cajasCheck.Add(chkGenero);
                cajasCheck.Add(chkCategoria);
                cajasCheck.Add(chkValorCuota);
                cajasCheck.Add(chkTipoSocix);
                cajasCheck.Add(chkPileta);
                cajasCheck.Add(chkEstilo);
                cajasCheck.Add(chkPeso);

                btnAceptar.Enabled = false;
                listaSocix = new List<Socix>();

                foreach (TextBox cajita in cajasDeTexto)
                {
                    cajita.Enabled = false;
                }

                foreach (ComboBox cajita in comboCajas)
                {
                    cajita.Enabled = false;
                }

                cmbGenero.DataSource = Enum.GetValues(typeof(EGenero));
                cmbValorCuota.DataSource = Enum.GetValues(typeof(ECuota));
                cmbCategoria.DataSource = Enum.GetValues(typeof(ECategoria));
                cmbTipoSocix.DataSource = Enum.GetValues(typeof(ETipoSocix));
                cmbPileta.DataSource = Enum.GetValues(typeof(EPileta));
                cmbEstiloPreferido.DataSource = Enum.GetValues(typeof(EEstilos));
                cmbPeso.DataSource = Enum.GetValues(typeof(EPeso));


                this.actualizarDG += frmListDatos.ActualizarDatagrid;
                this.actualizarDGDni += frmListDatos.ActualizarDatagridDni;
                tarea = new Task(() => frmListDatos.ShowDialog());
                tarea.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}.", "Error en la carga del formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        /// <summary>
        /// Metodo manejador que habilita o deshabilita el txtBox correspondiente a su campo segun el estado del chkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTipoSocix_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipoSocix.CheckState == CheckState.Checked)
            {
                cmbTipoSocix.Enabled = true;
            }
            else
            {
                cmbTipoSocix.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo manejador que verifica que el dni ingresado en el txtbox exista y actualiza la base de datos en consecuencia, mostrando los datos actuales del socix correspondiente al dni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDni_Click(object sender, EventArgs e)
        {
            GestorBaseDeDatos gbd;

            try
            {
                if (int.TryParse(this.txtDNI.Text, out int dni))
                {
                    gbd = new GestorBaseDeDatos($"SELECT * FROM Socixs WHERE dni = {dni}");
                    SqlCommand sqlCommand = new SqlCommand(gbd.SqlComando, gbd.SqlConexion);
                    gbd.ObtenerSocix(sqlCommand, listaSocix);

                    if (listaSocix[0] is Futbolista)
                    {
                        socix = new Futbolista();
                    }
                    else if (listaSocix[0] is Pugilista)
                    {
                        socix = new Pugilista();
                    }
                    else
                    {
                        socix = new Nadador();
                    }

                    socix = listaSocix[0];

                    if (tarea != null)
                    {
                        Task tareaDos = Task.Run(() => this.ActualizarEventDni(dni));
                        btnAceptar.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("Dni inválido o inexistente.", "Error al ingresar DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}.", "Error al ingresar DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        /// <summary>
        /// Metodo manejador que llama al evento actualizarDG
        /// </summary>
        private void ActualizarEvent()
        {
            if (this.actualizarDG != null)
            {
                this.actualizarDG.Invoke();
            }

        }

        /// <summary>
        /// Metodo manejador que llama al evento actualizarDGDNI 
        /// </summary>
        /// <param name="dni"></param>
        private void ActualizarEventDni(int dni)
        {

            if (this.actualizarDGDni != null)
            {
                this.actualizarDGDni.Invoke(dni);
            }
            
        }


    }
}
