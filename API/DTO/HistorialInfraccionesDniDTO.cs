using System.Collections.Generic;
using API.Entities;

namespace API.DTO
{
    public class HistorialInfraccionesDniDTO
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string  Apellidos { get; set; }
        public int Puntos { get; set; }
        public IReadOnlyList<InfraccionDTO> registroInfracciones { get; set; }

    }
}