using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{

    public class ProductoNoDisponibleException : Exception
    {
        public ProductoNoDisponibleException(string mensaje) : base(mensaje) { }

    }

    public class ProductoNoExisteException : Exception 
    {
        public ProductoNoExisteException(string mensaje) : base(mensaje) { }    
    }

    public class ClienteNoExisteException : Exception 
    {
        public ClienteNoExisteException(string mensaje) : base(mensaje) { }    
    }
}

