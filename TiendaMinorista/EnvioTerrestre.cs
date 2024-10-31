using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    public class EnvioTerrestre : Envio
    {

        public string NumeroCamion { get; private set; }
        public EnvioTerrestre(string numeroEnvio, string destinatario, string direccion, string numeroCamion) : base(numeroEnvio, destinatario, direccion)
        {
            NumeroCamion = numeroCamion;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Envio terrestre #{NumeroEnvio}");
            Console.WriteLine($"Destinatario: {Destinatario}");
            Console.WriteLine($"Direccion: {Direccion}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Numero de Camion: {NumeroCamion}");
        }

    }

}
