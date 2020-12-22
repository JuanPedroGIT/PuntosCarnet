using System.Collections.Generic;

namespace API.Entities
{
    public class Conductor: BaseEntity
    {
        public Conductor()
        {
        }

        public Conductor(string dni, string nombre, string apellidos, int puntos)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Puntos = puntos;
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string  Apellidos { get; set; }
        public int Puntos { get; set; }
        public IList<VehiculosConductor> VehiculosConductores { get; set; }
        public IList<RegistroInfraccion> RegistroInfracciones { get; set; }
        
    }
}