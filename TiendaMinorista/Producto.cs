using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public abstract class Producto
    {
        protected string codigo;
        protected string nombre;
        protected double precio;
        protected int cantidadInventario;


        public string Codigo => codigo;
        public string Nombre => nombre;
        public double Precio => precio;
        public int CantidadInventario => cantidadInventario;


        public Producto(string codigo, string nombre, double precio, int cantidadInventario) 
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidadInventario = cantidadInventario;
        }

        public virtual void ActualizarInventario(int cantidad) 
        {
            cantidadInventario = cantidad;
        }

        public bool VerificarDisponibilidad(int cantidad)
        {
            return cantidadInventario >= cantidad;
        }
    }
}
