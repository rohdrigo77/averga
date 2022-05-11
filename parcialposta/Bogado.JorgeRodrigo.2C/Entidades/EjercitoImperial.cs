using System;
using System.Text;
using System.Collections.Generic;

namespace Entidades
{
    public class EjercitoImperial
    {
        private int capacidad;
        private List<Trooper> troopers;

        public List<Trooper> Troopers
        {
            get
            {
                return this.troopers;
            }
        }

        private EjercitoImperial()
        {
            this.troopers = new List<Trooper>();
        }

        public EjercitoImperial(int capacidad)
        : this()
        {
            this.capacidad = capacidad;
        }

        public static EjercitoImperial operator - (EjercitoImperial ejercito, Trooper soldado)
        {
         
            int i;

            for (i = 0; i<ejercito.Troopers.Count; i++)
            {
                if (ejercito.Troopers[i].Tipo == soldado.Tipo)
                {
                    ejercito.Troopers.Remove(soldado);
                    break;
                }
            }

            return ejercito;
        }

        public static EjercitoImperial operator +(EjercitoImperial ejercito, Trooper soldado)
        {
           
            if (ejercito.Troopers.Count < ejercito.capacidad)
            {
                ejercito.Troopers.Add(soldado);
            }

            return ejercito;
        }


    }


}
