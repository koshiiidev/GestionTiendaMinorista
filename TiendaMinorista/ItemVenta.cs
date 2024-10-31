using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class ItemVenta
    {
        public Producto Producto { get; private set; }
        public int Cantidad { get; private set; }
        public double Subtotal { get; private set; }


        public ItemVenta(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            Subtotal = Producto.Precio * Cantidad;
        }
    }
}
