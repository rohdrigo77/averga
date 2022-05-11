using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{ 
    public class PosicionException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public PosicionException(string mensaje)
        : base(mensaje)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public PosicionException(string mensaje, Exception innerException)
       : base(mensaje, innerException)
        {
        }
    }
}
