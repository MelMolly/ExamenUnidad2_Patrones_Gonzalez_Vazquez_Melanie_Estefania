using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad_2
{
    public class Program
    {
        static async Task Main()
        {
            var servidor = Servidor.Chat;

            Console.WriteLine("=== Chat interactivo con bot ===");
            Console.Write("Ingresa tu nombre: ");
            string usuario = Console.ReadLine();

            servidor.ConectarCliente(usuario);

            while (true)
            {
                Console.Write("Escribe mensaje (destinatario:mensaje) o 'salir': ");
                string input = Console.ReadLine();
                if (input.ToLower() == "salir") break;

                string[] partes = input.Split(':');
                if (partes.Length < 2)
                {
                    Console.WriteLine("Formato incorrecto. Usa: destinatario:mensaje");
                    continue;
                }

                string destinatario = partes[0].Trim();
                string contenido = string.Join(":", partes, 1, partes.Length - 1).Trim();

                await servidor.EnviarMensajeAsync(usuario, destinatario, contenido);
            }

            Console.WriteLine("Saliendo del chat...");
            Console.ReadLine();
        }
    }
}
