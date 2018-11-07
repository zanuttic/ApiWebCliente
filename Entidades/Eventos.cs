namespace ApiWebCliente.Entidades
{
    /// <summary>
    /// Eventos registrados para cada jugador
    /// </summary>
    public class Eventos
    {

        public float tiempo { get; set; }

        public int CantEstimulos { get; set; }

        public bool ResultadoOK { get; set; }

        //foreing key
        public int MetricsId { get; set; }

    }
}
