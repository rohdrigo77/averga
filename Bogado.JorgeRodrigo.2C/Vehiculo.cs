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
    public abstract class Vehiculo
    {
        private DateTime horaEgreso;
        private DateTime horaIngreso;
        private string patente;
        public enum EVehiculos
        {
            Automovil,
            Moto,
        }
        /// <summary>
        /// Constructor de instancia "Vehiculo"
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="horaIngreso"></param>
        public Vehiculo(String patente, DateTime horaIngreso)
        {
            this.horaIngreso = horaIngreso;
            this.Patente = patente;
        }
        /// <summary>
        /// Propiedad HoraEgreso de lectura y escritura
        /// </summary>
        public DateTime HoraEgreso
        {
            get
            {
                return this.horaEgreso;
            }
            set
            {
                if (this.HoraEgreso >= this.HoraIngreso)
                {
                    this.HoraEgreso = value;
                }
            }
        }
        /// <summary>
        /// Propiedad HoraIngreso de lectura
        /// </summary>
        public DateTime HoraIngreso
        {
            get
            {
                return this.horaIngreso;
            }
        }
        /// <summary>
        /// Propiedad Patente de lectura y escritura
        /// </summary>
        public string Patente
        {
            get
            {
                return this.patente;
            }

            set
            {
                if (this.ValidarPatente(value))
                {
                    this.Patente = value;
                }
            }
        }
        /// <summary>
        /// Propiedad abstracta CostoEstadia de lectura
        /// </summary>
        public abstract double CostoEstadia
        {
            get;
        }
        /// <summary>
        /// Propiedad abstracta Descripcion de lectura
        /// </summary>
        public abstract string Descripcion
        {
            get;
        }
        /// <summary>
        /// Metodo virtual "CargoDeEstacionamiento".
        /// Retorna la cantidad de horas que el vehiculo estuvo estacionado.
        /// </summary>
        /// <returns>horasAcumuladas</returns>
        protected virtual double CargoDeEstacionamiento()
        {
            double horasAcumuladas = 0;
            if (HoraEgreso > HoraIngreso)
            {
                horasAcumuladas = (this.HoraEgreso - this.HoraIngreso).TotalHours;
            }

            return horasAcumuladas;
        }
        /// <summary>
        /// Metodo virtual "MostrarDatos".
        /// Retorna la cadena armada con Patente y HoraIngreso
        /// </summary>
        /// <returns>sb.ToString()</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Patente: {this.Patente}");
            sb.AppendLine($"Ingreso: {this.HoraIngreso}");

            return sb.ToString();


        }
        /// <summary>
        /// Metodo "ValidarPatente".
        /// Retorna un valor booleano correspondiente a la cantidad de caracteres de patente
        /// </summary>
        /// <param name="patente"></param>
        /// <returns>estado(true si la patente tiene entre 6 y 7 caracteres inclusive, false si no)</returns>
        private bool ValidarPatente(string patente)
        {
            bool estado = false;

            if (patente.Length > 5 && patente.Length < 8)
            {
                estado = true;
            }
            
            return estado;

        }
        /// <summary>
        /// Sobrecarga de operador ==
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>true si la patente de ambos vehiculos es la misma, false si no</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.Patente == v2.Patente);
        }
        /// <summary>
        /// Sobrecarga de operador !=
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>false si la patente de ambos vehiculos es la misma, true si no</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

    }
}
