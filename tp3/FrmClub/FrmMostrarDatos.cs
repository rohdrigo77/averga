using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;


namespace FrmClub
{


    public partial class FrmListDatos : Form
    {
        private string consulta;
        private GestorBaseDeDatos gestor;


        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        /// <param name="consulta"></param>
        public FrmListDatos(string consulta)
        {
            InitializeComponent();
            this.consulta = consulta;
        }

        /// <summary>
        /// Propiedad de solo lectura para el atributo dataGridView1
        /// </summary>
        public DataGridView DataGridView
        {
            get
            {
                return this.dataGridView1;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo gestor
        /// </summary>
        public GestorBaseDeDatos Gestor
        {
            set
            {
                this.gestor = value;
            }
            get
            {
                return this.gestor;
            }
        }

        /// <summary>
        /// Metodo manejador que asigna el atributo gestor y dataGridView1 al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmListDatos_Load(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos(this.consulta);
            
            try
            {
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();
         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo manejador que muestra solo los nadadores en el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listNadadoresBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Natacion'");
        
            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo manejador que muestra solo los futbolistas en el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFutbolistasBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Futbol'");
        
            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo manejador que muestra solo los pugilistas en el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPugilistas_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Boxeo'");

            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo manejador que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Metodo manejador que invoca al datagrid de mostrarDatos si es necesario y lo actualiza    
        /// </summary>
        public void ActualizarDatagrid()
        { 

            if (this.DataGridView.InvokeRequired)
            {
                ActualizarDataGrid del = new ActualizarDataGrid(ActualizarDatagrid);
                this.DataGridView.Invoke(del);
            }
            else
            {
                this.Gestor = new GestorBaseDeDatos();
                this.DataGridView.DataSource = this.Gestor.LeerDesdeBD();

            }

        }

        /// <summary>
         /// Metodo manejador que invoca al datagrid de mostrarDatos si es necesario y lo actualiza segun el dni recibido    
        /// </summary>
        /// <param name="dni"></param>

        public void ActualizarDatagridDni(int dni)
        {           
            if (this.DataGridView.InvokeRequired)
            {
                ActualizarDataGridConDni del = new ActualizarDataGridConDni(ActualizarDatagridDni);
                object [] args = { dni };
                this.DataGridView.Invoke(del, args);
            }
            else
            {
                this.Gestor = new GestorBaseDeDatos($"Select * from Socixs where dni = { dni }");
                this.DataGridView.DataSource = this.Gestor.LeerDesdeBD();

            }
        }

    }
}
