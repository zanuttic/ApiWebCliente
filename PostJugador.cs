using ApiWebCliente.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebCliente
{
    public class PostJugador
    {
        public Jugadores Post(Jugadores jugador) {
            StreamWriter _log = File.AppendText(@"D:\\PostJugador.log");
            try
            {
               
                _log.WriteLine("Iniciando Post: ");


                JugadoresPost jugadoresPost = new JugadoresPost()
                {
                    UserName = jugador.UserName,
                    Personas = new PersonasPost()
                    {
                        JugadoresId = 1,
                        Apellido = jugador.Personas.Apellido,
                        Nombre = jugador.Personas.Nombre,
                        Pais = jugador.Personas.Pais,
                        Provincia = jugador.Personas.Provincia,
                        Cuidad = jugador.Personas.Cuidad,
                        CorreoElectronico = jugador.Personas.CorreoElectronico,
                        FechaNacimiento = jugador.Personas.FechaNacimiento,
                        Sexo = jugador.Personas.Sexo,
                        Documento = jugador.Personas.Documento
                    }

                };


                string json;

                var jugadoresJson = JsonConvert.SerializeObject(jugadoresPost);

                _log.WriteLine("Iniciando Post:  :" + jugadoresJson);

                using (var webClient = new System.Net.WebClient())
                {

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                    json = webClient.UploadString("https://emplearv.azurewebsites.net/api/Jugadores/", jugadoresJson);
                   
                    _log.WriteLine("DownloadString :" + json);
                }
                var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
                _log.WriteLine("Consulta finalizada :" + json);
                _log.Close();

                return jugadoresGet;
            }
            catch(Exception ex)
            {
                _log.WriteLine("Error" + ex.Message);
                _log.Close();
                return new Jugadores();
            }
        }

    }
}
