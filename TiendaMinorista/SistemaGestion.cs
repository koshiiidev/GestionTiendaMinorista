using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class SistemaGestion
    {
        private List<Producto> inventario;
        private List<Cliente> clientes;
        private List<Venta> ventas;
        private List<Envio> envios;

        public SistemaGestion()
        {
            inventario = new List<Producto>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();
            envios = new List<Envio>();
        }

        public void RegistrarVenta(string numeroVenta, string clienteId, Dictionary<string, int> productosYCantidades)
        {
            try
            {
                var cliente = BuscarCliente(clienteId);
                var venta = new Venta(numeroVenta, clienteId);

                foreach (var item in productosYCantidades)
                {
                    var producto = BuscarProducto(item.Key);
                    venta.AgregarItem(producto, item.Value);
                }

                venta.FinzalizarVenta();
                ventas.Add(venta);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al registra la venta: {e.Message}");
                throw;
            }
        }

        public void ActualizarInventario(string codigoProducto, int nuevaCantidad)
        {
            try
            {
                var producto = BuscarProducto(codigoProducto);
                producto.ActualizarInventario(nuevaCantidad);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro al actualizar el inventario: {e.Message}");
                throw;
            }
        }

        public Producto BuscarProducto(string codigo)
        {
            var producto = inventario.FirstOrDefault(p => p.Codigo == codigo);
            if (producto == null)
            {
                throw new ProductoNoExisteException($"No se encontro el producto con el codigo {codigo}");
            }
            return producto;
        }

        public Cliente BuscarCliente(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                throw new ClienteNoExisteException($"No se encontro el cliente con el ID {id}");
            }
            return cliente;
        }

        public void AgregarEnvio(Envio envio)
        {
            envios.Add(envio);
        }

        public void ActualizarEstadoEnvio(string numeroEnvio, string nuevoEstado)
        {
            var envio = envios.FirstOrDefault(e => e.NumeroEnvio == numeroEnvio);
            if (envio == null)
            {
                throw new Exception($"No se encontro el envio con el numero {numeroEnvio}");
            }

            envio.ActualizarEstado(nuevoEstado);
        }

        public void MostrarTodosLosEnvios()
        {
            foreach (var envio in envios)
            {
                envio.MostrarDetalles();
                Console.WriteLine();
            }
        }
    }
}
