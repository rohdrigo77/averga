using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita c = new Centralita("Fede Center");

            Local l1 = new Local("Bernal", 30, "Rosario", 2.65F);
            Provincial l2 = new Provincial("Morón", Provincial.Franja.Franja_1, 21, "Bernal");
            Local l3 = new Local("Lanús", 45, "San Rafael", 1.99F);
            Provincial l4 = new Provincial(Provincial.Franja.Franja_3, l2);

            c = c + l1;
            Console.WriteLine(c.ToString());
            c = c + l2;
            Console.WriteLine(c.ToString());
            c = c + l3;
            Console.WriteLine(c.ToString());
            c = c + l4;

            c.OrdenarLlamadas();
            Console.WriteLine(c.ToString());

            Console.ReadKey();

        }
    }
}
