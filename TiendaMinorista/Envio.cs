using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public abstract class Envio
    {
        public string NumeroEnvio {  get; protected set; }
        public string Destinatario {  get; protected set; }
        public string Direccion {  get; protected set; }
        public string Estado {  get; protected set; }


        protected Envio(string numeroEnvio, string destinatario, string direccion) 
        {
            NumeroEnvio = numeroEnvio;
            Destinatario = destinatario;
            Direccion = direccion;
            Estado = "Procesando";
        }

        public void ActualizarEstado(string nuevoEstado) 
        {
            Estado = nuevoEstado;
        }

        public abstract void MostrarDetalles();
    }
}
