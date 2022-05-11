using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Futbolista))]
    public class Futbolista : Socix
    {

        private int partidosJugados;
        private ECategoria categoria;
        private int posicion;
        /// <summary>
        /// 
        /// </summary>
        public Futbolista()
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
        /// <param name="cuota"></param>
        /// <param name="tipoSocix"></param>
        /// <param name="medallas"></param>
        /// <param name="partidosJugados"></param>
        /// <param name="posicion"></param>
        /// <param name="fechaAsociacion"></param>
        /// <param name="fechaAptaFisica"></param>
        public Futbolista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota cuota, ETipoSocix tipoSocix, int medallas, int partidosJugados, int posicion,string fechaAsociacion, string fechaAptaFisica)
        :base(dni,nombre,apellido,genero,edad,cuota,tipoSocix,medallas, fechaAsociacion, fechaAptaFisica)
        {           
            this.partidosJugados = partidosJugados;
            this.posicion = posicion;     
        }

        /// <summary>
        /// 
        /// </summary>
        public int PartidosJugados
        {
            set
            {
                this.partidosJugados = value;
            }
            get
            {
                return this.partidosJugados;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ECategoria Categoria
        {
            set
            {
                this.categoria = value;
            }
            get
            {
                return this.categoria;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Posicion
        {
            set
            {
                if (value == 0)
                {
                    if (this is Futbolista)
                    {
                        throw new PosicionException("Posición inválida. Elija una del 1 al 11."); 
                    }
                    else
                    {
                        this.posicion = value;
                    }
                }
                if (value >= 1 && value <=11)
                {
                    this.posicion = value;
                }
            }
            get
            {
                return this.posicion;
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
                    if (value == ECuota.NinixsFutbol)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    this.valorCuota = ECuota.AdultxsFutbol;
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
            sb.AppendLine($"Categoría: {this.Categoria}");
            sb.AppendLine($"Posición de juego: {this.Posicion}");
            sb.AppendLine($"Cantidad de partidos jugados: {this.PartidosJugados}");

            return sb.ToString();
        }





    }
}
