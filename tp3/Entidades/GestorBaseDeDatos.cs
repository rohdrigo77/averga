using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Generics;
using Excepciones;
using System.Threading;

namespace Entidades
{

    public class GestorBaseDeDatos
    {

        private SqlConnection sqlConexion;
        private string sqlComando;

        /// <summary>
        /// Constructor publico de GestorBaseDeDatos
        /// </summary>
        public GestorBaseDeDatos()
        {
            this.sqlConexion =  new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP3CLUB;Trusted_Connection=True");
        }

        /// <summary>
        ///  Constructor publico de GestorBaseDeDatos parametrizado que recibe un string para asignar el atributo "comando".
        /// </summary>
        /// <param name="comando"></param>
        public GestorBaseDeDatos(string comando)
        :this() 
        {
            this.sqlComando = comando;
        }

        /// <summary>
        /// Puebla un datatable y lo retorna segun el comando y conexion del GestorBaseDeDatos
        /// </summary>
        /// <returns></returns>
        public DataTable LeerDesdeBD()
        {
            DataTable dataTable = new DataTable();

            using (this.sqlConexion)
            {
                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(this.sqlComando, sqlConexion));
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return dataTable;

        }

        /// <summary>
        /// Propiedad publica de lectura y escritura para el atributo sqlConexion
        /// </summary>
        public SqlConnection SqlConexion
        {
            set
            {
                this.sqlConexion = value;
            }
            get
            {
                return this.sqlConexion;
            }
        }

        /// <summary>
        /// Propiedad publica de escritura y lectura para el atributo sqlComando
        /// </summary>
        public string SqlComando
        {
            get
            {
                return this.sqlComando;
            }
            set
            {
                this.sqlComando = value;
            }
        }

        /// <summary>
        /// Metodo para guardar socio recibido en base de datos
        /// </summary>
        /// <param name="socio"></param>
        public void Guardar(Socix socio)
        {
            using (this.sqlConexion)
            {
                try
                {
                    string consulta = "INSERT INTO Socixs (dni,nombre,apellido,genero,edad,valorCuota,tipoSocix,medallas,categoria,posicion,partidosJugados,pileta,estiloPreferido,peso,cantidadPeleas,aptaFisica,asociacion) VALUES (@dni,@nombre,@apellido,@genero,@edad,@valorCuota,@tipoSocix,@medallas,@categoria,@posicion,@partidosJugados,@pileta,@estiloPreferido,@peso,@cantidadPeleas,@aptaFisica,@asociacion)";

                    SqlCommand sqlCommand = new SqlCommand(consulta, this.sqlConexion);

                    sqlCommand.Parameters.AddWithValue("dni", socio.DNI);
                    sqlCommand.Parameters.AddWithValue("nombre", socio.Nombre);
                    sqlCommand.Parameters.AddWithValue("apellido", socio.Apellido);
                    sqlCommand.Parameters.AddWithValue("genero", socio.Genero.ToString());
                    sqlCommand.Parameters.AddWithValue("edad", socio.Edad);
                    sqlCommand.Parameters.AddWithValue("valorCuota", socio.ValorCuota.ToString());
                    sqlCommand.Parameters.AddWithValue("tipoSocix", socio.TipoSocix.ToString());
                    sqlCommand.Parameters.AddWithValue("medallas", socio.CantidadMedallas);
                    sqlCommand.Parameters.AddWithValue("aptaFisica", socio.FechaAptaFisica);
                    sqlCommand.Parameters.AddWithValue("asociacion", socio.FechaDeAsociacion);


                    if (socio is Futbolista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", ((Futbolista)socio).Categoria.ToString());
                        sqlCommand.Parameters.AddWithValue("posicion", ((Futbolista)socio).Posicion);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", ((Futbolista)socio).PartidosJugados);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);
                    }
                    else if (socio is Pugilista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", ((Pugilista)socio).CategoriaPeso.ToString());
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", ((Pugilista)socio).CantidadPeleas);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", ((Nadador)socio).TipoPileta.ToString());
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", ((Nadador)socio).EstiloPreferido.ToString());
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);
                    }

                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.SqlConexion.ConnectionString = @"Server = localhost\SQLEXPRESS; Database = TP3CLUB; Trusted_Connection = True";
                        this.sqlConexion.Open();
                    }

                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception($"Excepcion Capturada en GuardarSocix: {ex.Message}", ex);
                }

            }

        }

        /// <summary>
        /// Metodo para validar si el dni recibido existe en la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public bool DniExistente(int dni)
        {

            bool respuesta = false;

            using (this.sqlConexion)
            {
                try
                {

                    string consulta = "SELECT dni FROM Socixs WHERE dni = @dni";
                    SqlCommand sqlCommand = new SqlCommand(consulta, this.sqlConexion);
                    sqlCommand.Parameters.AddWithValue("dni", dni);

                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }


                    if (sqlCommand.ExecuteScalar() != null)
                    {
                        respuesta = true;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo para ejecutar el comando escalar en sqlComando con la conexion en sqlConexion
        /// </summary>
        public void EjecutarScalar()
        {
            using (this.sqlConexion)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, this.sqlConexion);
                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }


                    sqlCommand.ExecuteScalar();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Metodo para ejecutar el comando reader en sqlComando con la conexion en sqlConexion
        /// </summary>
        public void EjecutarReader()
        {
            using (this.sqlConexion)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, this.sqlConexion);
                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }


                    sqlCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Metodo para ejecutar el comando nonquery en sqlComando con la conexion en sqlConexion
        /// </summary>
        public void EjecutarNonQuery()
        {
            using (this.sqlConexion)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, this.sqlConexion);
                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }


                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        } 
        
        /// <summary>
        /// Metodo publico para obtener una lista de socios segun el comando recibido y asignarla a la lista recibida
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="list"></param>

        public void ObtenerSocix(SqlCommand sqlCommand, List<Socix> list)
        {
            
            Socix socix = null;

            using (this.sqlConexion)
            {
                try
                {
                    
                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }

                    SqlDataReader data = sqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        if (data.GetString(6).IndexOf("Natacion", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            socix = new Nadador();
                            ((Nadador)socix).TipoPileta = Enum.Parse<EPileta>(data.GetString(12));
                            ((Nadador)socix).EstiloPreferido = Enum.Parse<EEstilos>(data.GetString(13));
                        }
                        else if (data.GetString(6).IndexOf("Futbol", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            socix = new Futbolista();
                            ((Futbolista)socix).Categoria = Enum.Parse<ECategoria>(data.GetString(9));
                            ((Futbolista)socix).Posicion = data.GetInt32(10);
                            ((Futbolista)socix).PartidosJugados = data.GetInt32(11);
                        }
                        else
                        {
                            socix = new Pugilista();
                            ((Pugilista)socix).CategoriaPeso = Enum.Parse<EPeso>(data.GetString(14));
                            ((Pugilista)socix).CantidadPeleas = data.GetInt32(15);
                        }

                        socix.SocixNuevx = false;
                        socix.DNI = data.GetInt32(1);
                        socix.Nombre = data.GetString(2);
                        socix.Apellido = data.GetString(3);
                        socix.Genero = Enum.Parse<EGenero>(data.GetString(4));
                        socix.Edad = data.GetInt32(5);
                        socix.ValorCuota = Enum.Parse<ECuota>(data.GetString(6));
                        socix.TipoSocix = Enum.Parse<ETipoSocix>(data.GetString(7));
                        socix.CantidadMedallas = data.GetInt32(8);
                        socix.FechaAptaFisica = data.GetString(16);
                        socix.FechaDeAsociacion = data.GetString(17);

                        list.Add(socix);

                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Excepcion Capturada en ObtenerSocix: {ex.Message}");
                }

            }           

        }

        /// <summary>
        /// Metodo para actualizar el socix recibido existente en la base con sus atributos
        /// </summary>
        /// <param name="socio"></param>
        public void ActualizarSocix(Socix socio)
        {
            using (this.sqlConexion)
            {
                try
                {
                    string consulta = "UPDATE Socixs SET nombre = @nombre, apellido = @apellido, genero = @genero, edad = @edad, valorCuota = @valorCuota, tipoSocix = @tipoSocix, medallas = @medallas, categoria = @categoria, posicion = @posicion, partidosJugados = @partidosJugados, pileta = @pileta , estiloPreferido = @estiloPreferido, peso = @peso, cantidadPeleas = @cantidadPeleas, aptaFisica = @aptaFisica, asociacion = @asociacion WHERE dni = @dni";

                    SqlCommand sqlCommand = new SqlCommand(consulta, this.sqlConexion);
                    sqlCommand.Parameters.AddWithValue("dni", socio.DNI);
                    sqlCommand.Parameters.AddWithValue("nombre", socio.Nombre);
                    sqlCommand.Parameters.AddWithValue("apellido", socio.Apellido);                   
                    sqlCommand.Parameters.AddWithValue("genero", socio.Genero.ToString());
                    sqlCommand.Parameters.AddWithValue("edad", socio.Edad);
                    sqlCommand.Parameters.AddWithValue("valorCuota", socio.ValorCuota.ToString());
                    sqlCommand.Parameters.AddWithValue("tipoSocix", socio.TipoSocix.ToString());
                    sqlCommand.Parameters.AddWithValue("medallas", socio.CantidadMedallas);
                    sqlCommand.Parameters.AddWithValue("aptaFisica", socio.FechaAptaFisica);
                    sqlCommand.Parameters.AddWithValue("asociacion", socio.FechaDeAsociacion);


                    if (socio is Futbolista)
                    {

                        sqlCommand.Parameters.AddWithValue("categoria", ((Futbolista)socio).Categoria.ToString());
                        sqlCommand.Parameters.AddWithValue("posicion", ((Futbolista)socio).Posicion);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", ((Futbolista)socio).PartidosJugados);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);


                    }
                    else if (socio is Pugilista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", ((Pugilista)socio).CategoriaPeso.ToString());
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", ((Pugilista)socio).CantidadPeleas);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", ((Nadador)socio).TipoPileta.ToString());
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", ((Nadador)socio).EstiloPreferido.ToString());
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);
                    }



                    if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                    {
                        this.sqlConexion.Open();
                    }

                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception($"Excepcion Capturada en ActualizarSocix: {ex.Message}", ex);
                }

            }
        }

        /// <summary>
        /// Metodo para borrar dni de un socix donde el dni sea el recibido
        /// </summary>
        /// <param name="dni"></param>
        public void BorrarDNI(int dni)
        {

            using (this.sqlConexion)
            {
                this.sqlComando = "Delete dni FROM Socixs WHERE dni = @dni";

                SqlCommand sqlCommandDelete = new SqlCommand(sqlComando, this.sqlConexion);
                sqlCommandDelete.Parameters.AddWithValue("dni", dni);


                if (this.sqlConexion.State != System.Data.ConnectionState.Open)
                {
                    this.sqlConexion.Open();
                }

                sqlCommandDelete.ExecuteNonQuery();
            }
        }
    }
}
