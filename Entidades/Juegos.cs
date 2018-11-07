using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebCliente.Entidades
{
    public class Juegos
    {
        public int JuegosId { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string Descripcion { get; set; }

        public Boolean Estado { get; set; }

        public Boolean Multijugador { get; set; }

    }
}
