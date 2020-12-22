using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VehiculosRepository : IVehiculosRepository
    {
        private readonly PuntosCarnetContext _context;
        public VehiculosRepository(PuntosCarnetContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> GetVehiculoByMatriculaAsync(string matricula)
        {
            return await _context.Vehiculos.FirstOrDefaultAsync(x => x.Matricula == matricula);
        }

        public async Task<IReadOnlyList<Vehiculo>> GetVehiculosAsync()
        {
            var v = await _context.Vehiculos.Include(x => x.VehiculosConductores)
            .ToListAsync<Vehiculo>();

            return v;
        }
        

        public void Update(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            _context.Entry(vehiculo).State = EntityState.Modified;
        }

        public void Insert(Vehiculo vehiculo)
        {
           var r =  _context.Vehiculos.Add(vehiculo);
           
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}