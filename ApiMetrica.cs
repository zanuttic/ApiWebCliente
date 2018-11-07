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
    public class ApiMetrica
    {
        public Metrics MetricaControlerAsync(Acciones accion, Metrics metric)
        {

            MetricaControler metricaControler = new MetricaControler();
            return metricaControler.HttpConection(accion, metric);
        }
    }
}
