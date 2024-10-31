using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class ProductoPerecible : Producto
    {
        private DateTime fechaVencimiento;

        public ProductoPerecible(string codigo, string nombre, double precio, int cantidadInventario, DateTime fechaVencimiento) : base(codigo, nombre, precio, cantidadInventario)
        {
            this.fechaVencimiento = fechaVencimiento;
        }


        public bool VerificarVencimiento() 
        {
            return DateTime.Now < fechaVencimiento;
        }


        public override void ActualizarInventario(int cantidad)
        {
            if (VerificarVencimiento())
            {
                base.ActualizarInventario(cantidad);
            }
            else
            {
                throw new Exception("Producto Vencido");
            }
            
        }
    }
}
