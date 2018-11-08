using ApiWebCliente.Entidades;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;


namespace ApiWebCliente
{
    public class JugadoresControler
    {

        
        static HttpClient client = new HttpClient();
        private string url = "https://emplearv.azurewebsites.net/api/Jugadores/";

        public Jugadores HttpConection(Acciones accion, Jugadores jugadores)
        {
            Jugadores ojugadores = new Jugadores();
            try
            {
               
                var j = JsonConvert.SerializeObject(jugadores);
                switch (accion)
                {
                    case Acciones.Get:
                        ojugadores= get(jugadores);
                        break;

                    case Acciones.Gets:
                        break;
                    case Acciones.Post:
                        ojugadores= Post(jugadores);
                        break;
                    case Acciones.Put:
                        break;
                    case Acciones.Delete:
                        break;
                    default:
                        return null;
                }
            }catch(Exception ex)
            {
                var j = JsonConvert.SerializeObject(jugadores);
            }
            return ojugadores;
        }

        #region Get
        public Jugadores get(Jugadores jugador)
        {
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url + jugador.Personas.Documento);
            }
            var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
            return jugadoresGet;
        }

        #endregion


        #region Post
        public Jugadores Post(Jugadores jugador)
        {
            try
            {

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
                    },
                    Patologia = jugador.Patologia

                };


                string json;

                var jugadoresJson = JsonConvert.SerializeObject(jugadoresPost);

                using (var webClient = new System.Net.WebClient())
                {

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                    json = webClient.UploadString(url, jugadoresJson);
                }
                var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);

                return jugadoresGet;
            }
            catch (Exception ex)
            {
                return new Jugadores();
            }
        }

        #endregion

    }
}
