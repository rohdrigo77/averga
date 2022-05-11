using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;


namespace Entidades
{

    [XmlInclude(typeof(Socix))]
    [XmlInclude(typeof(Nadador))]
    [XmlInclude(typeof(Futbolista))]
    [XmlInclude(typeof(Pugilista))]
    public abstract class Socix
    {
        private int dni;
        private string nombre;
        private string apellido;
        private EGenero genero;
        private int edad;
        protected ECuota valorCuota;
        private ETipoSocix tipoSocix;
        private int cantidadMedallas;
        private string fechaDeAsociacion;
        private string fechaAptaFisica;
        private bool socixNuevx;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Socix()
        {
            
        }

        /// <summary>
        ///  Constructor parametrizado
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="genero"></param>
        /// <param name="edad"></param>
        /// <param name="valorCuota"></param>
        /// <param name="tipoSocix"></param>
        /// <param name="cantidadMedallas"></param>
        /// <param name="fechaAptaFisica"></param>
        /// <param name="fechaAsociacion"></param>
        public Socix(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, ETipoSocix tipoSocix, int cantidadMedallas, string fechaAptaFisica, string fechaAsociacion)
        {
            
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.genero = genero;
            this.valorCuota = valorCuota;
            this.tipoSocix = tipoSocix;
            this.cantidadMedallas = cantidadMedallas;
            this.fechaAptaFisica = fechaAptaFisica;
            this.fechaDeAsociacion = fechaAsociacion;
            this.socixNuevx = false;
        }

        /// <summary>
        ///  Propiedad del atributo socixNuevx
        /// </summary>
        public bool SocixNuevx
        {
            set
            {
                this.socixNuevx = value;
            }
            get
            {
                return this.socixNuevx;
            }

        }
        /// <summary>
        /// Propiedad del atributo dni, con validación para evitar duplicados y numeros mayores a 99999999  
        /// </summary>
        public int DNI
        {
            set
            {
                if (value <= 99999999)
                {
                    if(!new GestorBaseDeDatos().DniExistente(value) || this.socixNuevx == false)
                    {
                        this.dni = value;
                    }
                    else
                    {           
                         throw new DniInvalidoException("El DNI ingresado ya existe o es invalido. Ingrese otro diferente.");                      
                    }
                                  
                }
            }
            get
            {
                return this.dni;
            }
           
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo nombre con validación para valores enteros y strings mayores a 50
        /// </summary>
        public string Nombre
        {
            set
            {
                if(value.Length > 50 ||  int.TryParse(value,out _) )
                {
                    throw new NombreApellidoInvalidoException("El nombre ingresado es inválido. Ingrese otro diferente.");
                }
                else
                {
                    this.nombre = value;
                }
            }
            get
            {
                return this.nombre;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo apellido con validación para valores enteros y strings mayores a 50
        /// </summary>
        public string Apellido
        {
            set
            {
                if (int.TryParse(value, out _) || value.Length > 50)
                {
                    throw new NombreApellidoInvalidoException("El Apellido ingresado es inválido. Ingrese otro diferente.");
                }
                else
                {
                    this.apellido = value;
                }
            }
            get
            {
                return this.apellido;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo genero
        /// </summary>
        public EGenero Genero
        {
            set
            {
                this.genero = value;
            }
            get
            {
                return this.genero;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo edad, con validaciones para numeros enteros entre 3 y 
        /// </summary>
        public int Edad
        {
            set
            {
                
                if (value >= 3 && value < 100)
                {
                    this.edad = value;
                }
                else
                {
                    throw new EdadNoAdmitidaException("Edad no admitida. Ingrese una edad de 3 a 100.");
                }

            }
            get 
            {
                return this.edad;
            }

        }
        /// <summary>
        /// Propiedad virtual de lectura y escritura para el atributo valorCuota
        /// </summary>
        public virtual ECuota ValorCuota {set; get;}

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo cantidadMedallas
        /// </summary>
        public int CantidadMedallas
        {
            set
            {
                if (value >= 0)
                {
                    this.cantidadMedallas = value;
                }
                else
                {
                    if (value == 0)
                    {
                        this.cantidadMedallas = value;
                    }
                    else
                    {
                        throw new MenorQueCeroException("El valor ingresado no es válido o socix no compite. Ingrese un número mayor o igual a 0, o haga competir al socix.");
                    }
                        
                }
            }
            get
            {
                return this.cantidadMedallas;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo tipoSocix
        /// </summary>
        public ETipoSocix TipoSocix
        {
            set
            {
                this.tipoSocix = value;
            }
            get
            {
                return this.tipoSocix;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo fechaDeAsociacion
        /// </summary>

        public string FechaDeAsociacion
        {
            set
            {
                this.fechaDeAsociacion = value;
            }
            get
            {
                return this.fechaDeAsociacion;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo fechaAptaFisica
        /// </summary>
        public string FechaAptaFisica
        {
            set
            {
                this.fechaAptaFisica = value;
            }
            get
            {
                return this.fechaAptaFisica;
            }
        }
        /// <summary>
        /// Metodo virtual que devuelve un stringbuilder convertido a string detallando los datos del socix
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--- Datos socix ---");
            sb.AppendLine($"DNI: {this.DNI}");
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Genero: {this.Genero}");
            sb.AppendLine($"Edad: {this.Edad}");
            sb.AppendLine($"Valor cuota: {this.ValorCuota}");
            sb.AppendLine($"Cantidad de medallas: {this.CantidadMedallas}");
            sb.AppendLine($"Tipo de socix: {this.TipoSocix}");
            sb.AppendLine($"Fecha de última apta física presentada: {this.FechaAptaFisica}");
            sb.AppendLine($"Socix desde: {this.FechaDeAsociacion}");


            return sb.ToString();
        }
        /// <summary>
        /// Metodo publico que llama a Mostrar()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();         
        }

    }
}
