using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class Venta
    {
        public string NumeroVenta { get; private set; }
        public DateTime Fecha { get; private set; }
        public Cliente Cliente { get; private set; }
        private List<ItemVenta> items;
        public double Total { get; private set; }


        public Venta (string numeroVenta, Cliente cliente)
        {
            NumeroVenta = numeroVenta;
            Fecha = DateTime.Now;
            Cliente = cliente;
            items = new List<ItemVenta>();
            Total = 0;
        }

        public void AgregarItem(Producto producto, int cantidad) 
        {
            if (!producto.VerificarDisponibilidad(cantidad))
            {
                throw new ProductoNoDisponibleException($"No hay suficiente stock del producto {producto.Nombre}");
            }

            items.Add(new ItemVenta(producto, cantidad));
            CalcularTotal();
        }

        private void CalcularTotal() 
        {
            Total = items.Sum(item => item.Subtotal);
        }

        public void FinzalizarVenta() 
        {
            foreach (var item in items) 
            {
                item.Producto.ActualizarInventario(item.Producto.CantidadInventario - item.Cantidad);
            }
            Cliente.AgregarCompra(this);
        }
    }
}
