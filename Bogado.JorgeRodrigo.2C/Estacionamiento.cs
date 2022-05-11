using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Entidades
{
	public class Estacionamiento
	{

		private int capacidadEstacionamiento;
		private static Estacionamiento estacionamiento;
		private List<Vehiculo> listadoVehiculos;
		private string nombre;
		/// <summary>
		/// Constructor parametrizado de instancia Estacionamiento
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="capacidad"></param>
		private Estacionamiento(string nombre, int capacidad)
		{
			this.listadoVehiculos = new List<Vehiculo>();
			this.nombre = nombre;
			this.capacidadEstacionamiento = capacidad;
		}
		/// <summary>
		/// Propiedad ListadoVehiculos de solo lectura
		/// </summary>
		public List<Vehiculo> ListadoVehiculos
		{
			get
			{
				return this.listadoVehiculos;
			}
		}
		/// <summary>
		/// Propiedad ListadoVehiculos de nombre
		/// </summary>
		public string Nombre
		{
			get
			{
				return this.nombre;
			}
		}
		/// <summary>
		/// Metodo GetEstacionamiento.
		/// si el atributo estacionamiento es nulo, se instancia un Estacionamiento mediante su constructor utilizando parametros recibidos.
		/// Caso contrario, se modifica la capacidad del estacionamiento por la recibida.
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="capacidad"></param>
		/// <returns>Estacionamiento.estacionamiento</returns>
		public static Estacionamiento GetEstacionamiento(string nombre, int capacidad)
		{
			if (Estacionamiento.estacionamiento is null)
			{
				Estacionamiento.estacionamiento = new Estacionamiento(nombre, capacidad);
			}
			else
			{
				Estacionamiento.estacionamiento.capacidadEstacionamiento = capacidad;
			}

			return Estacionamiento.estacionamiento;

		}
		/// <summary>
		/// Metodo virtual "InformarSalida".
		/// Retorna la cadena armada con $"Retiro Estacionamiento {this.Nombre}", vehiculo.ToString(), $"Retiro Estacionamiento {vehiculo.HoraEgreso}", 
		/// $"El cargo por estacionamiento es:  {vehiculo.CostoEstadia.ToString("00.0")}"
		/// </summary>
		/// <returns>sb.ToString()</returns>
		public string InformarSalida(Vehiculo vehiculo)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Retiro Estacionamiento {this.Nombre}");
			sb.AppendLine(vehiculo.ToString());
			sb.AppendLine($"Retiro Estacionamiento {vehiculo.HoraEgreso}");
			sb.AppendLine($"El cargo por estacionamiento es:  {vehiculo.CostoEstadia.ToString("00.0")}");
			return sb.ToString();
		}
		/// <summary>
		/// Sobrecarga de operador -.
		/// Si el vehiculo recibido esta en el estacionamiento recibido, se setea la HoraEgreso del vehiculo recibido con la hora actual y se remueve del estacionamiento 
		/// </summary>
		/// <param name="estacionamiento"></param>
		/// <param name="vehiculo"></param>
		/// <returns>true si la condicion se cumple, false si no</returns>
		public static bool operator -(Estacionamiento estacionamiento, Vehiculo vehiculo)
		{
			bool estado = false;

			if (estacionamiento == vehiculo)
			{
				vehiculo.HoraEgreso = DateTime.Now;
				estacionamiento.ListadoVehiculos.Remove(vehiculo);
				estado = true;
			}

			return estado;
		}
		/// <summary>
		/// Sobrecarga de operador +
		/// Si el vehiculo recibido no esta en el estacionamiento recibido, y este tiene capacidad, se agrega el vehiculo recibido al estacionamiento 
		/// </summary>
		/// <param name="estacionamiento"></param>
		/// <param name="vehiculo"></param>
		/// <returns>true si la condicion se cumple, false si no</returns>
		public static bool operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)
		{
			bool estado = false;

			if (estacionamiento != vehiculo && estacionamiento.ListadoVehiculos.Count < estacionamiento.capacidadEstacionamiento)
			{
				estacionamiento.ListadoVehiculos.Add(vehiculo);
				estado = true;
			}

			return estado;
		}
		/// <summary>
		/// Sobrecarga de operador == 
		/// Retorna si el vehiculo está en el estacionamiento recibido
		/// </summary>
		/// <param name="estacionamiento"></param>
		/// <param name="vehiculo"></param>
		/// <returns>true si se cumple la condicion, false si no</returns>
		public static bool operator == (Estacionamiento estacionamiento, Vehiculo vehiculo)
		{
			return estacionamiento.ListadoVehiculos.Contains(vehiculo);

		}
		/// <summary>
		/// Sobrecarga de operador != 
		/// Retorna si el vehiculo no está en el estacionamiento recibido
		/// </summary>
		/// <param name="estacionamiento"></param>
		/// <param name="vehiculo"></param>
		/// <returns>true si se cumple la condicion, false si no</returns>
		public static bool operator !=(Estacionamiento estacionamiento, Vehiculo vehiculo)
		{
			return !(estacionamiento.ListadoVehiculos.Contains(vehiculo));
		}

	}
}


