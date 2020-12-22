using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly PuntosCarnetContext _context;
        public ConductorRepository(PuntosCarnetContext context)
        {
            _context = context;
        }

   

        public async Task<Conductor> GetConductorByDniAsync(string dni)
        {
            return await  _context.Conductores.FirstOrDefaultAsync(x => x.Dni == dni);
        }

        public async Task<IReadOnlyList<Conductor>> GetConductoresAsync()
        {
             return await  _context.Conductores
                        .Include(x => x.RegistroInfracciones)    
                        .ToListAsync();
        }

        public void InsertConductor(Conductor conductor)
        {
           _context.Conductores.Add(conductor);
        }


         public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}