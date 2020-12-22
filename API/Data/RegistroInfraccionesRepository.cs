using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RegistroInfraccionesRepository : IRegistroInfraccionesRepository
    {
        private readonly PuntosCarnetContext _context;
        public RegistroInfraccionesRepository(PuntosCarnetContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<RegistroInfraccion>> GetRegistroInfraccionByIdConductor(int id)
        {
                return await _context.RegistroInfracciones
                            .Include(x => x.TipoInfraccion)
                            .Where(x => x.ConductorId == id )
                            .ToListAsync();
        }

        public async Task<int> Complete()
        {
           return await _context.SaveChangesAsync();
        }

        public void Insert(RegistroInfraccion registroInfraccion)
        {
            _context.RegistroInfracciones.Add(registroInfraccion);
        }

        public async Task<IList<RegistroInfraccion>> GetRegistroInfraccion()
        {
            return await _context.RegistroInfracciones
                    .Include(c => c.Conductor)
                    .Include(i => i.TipoInfraccion)
                    .ToListAsync();
        }
    }
}