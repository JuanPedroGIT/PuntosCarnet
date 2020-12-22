namespace API.Entities
{
    public class VehiculosConductor: BaseEntity
    {
        public VehiculosConductor()
        {
        }

        public VehiculosConductor(Conductor conductor, Vehiculo vehiculo)
        {
            Conductor = conductor;
            Vehiculo = vehiculo;
        }

        public Conductor Conductor { get; set; }
        public int ConductorId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; }



        
    }
}