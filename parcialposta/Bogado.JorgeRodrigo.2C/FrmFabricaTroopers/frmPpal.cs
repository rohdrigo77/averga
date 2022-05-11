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

namespace FrmFabricaTroopers
{
    public partial class frmPpal : Form
    {
        EjercitoImperial ejercitoImperial;
        public frmPpal()
        {
            InitializeComponent();
            this.ejercitoImperial = new EjercitoImperial(100) + new TrooperAsalto(Trooper.Blaster.EC17);
            this.RefrescarEjercito();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Trooper trooperNuevo;
            int capacidad = this.ejercitoImperial.Troopers.Count;

            if ((Trooper.ETrooper)this.cmbTipo.SelectedItem == Trooper.ETrooper.Arena)
            {
                trooperNuevo = new TrooperArena(Trooper.Blaster.EC17);
            }
            else if(((Trooper.ETrooper)this.cmbTipo.SelectedItem == Trooper.ETrooper.Asalto))
            {
                trooperNuevo = new TrooperAsalto(Trooper.Blaster.E11);
            }
            else 
            {
                trooperNuevo = new TrooperExplorador("Moto");
            }

            this.ejercitoImperial = this.ejercitoImperial + trooperNuevo;

            if (capacidad < this.ejercitoImperial.Troopers.Count)
            {
                MessageBox.Show(trooperNuevo.InfoTrooper(), "Ingreso al Ejercito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarEjercito();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Trooper trooperNuevo;
            int capacidad = this.ejercitoImperial.Troopers.Count;

            if ((Trooper.ETrooper)this.cmbTipo.SelectedItem == Trooper.ETrooper.Arena)
            {
                trooperNuevo = new TrooperArena(Trooper.Blaster.EC17);
            }
            else if (((Trooper.ETrooper)this.cmbTipo.SelectedItem == Trooper.ETrooper.Asalto))
            {
                trooperNuevo = new TrooperAsalto(Trooper.Blaster.E11);
            }
            else
            {
                trooperNuevo = new TrooperExplorador("Moto");
            }

            this.ejercitoImperial = this.ejercitoImperial - trooperNuevo;

            if (capacidad > this.ejercitoImperial.Troopers.Count)
            {
                if (MessageBox.Show($"{trooperNuevo.InfoTrooper()} ¿Está seguro que quiere quitar a este Trooper?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    RefrescarEjercito();
                }    
            }

        }
        private void frmPpal_Load(object sender, EventArgs e)
        {
            this.cmbTipo.DataSource = Enum.GetValues(typeof(Trooper.ETrooper)); 
        }

        private void RefrescarEjercito()
        {
            int i;
            this.lstEjercito.Items.Clear();

            for (i = 0; i < this.ejercitoImperial.Troopers.Count; i++)
            {
                this.lstEjercito.Items.Add(this.ejercitoImperial.Troopers[i].InfoTrooper());
            } 
                 
        }


    }
}
