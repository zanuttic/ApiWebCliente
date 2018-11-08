using ApiWebCliente.Entidades;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;


namespace ApiWebCliente
{
    public class MetricaControler
    {

        static HttpClient client = new HttpClient();

        private string url = "https://emplearv.azurewebsites.net/api/Metrics/";

        public Metrics HttpConection(Acciones accion, Metrics metrics)
        {
            Metrics oMetrics = new Metrics();
            try
            {

                var j = JsonConvert.SerializeObject(metrics);
                switch (accion)
                {
                    case Acciones.Get:
                        oMetrics = GetMetrics(metrics);
                        break;

                    case Acciones.Gets:
                        break;
                    case Acciones.Post:
                        //crea Metrics
                        oMetrics = Post(metrics);
                        break;
                    case Acciones.Put:
                        break;
                    case Acciones.Delete:
                        break;


                }
            }
            catch (Exception ex)
            {
                var j = JsonConvert.SerializeObject(metrics);
            }
            return oMetrics;
        }


        #region Get
        public Metrics GetMetrics(Metrics metrics)
        {
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url + metrics.JugadorId);
            }
            var metricssGet = JsonConvert.DeserializeObject<Metrics>(json);
            return metricssGet;
        }

        #endregion

        #region Post

        public Metrics Post(Metrics metrics)
        {
            try
            {

                Metrics metricsesPost = new Metrics()
                {
                    CantidadEventos = metrics.CantidadEventos,
                    HoraInicio = metrics.HoraInicio,
                    JuegoId = metrics.JuegoId,
                    JugadorId = metrics.JugadorId,
                    ObservacionProfesor= metrics.ObservacionProfesor,
                    Eventos = metrics.Eventos

                };


                string json;

                var metricsesJson = JsonConvert.SerializeObject(metricsesPost);


                using (var webClient = new System.Net.WebClient())
                {

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                    json = webClient.UploadString(url, metricsesJson);
                }
                var Metricsget = JsonConvert.DeserializeObject<Metrics>(json);

                return Metricsget;
            }
            catch (Exception ex)
            {
                return new Metrics();
            }
        }
        #endregion


    }   
}
