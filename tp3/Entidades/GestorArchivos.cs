using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Generics;
using Excepciones;




namespace Entidades
{
    public class GestorDeArchivos : IGuardar<List<Socix>>
    {
        /// <summary>
        /// Constructor sin parametros de GestorDeArchivos
        /// </summary>
        public GestorDeArchivos()
        {
            
        }

        /// <summary>
        /// Propiedad publica para generar ruta segun Environment.GetFolderPath
        /// </summary>
        public string GenerarRutaCompleta
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }

        /// <summary>
        /// Metodo que indica si el archivo segun ruta generada + nombreArchivo recibido existe.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns>bool (true or false)</returns>
        public bool ExisteArchivo(string nombreArchivo)
        {
            return File.Exists(this.GenerarRutaCompleta + nombreArchivo);
        }

        /// <summary>
        /// Metodo para guardar en el archivo, usando el string de archivo para completar el path, el objeto recibido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="objeto"></param>

        public void Guardar(string archivo, List<Socix> objeto) 
        {
            using (XmlTextWriter itemNuevo = new XmlTextWriter(GenerarRutaCompleta + archivo, Encoding.UTF8))
            {
                try
                {
                    Type[] socixTipos = { typeof(Socix), typeof(Nadador), typeof(Futbolista), typeof(Pugilista) };
                    XmlSerializer itemASerializar;
                    itemASerializar = new XmlSerializer(objeto.GetType(), socixTipos);
                    itemNuevo.Formatting = Formatting.Indented;
                    itemASerializar.Serialize(itemNuevo, objeto);
                    

                }
                catch (Exception)
                {
                    throw;
                }

            }
           

        }

        /// <summary>
        /// Metodo para leer archivo, formando el path con la propiedad GenerarRutaCompleta  y el parametro recibido nombreArchivo, y devolverlo en el objeto de salida
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="objeto"></param>
        public void Leer(string nombreArchivo, out List<Socix> objeto) 
        {
            

            if (nombreArchivo.Contains(".xml"))
            {
                using (XmlTextReader lector = new XmlTextReader(GenerarRutaCompleta + nombreArchivo))
                {
                    try
                    {

                        XmlSerializer ser = new XmlSerializer(typeof(List<Socix>));

                        objeto = (List<Socix>)ser.Deserialize(lector);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            else
            {
                throw new ErrorArchivosException("Formato de archivo no admitido");
            }                     

        }

    }

}