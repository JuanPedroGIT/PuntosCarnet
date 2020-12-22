using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IConductorRepository
    {
        
         Task<Conductor> GetConductorByDniAsync(string dni);
         Task<IReadOnlyList<Conductor>> GetConductoresAsync();
         void InsertConductor(Conductor conductor);
         Task<int> Complete();
         
    }
}