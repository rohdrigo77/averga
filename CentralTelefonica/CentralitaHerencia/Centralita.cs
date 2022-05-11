using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string NombreEmpresa)
        : this()
        {
            this.razonSocial = NombreEmpresa;
        }

        public float GananciasPorLocal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Local);
            }
        }
        public float GananciasPorProvincial
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Provincial);
            }
        }

        public float GananciasPorTotal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }

        private void AgregarLlamada (Llamada nuevaLlamada)
        {
            this.listaDeLlamadas.Add(nuevaLlamada);
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"La razon social es: {this.razonSocial}");
            
            sb.AppendLine($"La ganancia local es : {this.GananciasPorLocal}");
            sb.AppendLine($"La ganancia provincial es : {this.GananciasPorProvincial}");
            sb.AppendLine($"La ganancia total es : {this.GananciasPorTotal}");

            sb.AppendLine("----------\n\n*** Listado de llamadas ***\n----------");
            
            foreach (Llamada llamada in this.Llamadas)
            {
                sb.AppendLine(llamada.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float gananciaLocal = 0;
            float gananciaProvincial = 0;

            foreach (Llamada llamada in this.Llamadas)
            {
                if (llamada is Local)
                {
                    gananciaLocal += ((Local)llamada).CostoLlamada;
                }
                else if (llamada is Provincial)
                {
                    gananciaProvincial += ((Provincial)llamada).CostoLlamada;
                }     
            }

            switch (tipo)
            {
                case Llamada.TipoLlamada.Local:
                {
                    return gananciaLocal;
                }
                case Llamada.TipoLlamada.Provincial:
                {
                    return gananciaProvincial;
                }
                default:
                {
                    return gananciaLocal + gananciaProvincial;
                }

            }

        }

        public static bool operator == (Centralita c, Llamada llamada)
        {
            bool retorno = false;

            foreach (Llamada l in c.listaDeLlamadas)
            {
                if (l == llamada)
                {
                    retorno = true;
                    break;
                }

            }

            return retorno;
        }
        public static bool operator !=(Centralita c, Llamada llamada)

        {
            return !(c == llamada);
        }

        public static Centralita operator + (Centralita c, Llamada llamada)
        {
            if (c != llamada)
            {
                c.listaDeLlamadas.Add(llamada);
            }

            return c;
        }
    }
}
