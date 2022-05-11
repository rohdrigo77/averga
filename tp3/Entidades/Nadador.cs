using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Nadador))]
    public class Nadador : Socix
    {
        private EPileta tipoPileta;
        private EEstilos estiloPreferido;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Nadador()
        : base()
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="genero"></param>
        /// <param name="edad"></param>
        /// <param name="valorCuota"></param>
        /// <param name="tipoSocix"></param>
        /// <param name="cantMedallas"></param>
        /// <param name="pileta"></param>
        /// <param name="estiloPreferido"></param>
        /// <param name="fechaAptaFisica"></param>
        /// <param name="fechaAsociacion"></param>
        public Nadador(int dni, string nombre, string apellido, EGenero genero, int edad,ECuota valorCuota, ETipoSocix tipoSocix, int cantMedallas, EPileta pileta, EEstilos estiloPreferido, string fechaAptaFisica, string fechaAsociacion)
        : base(dni, nombre, apellido, genero, edad, valorCuota, tipoSocix, cantMedallas, fechaAptaFisica, fechaAsociacion)
        {
            this.tipoPileta = pileta;
            this.estiloPreferido = estiloPreferido;
            
        }


        /// <summary>
        /// Metodo virtual que devuelve un stringbuilder convertido a string detallando los datos del socix y nadador
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendLine($"{base.Mostrar()}");
                sb.AppendLine($"Pileta en la que nada: {this.TipoPileta}");
                sb.AppendLine($"Estilo preferido de nado: {this.EstiloPreferido}");
            }
            catch (Exception)
            {
                throw;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo tipoPileta
        /// </summary>
        public EPileta TipoPileta
        {
            set
            {
                this.tipoPileta = value;
            }
            get
            {
                return this.tipoPileta;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo estiloPreferido
        /// </summary>
        public EEstilos EstiloPreferido
        {
            set
            {
                this.estiloPreferido = value;
            }
            get
            {
                return this.estiloPreferido;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo valorCuota
        /// </summary>
        public override ECuota ValorCuota
        {
            set
            {
                if(this.Edad <= 12)
                {         
                    if (value == ECuota.NinixsNatacion)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    if (value == ECuota.AdultxsNatacion)
                    {
                        this.valorCuota = value;
                    }
                }
            }
            get
            {
                return this.valorCuota;
            }

        }
    }
}
