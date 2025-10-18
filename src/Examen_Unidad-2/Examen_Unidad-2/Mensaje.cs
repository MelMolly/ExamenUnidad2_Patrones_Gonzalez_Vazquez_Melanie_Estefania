using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad_2
{
    public class Mensaje
    {
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public string Contenido { get; set; }
        public DateTime Hora { get; set; }

        public void Limpiar()
        {
            Remitente = Destinatario = Contenido = string.Empty;
            Hora = DateTime.MinValue;
        }

        public override string ToString()
        {
            return $"[{Hora:HH:mm:ss}] {Remitente} → {Destinatario}: {Contenido}";
        }
    }
}
