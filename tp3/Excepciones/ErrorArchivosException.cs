using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorArchivosException : Exception
    {
        /// <summary>
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public ErrorArchivosException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public ErrorArchivosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

    }
}

