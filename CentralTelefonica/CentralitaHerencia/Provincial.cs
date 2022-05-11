using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincial : Llamada
    {
        protected Franja franjaHoraria;

        public override float CostoLlamada
        {
            get 
            { 
                return this.CalcularCosto();
            }
        }

        public Provincial (Franja miFranja, Llamada llamada)
        : this(llamada.NroOrigen, miFranja, llamada.Duracion,llamada.NroDestino)
        {
            
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino )
        : base(duracion, origen, destino)
        {
            this.franjaHoraria = miFranja;
        }

        private float CalcularCosto()
        {
            float costo = 0;

            switch (this.franjaHoraria)
            {
                case Franja.Franja_1:
                    costo = 0.99F;
                    break;
                case Franja.Franja_2:
                    costo = 1.25F;
                    break;
                default:
                    costo = 0.66F;
                    break;
            }

            return costo * base.Duracion;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.ToString();
            sb.AppendLine($"La franja horaria de la llamadas es : {this.franjaHoraria}");
            sb.AppendLine($"El costo de la llamadas es : {this.CostoLlamada}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3,
        }

    }
}
