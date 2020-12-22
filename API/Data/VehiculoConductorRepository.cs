using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class VehiculoConductorRepository : IVehiculoConductorRepository
    {
        private readonly PuntosCarnetContext _context;
        public VehiculoConductorRepository(PuntosCarnetContext context)
        {
            _context = context;
        }

        public int GetNoVehiculosPorIdConductor(int id)
        {
           return  _context.VehiculosConductores
                        .Where(x => x.ConductorId == id)
                        .Count();
        }

        public void Insert(VehiculosConductor vehiculosConductor)
        {
            _context.VehiculosConductores.Add(vehiculosConductor);
        }

              public async Task<int> Complete()
        {
           return await _context.SaveChangesAsync();
        }
    }
}