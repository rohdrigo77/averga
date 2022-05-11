using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;
using Excepciones;

namespace Entidades
{
    public class Club
    {
        private List<Socix> listaDeSocixs;
        protected string razonSocial;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Club()
        {
            this.listaDeSocixs = new List<Socix>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombreClub"></param>
        public Club(string nombreClub)
        : this()
        {
            this.razonSocial = nombreClub;
        }

        /// <summary>
        /// Propiedad publica de solo lectura para el atributo razonSocial
        /// </summary>
        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }

        }

        /// <summary>
        /// Propiedad publica de lectura y escritura para el atributo listaDeSocixs
        /// </summary>

        public List<Socix> ListaSocixs
        {
            get
            {
                return this.listaDeSocixs;
            }
            set
            {
                this.listaDeSocixs = value;
            }
        }

        /// <summary>
        /// Metodo para calcular el total de medallas segun la listaSocixs del club
        /// </summary>
        /// <returns></returns>
        public int CalcularTotalMedallas()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix.TipoSocix == ETipoSocix.Competitivo)
                {
                    totalMedallas += socix.CantidadMedallas;
                }
            }

            return totalMedallas;
        }

        /// <summary>
        /// Metodo para calcular el total de medallas de natacion segun la listaSocixs del club
        /// </summary>
        /// <returns></returns>
        public int CalcularTotalMedallasNatacion()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Nadador)
                {
                    totalMedallas += socix.CantidadMedallas;
                }

            }

            return totalMedallas;
        }

        /// <summary>
        /// Metodo para calcular el total de medallas de futbol segun la listaSocixs del club
        /// </summary>
        /// <returns></returns>
        private int CalcularTotalMedallasFutbol()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Futbolista)
                {
                    totalMedallas += socix.CantidadMedallas;
                }

            }

            return totalMedallas;
        }

        /// <summary>
        /// Metodo para calcular el total de medallas de boxeo segun la listaSocixs del club 
        /// </summary>
        /// <returns></returns>
        public int CalcularTotalMedallasBox()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Pugilista)
                {
                    totalMedallas += socix.CantidadMedallas;
                }

            }

            return totalMedallas;
        }

        /// <summary>
        /// Operator estatico que retorna un bool si se pudo agregar el socix a la listaSocixs del club
        /// </summary>
        /// <param name="miClub"></param>
        /// <param name="socix"></param>
        /// <returns></returns>
        public static bool operator +(Club miClub, Socix socix)
        {
            bool respuesta = false;
            try
            {
                if (!new GestorBaseDeDatos().DniExistente(socix.DNI))
                {
                    miClub.ListaSocixs.Add(socix);
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw new DniInvalidoException("El dni ingresado es inválido o existente", ex);
            }


            return respuesta;

        }
        /// <summary>
        /// Metodo para calcular el porcentaje de socixs competitivos segun deporte
        /// </summary>
        /// <returns></returns>
        public string SocixsCompetitivos()
        {
            StringBuilder deporteMasCompetitivo = new StringBuilder();
            float competidorxsNadadorxs = 0;
            float competidorxsFutbolistas = 0;
            float competidoresBox = 0;
            float totalCompetidores;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix.TipoSocix == ETipoSocix.Competitivo)
                {
                    if (socix.ValorCuota == ECuota.NinixsNatacion || socix.ValorCuota == ECuota.AdultxsNatacion)
                    {
                        competidorxsNadadorxs++;

                    }
                    else if (socix.ValorCuota == ECuota.NinixsFutbol || socix.ValorCuota == ECuota.AdultxsFutbol)
                    {
                        competidorxsFutbolistas++;
                    }
                    else
                    {
                        competidoresBox++;
                    }
                }
            }

            totalCompetidores = competidoresBox + competidorxsFutbolistas + competidorxsNadadorxs;

            competidoresBox = competidoresBox / totalCompetidores * 100;
            competidorxsNadadorxs = competidorxsNadadorxs / totalCompetidores * 100;
            competidorxsFutbolistas = competidorxsFutbolistas / totalCompetidores * 100;


            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Natación es de %{competidorxsNadadorxs}.");

            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Futbol es de %{competidorxsFutbolistas}.");

            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Boxeo es de % {competidoresBox}.");

            return deporteMasCompetitivo.ToString();
        }
        /// <summary>
        /// Metodo para calcular el porcentaje de ninixs segun deporte
        /// </summary>
        /// <returns></returns>
        public string DeporteConMasNinixs()
        {
            StringBuilder deporteConMasNinixs = new StringBuilder();
        float ninixsNadadorxs = 0;
        float ninixsFutbolistas = 0;
        float ninixsBox = 0;
        float totalNinixs = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix.Edad <= 12)
                {
                    if (socix.ValorCuota == ECuota.NinixsNatacion || socix.ValorCuota == ECuota.AdultxsNatacion)
                    {
                        ninixsNadadorxs++;

                    }
                    else if (socix.ValorCuota == ECuota.NinixsFutbol || socix.ValorCuota == ECuota.AdultxsFutbol)
                    {
                        ninixsFutbolistas++;
                    }
                    else
                    {
                        ninixsBox++;
                    }
                }
            }

            totalNinixs = ninixsBox + ninixsFutbolistas + ninixsNadadorxs;

            if (totalNinixs > 0)
            {                
                ninixsBox = ninixsBox / totalNinixs * 100;
                ninixsFutbolistas = ninixsFutbolistas / totalNinixs * 100;
                ninixsNadadorxs = ninixsNadadorxs / totalNinixs * 100;

                deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Natación es de %{ninixsNadadorxs}.");
                deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Boxeo es de %{ninixsBox}");
                deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Futbol es de %{ninixsBox}");
            }
            else
            {
                deporteConMasNinixs.AppendLine($"No hay ninixs socixs.");
            }
            

            return deporteConMasNinixs.ToString();
        }
        /// <summary>
        /// Metodo para calcular el porcentaje de medallas segun genero
        /// </summary>
        /// <returns></returns>
        public string MedallasSegunGenero()
        {
            StringBuilder generoMedallas = new StringBuilder();
            float medallasMasculino = 0;
            float medallasFemenino = 0;
            float medallasNB = 0;
            int totalMedallas = this.CalcularTotalMedallas();

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix.TipoSocix == ETipoSocix.Competitivo)
                {
                    switch (socix.Genero)
                    {
                        case EGenero.Masculino:
                            medallasMasculino += socix.CantidadMedallas;
                            break;
                        case EGenero.Femenino:
                            medallasFemenino += socix.CantidadMedallas;
                            break;
                        default:
                            medallasNB += socix.CantidadMedallas;
                            break;
                    }
                }
            }

            if (totalMedallas > 0)
            {
                medallasMasculino = (medallasMasculino / totalMedallas) * 100;
                medallasFemenino = (medallasFemenino / totalMedallas) * 100;
                medallasNB = (medallasNB / totalMedallas) * 100;


                generoMedallas.AppendLine($"El género masculino posee el %{medallasMasculino} de medallas.");

                generoMedallas.AppendLine($"El género femenino posee el  %{medallasFemenino} de medallas.");

                generoMedallas.AppendLine($"El género no binario posee el %{medallasNB} de medallas.");
            }
            else
            {
                generoMedallas.AppendLine($"Ningún socix posee medallas.");
            }
           

            return generoMedallas.ToString();
        }

    }
}
