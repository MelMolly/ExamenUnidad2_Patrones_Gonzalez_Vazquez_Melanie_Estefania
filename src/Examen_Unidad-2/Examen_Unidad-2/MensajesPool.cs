using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad_2
{
    public class MensajesPool
    {
        private readonly Queue<Mensaje> disponibles = new Queue<Mensaje>();
        private readonly int capacidadMax;

        public MensajesPool(int capacidad)
        {
            capacidadMax = capacidad;
            for (int i = 0; i < capacidad; i++)
                disponibles.Enqueue(new Mensaje());
        }

        public Mensaje ObtenerMensaje()
        {
            if (disponibles.Count > 0)
                return disponibles.Dequeue();
            return new Mensaje();
        }

        public void LiberarMensaje(Mensaje mensaje)
        {
            mensaje.Limpiar();
            if (disponibles.Count < capacidadMax)
                disponibles.Enqueue(mensaje);
        }
    }
}
