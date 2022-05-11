using System;
using System.Text;

namespace Entidades
{
    public class TrooperAsalto : Trooper
    {
        public override string Tipo
        {
            get
            {
                return "Comando para misiones de infiltración";
            }
        }

        public TrooperAsalto(Blaster armamento)  
        : base(armamento,true)
        {
           
         
        }

    }
}