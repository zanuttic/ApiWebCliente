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

       // StreamWriter _log = File.AppendText(@"D:\\log_JugadoresControler.log");
        
        static HttpClient client = new HttpClient();
        private string url = "https://emplearv.azurewebsites.net/api/Jugadores/";

        public Jugadores HttpConection(Acciones accion, Jugadores jugadores)
        {
            Jugadores ojugadores = new Jugadores();
            try
            {
               
                var j = JsonConvert.SerializeObject(jugadores);
                //_log.WriteLine("Inicion Jugador" + j);
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
                //_log.WriteLine("finalizo bien");
                //_log.Close();
            }catch(Exception ex)
            {
                var j = JsonConvert.SerializeObject(jugadores);
                //_log.WriteLine(ex.Message);
                //_log.Close();
            }
            return ojugadores;
        }

        #region Get
        public Jugadores get(Jugadores jugador)
        {
            // StreamWriter WriteReportFile = File.AppendText(@"D:\\GetJugador.log");
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url + jugador.Personas.Documento);
                // Now parse with JSON.Net
                //   WriteReportFile.WriteLine("DownloadString :" + json);
            }
            var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
            //WriteReportFile.WriteLine("Consulta finalizada :" + json);
            //WriteReportFile.Close();
            return jugadoresGet;
        }

        #endregion


        #region Post
        public Jugadores Post(Jugadores jugador)
        {
            //StreamWriter _log = File.AppendText(@"D:\\PostJugador.log");
            try
            {

                //_log.WriteLine("Iniciando Post: ");


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

                //_log.WriteLine("Iniciando Post:  :" + jugadoresJson);

                using (var webClient = new System.Net.WebClient())
                {

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                    json = webClient.UploadString(url, jugadoresJson);
                    //json = webClient.UploadString("https://localhost:44396/api/Jugadores/", jugadoresJson);

                    //_log.WriteLine("DownloadString :" + json);
                }
                var jugadoresGet = JsonConvert.DeserializeObject<Jugadores>(json);
                //_log.WriteLine("Consulta finalizada :" + json);
               // _log.Close();

                return jugadoresGet;
            }
            catch (Exception ex)
            {
                //_log.WriteLine("Error" + ex.Message);
               // _log.Close();
                return new Jugadores();
            }
        }

        #endregion

    }
}
