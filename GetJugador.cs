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
           // StreamWriter WriteReportFile = File.AppendText(@"D:\\GetJugador.log");
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString("https://emplearv.azurewebsites.net/api/Jugadores/" + jugador.Personas.Documento);
                // Now parse with JSON.Net
             //   WriteReportFile.WriteLine("DownloadString :" + json);
            }
            var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
            //WriteReportFile.WriteLine("Consulta finalizada :" + json);
            //WriteReportFile.Close();
            return jugadoresGet;
        }

    }
}
