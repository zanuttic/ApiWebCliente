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
       // StreamWriter _log = File.AppendText(@"D:\\log_MetricsControler.log");

        private string url = "https://emplearv.azurewebsites.net/api/Metrics/";

        public Metrics HttpConection(Acciones accion, Metrics metrics)
        {
            Metrics oMetrics = new Metrics();
            try
            {

                var j = JsonConvert.SerializeObject(metrics);
                //_log.WriteLine("Inicion metrics" + j);
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
             //   _log.WriteLine(ex.Message);
             //   _log.Close();
            }
            return oMetrics;
        }


        #region Get
        public Metrics GetMetrics(Metrics metrics)
        {
            // StreamWriter WriteReportFile = File.AppendText(@"D:\\Getmetrics.log");
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(url + metrics.JugadorId);
                // Now parse with JSON.Net
                //   WriteReportFile.WriteLine("DownloadString :" + json);
            }
            var metricssGet = JsonConvert.DeserializeObject<Metrics>(json);
            //WriteReportFile.WriteLine("Consulta finalizada :" + json);
         //   _log.Close();//WriteReportFile.Close();
            return metricssGet;
        }

        #endregion

        #region Post

        public Metrics Post(Metrics metrics)
        {
            //StreamWriter _log = File.AppendText(@"D:\\Postmetrics.log");
            try
            {

            //    _log.WriteLine("Iniciando Post: ");


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

            //    _log.WriteLine("Iniciando Post:  :" + metricsesJson);

                using (var webClient = new System.Net.WebClient())
                {

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                    json = webClient.UploadString(url, metricsesJson);
                    //json = webClient.UploadString("https://localhost:44396/api/metricses/", metricsesJson);

                 //   _log.WriteLine("DownloadString :" + json);
                }
                var Metricsget = JsonConvert.DeserializeObject<Metrics>(json);
               // _log.WriteLine("Consulta finalizada :" + json);
               //  _log.Close();

                return Metricsget;
            }
            catch (Exception ex)
            {
               //// _log.WriteLine("Error" + ex.Message);
               //  _log.Close();
                return new Metrics();
            }
        }
        #endregion


    }   
}
