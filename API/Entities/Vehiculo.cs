using System.Collections.Generic;

namespace API.Entities
{
    public class Vehiculo: BaseEntity
    {
        public Vehiculo()
        {
        }

        public Vehiculo(string matricula, string marca, string modelo)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
        }

        public string Matricula { get; set; }
        public string  Marca { get; set; }
        public string Modelo { get; set; }
        public IList<VehiculosConductor> VehiculosConductores { get; set; }

    }
}