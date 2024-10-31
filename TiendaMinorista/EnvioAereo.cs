using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class EnvioAereo : Envio
    {
        public string NumeroVuelo { get; private set; }
        public double Peso{ get; private set; }
        public EnvioAereo(string numeroEnvio, string destinatario, string direccion, string numeroVuelo, double peso) : base(numeroEnvio, destinatario, direccion)
        {
            NumeroVuelo = numeroVuelo;
            Peso = peso;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Envio Aereo #{NumeroEnvio}");
            Console.WriteLine($"Destinatario: {Destinatario}");
            Console.WriteLine($"Direccion: {Direccion}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Numero de vuelo: {NumeroVuelo}");
            Console.WriteLine($"Peso: {Peso}kg");
        }
    }
}
