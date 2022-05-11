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
using System.Data.SqlClient;


namespace FrmClub
{
    public delegate string ObtenerClub();
    public partial class FrmClub : Form
    {        
        private FrmCargarSocix cargarSocix;
        private FrmModificarSocix modificarSocix;
        private FrmListDatos mostrarDatos;
        private FrmInformes informes;
        private Club miClub;
        private GestorBaseDeDatos gdb;
        private List<Socix> listaSocixs;
 
        /// <summary>
        ///  Constructor sin parametros de FrmClub
        /// </summary>
        public FrmClub()
        {
            InitializeComponent();
            miClub = new Club("Club del Peluca");
            listaSocixs = new List<Socix>();
            miClub.ListaSocixs = listaSocixs;


        }

        /// <summary>
        /// Propiedad de solo lectura del atributo miClub
        /// </summary>
        public Club MiClub
        {
            get
            {
                return this.miClub;
            }
        }

        /// <summary>
        /// Propiedad de solo lectura del atributo listaSocixs
        /// </summary>
        public List<Socix> ListaSocixs
        {
            get
            {
                return this.listaSocixs;
            }
        }

        /// <summary>
        /// Metodo manejador de cargarSocixBtn que llama al formulario FrmCargarSocix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargarSocixBtn_Click(object sender, EventArgs e)
        {
            
            this.cargarSocix = new FrmCargarSocix(this.listaSocixs);
            cargarSocix.ShowDialog();
        }

        /// <summary>
        /// Metodo manejador de listSocixsBtn que llama al formulario FrmListDatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listSocixsBtn_Click(object sender, EventArgs e)
        {
            this.mostrarDatos = new FrmListDatos("Select * from Socixs");
            mostrarDatos.ShowDialog();
        }

        /// <summary>
        /// Metodo manejador de informesBtn que llama al formulario FrmInformes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informesBtn_Click(object sender, EventArgs e)
        {
            this.informes = new FrmInformes(this.miClub);
            informes.ShowDialog();
        }

        /// <summary>
        /// Metodo manejador de modificarSocixBtn que llama al formulario FrmModificarSocix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarSocixBtn_Click(object sender, EventArgs e)
        {
            this.modificarSocix = new FrmModificarSocix();

            modificarSocix.ShowDialog();
        }

        /// <summary>
        /// Metodo que carga la propiedad Text, los atributos listaSocixs con los socixs obtenidos de la base, y gdb 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClub_Load(object sender, EventArgs e)
        {
            this.Text = miClub.RazonSocial;
            this.gdb = new GestorBaseDeDatos("Select * from Socixs");
          
            try
            {  
                
                using (gdb.SqlConexion)
                {                
                    SqlCommand sqlCommand = new SqlCommand(gdb.SqlComando, gdb.SqlConexion);
                    gdb.ObtenerSocix(sqlCommand, listaSocixs);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al intentar levantar los datos de la base", MessageBoxButtons.OK);
            }
        }


        /// <summary>
        /// Metodo manejador de btnCargarListaArchivo que llama a Leer el archivo y poblar listaSocixs con los elementos del archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarListaArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                new GestorDeArchivos().Leer($"{this.miClub.RazonSocial}.xml", out listaSocixs);
                MessageBox.Show("Lista cargada desde archivo exitosamente.", "Cargar lista desde archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al intentar levantar los datos del archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Metodo manejador de btnGuardarListaArchivo que llama a Guardar el archivo los elementos de  listaSocixs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnGuardarListaArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                new GestorDeArchivos().Guardar($"{this.miClub.RazonSocial}.xml", listaSocixs);
                MessageBox.Show($"La lista se guardó exitosamente en el archivo {this.miClub.RazonSocial}.xml", "Lista de socixs guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al intentar guardar el archivo", MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// Metodo manejador del evento FormClosing que guarda la listaSocixs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClub_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            try 
            {
                foreach (Socix socix in listaSocixs)
                {
                    gdb = new GestorBaseDeDatos("Select * from Socixs");
                    

                    if (!gdb.DniExistente(socix.DNI))
                    {
                        gdb.Guardar(socix);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}","Error capturado en FrmClub_FromClosing",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
            
        }
    }
}
