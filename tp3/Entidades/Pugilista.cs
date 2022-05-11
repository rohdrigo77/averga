using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Pugilista))]
    public class Pugilista : Socix
    {
        private EPeso categoriaPeso;
        private int cantidadPeleas;

        /// <summary>
        /// 
        /// </summary>
        public Pugilista()
        : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="genero"></param>
        /// <param name="edad"></param>
        /// <param name="valorCuota"></param>
        /// <param name="cantMedallas"></param>
        /// <param name="categoria"></param>
        /// <param name="tipoSocix"></param>
        /// <param name="cantidadPeleas"></param>
        /// <param name="fechaAsociacion"></param>
        /// <param name="fechaAptaFisica"></param>
        public Pugilista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, int cantMedallas, EPeso categoria, ETipoSocix tipoSocix, int cantidadPeleas, string fechaAsociacion, string fechaAptaFisica)
        : base(dni, nombre, apellido, genero, edad, valorCuota,tipoSocix,cantMedallas,fechaAptaFisica,fechaAsociacion)
        {
            this.categoriaPeso = categoria;
            this.cantidadPeleas = cantidadPeleas;
        }

        /// <summary>
        /// 
        /// </summary>
        public EPeso CategoriaPeso
        {
            set
            {
                this.categoriaPeso = value;
            }
            get
            {
                return this.categoriaPeso;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CantidadPeleas
        {
            set
            {
                this.cantidadPeleas = value;
            }
            get
            {
                return this.cantidadPeleas;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ECuota ValorCuota
        {
            set
            {
                if (this.Edad <= 12)
                {
                    if (value == ECuota.NinixsBoxeo)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    this.valorCuota = ECuota.AdultxsBoxeo;
                }
            }
            get
            {
                return this.valorCuota;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Categoría en peso: {this.CategoriaPeso}");
            sb.AppendLine($"Cantidad de peleas: {this.CantidadPeleas}");

            return sb.ToString();
        }


    }
}
