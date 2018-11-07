using ApiWebCliente.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebCliente
{
    public class ApiJugadores
    {
        public Jugadores JugadoresControlerAsync(Acciones accion, Jugadores jugadores)
        {

            JugadoresControler jugadoresControler = new JugadoresControler();
            var Jugador= jugadoresControler.HttpConection(accion, jugadores);

            return Jugador;

        }
    }
}
