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

namespace FrmClub
{
    public partial class FrmInformes : Form
    {
        Club club;

        /// <summary>
        ///  Constructor parametrizado
        /// </summary>
        /// <param name="lista"></param>
        public FrmInformes(Club miClub)
        {
            InitializeComponent();
            club = miClub;
        }

        /// <summary>
        /// Manejador del btnMedallasSegunGenero que muestra un cartel indicando el porcentaje de medallas segun genero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedallasSegunGenero_Click(object sender, EventArgs e)
        {
            

            MessageBox.Show(club.MedallasSegunGenero(), "Porcentaje de medallas según género", MessageBoxButtons.OK);
                
        }

        /// <summary>
        /// Manejador del btnSocixsCompetitivos que muestra un cartel indicando el porcentaje de Socixs competitivos por deporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSocixsCompetitivos_Click(object sender, EventArgs e)
        {                 

            MessageBox.Show(club.SocixsCompetitivos(), "Socixs competitivos por deporte", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Manejador del btnDeporteNinixs que muestra un cartel indicando el Porcentaje de ninixs según deporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDeporteNinixs_Click(object sender, EventArgs e)
        {            

            MessageBox.Show(club.DeporteConMasNinixs(), "Porcentaje de ninixs según deporte", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Manejador del btnSalir que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
