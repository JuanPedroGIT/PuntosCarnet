using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class InfraccionRepository : IInfraccionRepository
    {
        private readonly PuntosCarnetContext _context;
        public InfraccionRepository(PuntosCarnetContext context)
        {
            _context = context;
        }
        public async Task<TipoInfraccion> GetByNombreAsync(string nombre)
        {
            return await _context.TipoInfracciones.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
        public void InsertarInfraccion(TipoInfraccion tipoInfraccion)
        {
            _context.TipoInfracciones.Add(tipoInfraccion);
        }


        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }


    }
}