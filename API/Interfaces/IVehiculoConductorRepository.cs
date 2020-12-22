using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IVehiculoConductorRepository
    {
        void Insert(VehiculosConductor vehiculosConductor);
        int GetNoVehiculosPorIdConductor(int id);
        Task<int> Complete();
    }
}