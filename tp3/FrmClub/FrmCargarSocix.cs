using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace FrmClub
{
    public partial class FrmCargarSocix : Form
    {
        Socix socix;
        List<Socix> listaSocix;

        /// <summary>
        /// Constructor Parametrizado
        /// </summary>
        /// <param name="lista"></param>
        public FrmCargarSocix(List<Socix> lista)
        {
            InitializeComponent();
            listaSocix = lista;  
        }

        /// <summary>
        /// Metodo manejador que verifica que los campos de los txtBox esten completados, asigna los valores validandolos, muestra un cuadro de texto con los datos asignados y solicita confirmacion para guardar el socix en la base de datos y en la lista de socixs actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarSocix_Click(object sender, EventArgs e)
        {
            try
            {
                List<TextBox> listaTextBox = new List<TextBox>();
                listaTextBox.Add(txtApellido);
                listaTextBox.Add(txtNombre);
                listaTextBox.Add(txtDNI);
                listaTextBox.Add(txtEdad);
                bool camposLlenos = true;
                if (cmbDeportes.SelectedIndex == 1)
                {
                    listaTextBox.Add(txtPosicion);
                }

                foreach (TextBox textBox in listaTextBox)
                {
                    if (textBox.Text.Length <= 0)
                    {
                        MessageBox.Show("Complete todos los datos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        camposLlenos = false;
                        break;
                    }
                    
                }
                
               if (camposLlenos)
                {
                    
                    switch (cmbDeportes.SelectedIndex)
                    {
                        case 1:
                            socix = new Futbolista();                           
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = (EGenero)cmbGenero.SelectedItem;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = (ETipoSocix)cmbTipoSocix.SelectedItem;
                            socix.CantidadMedallas = 0;
                            ((Futbolista)socix).Posicion = int.Parse(txtPosicion.Text);
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;
                            ((Futbolista)socix).PartidosJugados = 0;

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsFutbol;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsFutbol;
                            }

                            if (socix.Edad >= 16 && socix.Edad <= 18)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Juvenil;
                            }
                            else if (socix.Edad == 14 || socix.Edad == 15)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Cadete;
                            }
                            else if (socix.Edad == 12 || socix.Edad == 13)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Infantil;
                            }
                            else if (socix.Edad == 10 || socix.Edad == 11)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Alevin;
                            }
                            else if (socix.Edad == 8 || socix.Edad == 9)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Benjamin;
                            }
                            else if (socix.Edad >= 5 && socix.Edad <= 7)
                            {
                                ((Futbolista)socix).Categoria = ECategoria.PreBenjamin;
                            }
                            else if (socix.TipoSocix == ETipoSocix.Competitivo && (socix.Edad < 5 || socix.Edad > 18))
                            {
                                throw new EdadNoAdmitidaException("La edad mínima para jugar en competitivo es de 5 años y la máxima 18.");
                            }
                            else
                            {
                                ((Futbolista)socix).Categoria = ECategoria.Amateur;
                            }
                            break;

                        case 2:
                            
                            socix = new Pugilista();
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = (EGenero)cmbGenero.SelectedItem;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = (ETipoSocix)cmbTipoSocix.SelectedItem;
                            socix.CantidadMedallas = 0;
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsBoxeo;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsBoxeo;
                            }

                            ((Pugilista)socix).CategoriaPeso = (EPeso)cmbPeso.SelectedItem;
                            ((Pugilista)socix).CantidadPeleas = 0;
                            break;

                        default:
                            socix = new Nadador();                            
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = (EGenero)cmbGenero.SelectedItem;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = (ETipoSocix)cmbTipoSocix.SelectedItem;
                            socix.CantidadMedallas = 0;
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;
                           ((Nadador) socix).TipoPileta = (EPileta)cmbPileta.SelectedItem;
                            ((Nadador)socix).EstiloPreferido = (EEstilos)cmbEstiloNado.SelectedIndex;
                           

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsNatacion;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsNatacion;
                            }
                            break;

                    }

                    socix.SocixNuevx = false;

                    if (MessageBox.Show($"¿Desea guardar el socio ingresado? \n \n {socix}", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        new GestorBaseDeDatos().Guardar(socix);
                        listaSocix.Add(socix);
                        MessageBox.Show($"Socix ingresadx correctamente \n \n {socix}", "Socix Agregadx", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                         

            }
            catch (MenorQueCeroException ex)
            {
                MessageBox.Show($"{ex.Message}", "Edad no admitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EdadNoAdmitidaException ex)
            {
                MessageBox.Show($"{ex.Message}", "Edad no admitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NombreApellidoInvalidoException ex)
            {
                MessageBox.Show($"{ex.Message}","Nombre o Apellido inválido",MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            catch (PosicionException ex)
            {
                MessageBox.Show($"{ex.Message}", "Posición Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show($"{ex.Message}", "DNI Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Metodo manejador que habilita y deshabilita lbls, cmb y textbox segun el deporte seleccionado en cmbDeportes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDeportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDni.Enabled = true;
            txtDNI.Enabled = true;
           switch (cmbDeportes.SelectedIndex)
            {
                case 1:
                    
                    lblTipoPileta.Enabled = false;
                    cmbPileta.Enabled = false;
                    lblEstiloNado.Enabled = false;
                    cmbEstiloNado.Enabled = false;
                    lblCategoriaPeso.Enabled = false;
                    cmbPeso.Enabled = false;
                    lblPosicion.Enabled = true;
                    txtPosicion.Enabled = true;
                    break;
                case 2:
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    lblTipoPileta.Enabled = false;
                    cmbPileta.Enabled = false;
                    lblEstiloNado.Enabled = false;
                    cmbEstiloNado.Enabled = false;
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    lblCategoriaPeso.Enabled = true;
                    cmbPeso.Enabled = true;
                    break;
                default :
                    lblTipoPileta.Enabled = true;
                    cmbPileta.Enabled = true;
                    lblEstiloNado.Enabled = true;
                    cmbEstiloNado.Enabled = true;
                    lblCategoriaPeso.Enabled = false;
                    cmbPeso.Enabled = false;
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    break;    
            }
        }

        /// <summary>
        /// Metodo que carga los cmb segun los enumerados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCargarSocix_Load(object sender, EventArgs e)
        {
            this.cmbGenero.DataSource = Enum.GetValues(typeof(EGenero));
            this.cmbDeportes.DataSource = Enum.GetValues(typeof(EDeporteSocix));
            this.cmbPileta.DataSource = Enum.GetValues(typeof(EPileta));
            this.cmbEstiloNado.DataSource = Enum.GetValues(typeof(EEstilos));
            this.cmbPeso.DataSource = Enum.GetValues(typeof(EPeso));
            this.cmbTipoSocix.DataSource = Enum.GetValues(typeof(ETipoSocix));
            
        }

        /// <summary>
        /// Metodo manejador que consulta si se quiere agregar un socio mas antes de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FrmCargarSocix_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea Agregar otrx socix?", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

    }
}
