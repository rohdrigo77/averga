using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Automovil : Vehiculo
    {
        private string marca;
        private static double valorHora;
        /// <summary>
        /// Constructor de clase Automovil
        /// </summary>
        static Automovil()
        {
            Automovil.ValorHora = 120;
        }
        /// <summary>
        /// Constructor parametrizado de instancia Automovil
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="horaIngreso"></param>
        /// <param name="marca"></param>
        public Automovil(string patente, DateTime horaIngreso, string marca)
        : base(patente, horaIngreso)
        {
            this.marca = marca;
        }
        /// <summary>
        /// Propiedad de solo escritura ValorHora
        /// </summary>
        public static double ValorHora
        {
            set
            {
                if (value > 0)
                {
                    Automovil.valorHora = value;
                }
            }
        }
        /// <summary>
        /// Propiedad heredada reescrita de solo lectura CostoEstadia
        /// </summary>
        public override double CostoEstadia
        {
            get
            {
                return this.CargoDeEstacionamiento();
            }
        }
        /// <summary>
        /// Propiedad heredada reescrita de solo lectura Descripcion
        /// </summary>
        public override string Descripcion
        {
            get
            {
                return this.marca;
            }
        }
        /// <summary>
        /// Metodo heredado reescrito CargoDeEstacionamiento
        /// Multiplica las horas que el Vehiculo estuvo estacionado por Automovil.valorHora
        /// </summary>
        /// <returns>el resultado de la multiplicacion</returns>
        protected override double CargoDeEstacionamiento()
        {
            return base.CargoDeEstacionamiento() * Automovil.valorHora;
        }
        /// <summary>
        /// Metodo reescrito "MostrarDatos".
        /// Retorna la cadena armada con "****AUTOMOVIL*****", base.MostrarDatos(), $"Marca: {this.Descripcion}", 
        /// </summary>
        /// <returns>sb.ToString()</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****AUTOMOVIL*****");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Marca: {this.Descripcion}");

            return sb.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}
