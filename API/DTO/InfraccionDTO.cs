using System;

namespace API.DTO
{
    public class InfraccionDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PuntosAdescontar { get; set; }
        public DateTime Fecha { get; set; }
    }
}