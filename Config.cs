using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebCliente
{
    public class Config
    {
        public string getURL()
        {
            var URL= "https://emplearv.azurewebsites.net";
            return URL;
            //return "http://www.empleavr.org/api/Metrics/";
        }

    }
}
