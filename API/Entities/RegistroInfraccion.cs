using System;

namespace API.Entities
{
    public class RegistroInfraccion: BaseEntity
    {
        public RegistroInfraccion()
        {
        }

        public RegistroInfraccion(Conductor conductor, TipoInfraccion tipoInfraccion, Vehiculo vehiculo)
        {
            Conductor = conductor;
            TipoInfraccion = tipoInfraccion;
            Vehiculo = vehiculo;
        }

        public Conductor Conductor { get; set; }
        public int ConductorId { get; set; }
        public TipoInfraccion TipoInfraccion { get; set; }
        public int TipoInfraccionId { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;
        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; }





    }
}