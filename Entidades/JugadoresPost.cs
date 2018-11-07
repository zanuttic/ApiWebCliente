namespace ApiWebCliente.Entidades
{
    public class JugadoresPost
    {
        public JugadoresPost()
        {
            Personas = new PersonasPost();
        }
        //public int JugadoresId { get; set; }

        public string UserName { get; set; }

        public PersonasPost Personas { get; set; }

        public string Patologia { get; set; }

    }
}
