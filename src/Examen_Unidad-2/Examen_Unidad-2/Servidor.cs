using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad_2
{
    public class Servidor
    {
        private static Servidor chat;
        private readonly MensajesPool mensajes;
        private readonly HashSet<string> clientesConectados;

        private readonly Random rnd = new Random();

        private Servidor()
        {
            mensajes = new MensajesPool(50);
            clientesConectados = new HashSet<string>();
        }

        public static Servidor Chat
        {
            get
            {
                if (chat == null)
                    chat = new Servidor();
                return chat;
            }
        }

        public void ConectarCliente(string nombre)
        {
            if (clientesConectados.Add(nombre))
                Console.WriteLine($"{nombre} se ha conectado al servidor.");
        }

        public async Task EnviarMensajeAsync(string remitente, string destinatario, string contenido)
        {
            var mensaje = mensajes.ObtenerMensaje();
            mensaje.Remitente = remitente;
            mensaje.Destinatario = destinatario;
            mensaje.Contenido = contenido;
            mensaje.Hora = DateTime.Now;

            Console.WriteLine(mensaje.ToString());

            await Task.Delay(100); 
            mensajes.LiberarMensaje(mensaje);

            if (destinatario.ToLower() == "bot")
            {
                await Task.Delay(rnd.Next(300, 800));
                await EnviarMensajeAsync("Bot", remitente, GenerarRespuesta(contenido));
            }
        }

        private string GenerarRespuesta(string mensajeUsuario)
        {
            mensajeUsuario = mensajeUsuario.ToLower();

            if (mensajeUsuario.Contains("holaa"))
                return "holaa";
            else if (mensajeUsuario.Contains("como estas?"))
                return "Muy bien, y tuu";
            else if (mensajeUsuario.Contains("que haces?"))
                return "Haciendo examen y tu?";
            else if (mensajeUsuario.Contains("comiendo"))
                return "Que bien";

            string[] respuestas = {
        "Ah okay",
        "Qué bien",
        "Interesante...",
        "Cuéntame más."
    };

            return respuestas[rnd.Next(respuestas.Length)];
        }

    }
}
