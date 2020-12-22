namespace API.Errors
{
    public class ApiErrorRespuesta
    {
        public ApiErrorRespuesta(string mensaje, string detalles = null)
        {
            Mensaje = mensaje;
            Detalles = detalles;
        }

        public string Mensaje { get; set; }
        public string Detalles { get; set; }
    }
}
