using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local : Llamada
    {
        protected float costo;

        public override float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        public Local (Llamada llamada, float costo)  
        : this(llamada.NroOrigen, llamada.Duracion,llamada.NroDestino,costo)    
        {
            
        }

        public Local (string origen, float duracion, string destino, float costo)
        : base(duracion, origen, destino)
        {
           
            this.costo = costo;
        }

        private  float CalcularCosto()
        {
            return this.costo * base.Duracion;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.ToString();
            sb.AppendLine($"El costo de la llamadas es : {this.CostoLlamada}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Local;
        }

        public override string ToString()
        {
            return Mostrar();
        }



    }
}
