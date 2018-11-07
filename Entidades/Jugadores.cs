namespace ApiWebCliente.Entidades
{
    public class Jugadores
    {
        public Jugadores()
        {
            Personas = new Personas();
        }
        public int JugadoresId { get; set; }

        public string UserName { get; set; }

        public Personas Personas { get; set; }

        //public int MetricsId { get; set; }
        public string Patologia { get; set; }

    }
}
