using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IGuardar<T>  where T : class, new()
    {
        /// <summary>
        /// Propiedad de interfaz de solo lectura
        /// </summary>
        string GenerarRutaCompleta { get; }

        /// <summary>
        /// Metodo de interfaz que recibe un string como nombreArchivo y retorna un bool
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        bool ExisteArchivo(string nombreArchivo);

        /// <summary>
        /// Metodo de interfaz que recibe un string archivo y un objeto T
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="objeto"></param>
        void Guardar(string archivo, T objeto);

        /// <summary>
        /// Metodo de interfaz que recibe un string archivo y un objeto T
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="objeto"></param>
        void Leer(string archivo, out T objeto);
    }
}
