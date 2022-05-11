using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivosException))]
        public void TestFormatoArchivoLeer()
        {
            // Act
            GestorDeArchivos gbd = new GestorDeArchivos();
            List<Socix> list = new List<Socix>();
            // Arrange
            gbd.Leer(gbd.GenerarRutaCompleta, out list);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]

        public void TestAsignarDNIExistente()
        {
            // Act
            Socix socix = new Nadador();

            socix.DNI = 37865167;


        }
    }
}
