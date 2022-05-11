using System;
using Entidades;
using System.Collections.Generic;



namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorBaseDeDatos gbd = new GestorBaseDeDatos();
            GestorDeArchivos gda = new GestorDeArchivos();
            Club miClub = new Club("Club del Peluca");
            List<Socix> lista = miClub.ListaSocixs; 
            Socix miSocix = new Nadador(66985714, "Ariel", "García", EGenero.Masculino, 20, ECuota.AdultxsNatacion, ETipoSocix.Competitivo, 5, EPileta.Olimpica, EEstilos.Crol, DateTime.Today.ToString("dd/MM/yyyy"), DateTime.Today.ToString("dd/MM/yyyy"));

            try
            {
                if (miClub + miSocix)
                {
                    Console.WriteLine("Se ha cargado al socix con exito.");
                    Console.WriteLine($"La cantidad total de medallas es: {miClub.CalcularTotalMedallas()}");
                }
                else
                {
                    Console.WriteLine("No se ha podido cargar al socix al curso.");
                }
                
                gda.Leer($"{miClub.RazonSocial}.xml", out lista);
                miClub.ListaSocixs = lista;
                Console.WriteLine(miClub.DeporteConMasNinixs());
                Console.WriteLine(miClub.SocixsCompetitivos());
                Console.WriteLine(miClub.MedallasSegunGenero());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
