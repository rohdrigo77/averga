using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class TrooperExplorador : Trooper
    {
        public string vehiculo;

        public override string Tipo
        {
            get
            {
                return "Soldado de Exploración";
            }
        }

        public string Vehiculo
        {
            get
            {
                return this.vehiculo;
            }

            set
            {
                if (value != "")
                {
                    this.Vehiculo = value;
                }
                else
                {
                    this.Vehiculo = "Indefinido";
                }

            }
        }

        public override string InfoTrooper()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" – Vehículo: {this.Vehiculo}");

            return sb.ToString();

        }

        public TrooperExplorador(string vehiculo)
        :base(Blaster.EC17)
        {
            this.vehiculo = vehiculo;
        }



    }
}
