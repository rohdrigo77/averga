using System;
using System.Text;


namespace Entidades
{
    public class TrooperArena : Trooper
    {
        public override string Tipo
        {
            get
            {
                return "Soldados de asalto de terrenos desérticos";
            }
        }

        public TrooperArena(Blaster armamento)
        : base(armamento)
        {

        }

    }
}