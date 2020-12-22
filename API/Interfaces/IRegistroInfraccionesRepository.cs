using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IRegistroInfraccionesRepository
    {
        void Insert(RegistroInfraccion registroInfraccion);
         Task<IReadOnlyList<RegistroInfraccion>> GetRegistroInfraccionByIdConductor(int id);
         Task<IList<RegistroInfraccion>> GetRegistroInfraccion();

        Task<int> Complete();
    }
    
}