using System;
using System.Text;

namespace Entidades
{
    public abstract class Trooper
    {
        protected Blaster armamento;
        protected bool esClon;
        public enum Blaster
        {
            E11,
            EC17,
            DLT19,
        }

        public enum ETrooper
        {
            Explorador,
            Arena,
            Asalto,
        }

        public Trooper(Blaster armamento)
        :this(armamento,false)
        {        
        }

        public Trooper(Blaster armamento, bool esClon)
        {
            this.armamento = armamento;
            this.esClon = esClon;
        }

        public Blaster Armamento
        {
            get
            {
                return this.armamento;
            }
        }

        public bool EsClon
        {
            get 
            {
                return this.esClon;
            }
            set
            {
                this.esClon = value;
            }
        }

        public abstract string Tipo
        { 
            get;
        }

        public virtual string InfoTrooper()
        {

            return String.Format($"{this.Tipo} armado con { this.armamento}, {this.EsClon} es clone.");
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType());
        }


    }
}
