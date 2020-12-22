using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IVehiculosRepository
    {
         Task<Vehiculo> GetVehiculoByMatriculaAsync(string matricula);
         Task<IReadOnlyList<Vehiculo>> GetVehiculosAsync();

         void Update(Vehiculo vehiculo);
         void Insert(Vehiculo vehiculo);
        Task<int> Complete();
    }
}