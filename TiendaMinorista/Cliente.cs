using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class Cliente
    {
        public string Id { get; private set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        private List<Venta> historialCompras;

        public Cliente(string id, string nombre, string contacto)
        {
            Id = id;
            Nombre = nombre;
            Contacto = contacto;
            this.historialCompras = new List<Venta>();
        }

        public void AgregarCompra(Venta venta) 
        {
            historialCompras.Add(venta);
        }

        public List<Venta> ObtenerHistorial() 
        {
            return historialCompras.ToList();
        }

        public void ActualizarPerfil(string nombre, string contacto) 
        {
            Nombre = nombre;
            Contacto = contacto;
        }
    }
}
