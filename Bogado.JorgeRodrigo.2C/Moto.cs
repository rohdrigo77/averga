using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public sealed class Moto : Vehiculo
    {
        private ETipo tipo;
        private static double valorHora;
        /// <summary>
        /// Enumeracion Etipo
        /// </summary>
        public enum ETipo
        {
            Ciclomotor,
            Scooter,
            Sport,
        }
        /// <summary>
        /// Constructor de clase Moto
        /// </summary>
        static Moto()
        {
            Moto.ValorHora = 100;
        }
        /// <summary>
        /// Constructor parametrizado de instancia Moto
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="horaIngreso"></param>
        /// <param name="tipo"></param>
        public Moto(string patente, DateTime horaIngreso, ETipo tipo)
       : base(patente, horaIngreso)
        {
            this.tipo = tipo;
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
                    Moto.valorHora = value;
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
                return this.tipo.ToString();
            }
        }
        /// <summary>
        /// Metodo heredado reescrito CargoDeEstacionamiento
        /// Multiplica las horas que el Vehiculo estuvo estacionado por Moto.valorHora
        /// </summary>
        /// <returns>el resultado de la multiplicacion</returns>
        protected override double CargoDeEstacionamiento()
        {
            return base.CargoDeEstacionamiento() * Moto.valorHora;
        }
        /// <summary>
        /// Metodo reescrito "MostrarDatos".
        /// Retorna la cadena armada con "****MOTO*****", base.MostrarDatos(), $"Tipo: {this.Descripcion}", 
        /// </summary>
        /// <returns>sb.ToString()</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****MOTO*****");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Tipo: {this.Descripcion}");

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
