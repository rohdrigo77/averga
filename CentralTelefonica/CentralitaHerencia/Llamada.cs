using System;
using System.Text;

namespace Entidades
{
    public abstract class Llamada
    {
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public float Duracion
        {
            get
            {
                return this.duracion;
            }
        }

        public string NroDestino
        {
            get
            {
                return this.nroDestino;
            }
        }

        public string NroOrigen
        {
            get
            {
                return this.nroOrigen;
            }
        }

        public virtual float CostoLlamada { get; }

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"La duracion de la llamadas es : {this.Duracion}");
            sb.AppendLine($"El numero de origen de la llamada es : {this.NroOrigen}");
            sb.AppendLine($"El numoer de destino de la llamadas es : {this.NroDestino}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            int orden = 0;

            if (llamada1.Duracion < llamada2.Duracion)
            {
                orden = -1;
            }
            else if (llamada1.Duracion > llamada2.Duracion)
            {
                orden = 1;
            }

            return orden;
        }

        public enum TipoLlamada
        {
            Local,
            Provincial,
            Todas,
        }

        public static bool operator == (Llamada l1, Llamada l2)
        {
            return l1.Equals(l2) && (l1.NroDestino == l2.NroDestino) && (l1.NroOrigen == l1.NroOrigen);
        }

        public static bool operator !=(Llamada l1, Llamada l2)
        {
            return !(l1 == l2);
        }

    }
}
