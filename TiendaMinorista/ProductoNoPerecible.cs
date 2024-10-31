using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class ProductoNoPerecible : Producto
    {
        private string categoria;

        public ProductoNoPerecible(string codigo, string nombre, double precio, int cantidadInventario, string categoria) : base(codigo, nombre, precio, cantidadInventario)
        {
            this.categoria = categoria;
        }

        public override void ActualizarInventario(int cantidad)
        {
            base.ActualizarInventario(cantidad);
        }
    }
}
