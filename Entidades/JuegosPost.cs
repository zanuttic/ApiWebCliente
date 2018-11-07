using System;

namespace ApiWebCliente.Entidades
{
    //[Serializable]
    public class JuegosPost //: MonoBehaviour
    {

        public string Nombre  { get; set; }

        public string Categoria { get; set; }

        public string Descripcion { get; set; }

        public Boolean Estado { get; set; }

        public Boolean Multijugador { get; set; }

    }
}

