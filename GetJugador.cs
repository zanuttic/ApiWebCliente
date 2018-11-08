using ApiWebCliente.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebCliente
{
    public class GetJugador
    {
        public Jugadores get(Jugadores jugador) {
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString("https://emplearv.azurewebsites.net/api/Jugadores/" + jugador.Personas.Documento);
            }
            var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
            return jugadoresGet;
        }

    }
}
