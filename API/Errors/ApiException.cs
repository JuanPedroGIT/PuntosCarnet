using System;

namespace API.Errors
{
    public class ApiException: Exception
    {
        public ApiException(string mensaje, string detalles = null)
        {
            Mensaje = mensaje;
            Detalles = detalles;
        }

        public string Mensaje { get; set; } 
        public string Detalles { get; set; }
    }
}