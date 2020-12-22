using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IInfraccionRepository
    {
        Task<TipoInfraccion> GetByNombreAsync(string nombre);
        void InsertarInfraccion(TipoInfraccion tipoInfraccion);
        Task<int> Complete();
    }
}