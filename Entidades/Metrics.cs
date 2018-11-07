using System;
using System.Collections.Generic;

namespace ApiWebCliente.Entidades
{
    /// <summary>
    /// Cada metrica equivale al juego
    /// </summary>
    public class Metrics
    {
        public Metrics()
        {
            Eventos = new List<Eventos>();
       

        }

       
        public int JugadorId { get; set; }

        public int JuegoId { get; set; }

        public DateTime HoraInicio { get; set; }

        public int CantidadEventos { get; set; }

        public List<Eventos> Eventos { get; set; }

        public string ObservacionProfesor { get; set; }

    }
}
