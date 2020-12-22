using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IApiService
    {
        Task<ConductorVehiculosDTO> InsertarVehiculo(VehiculoDTO vehiculo); 
        Task<Conductor> InsertarConductor(ConductorDTO conductorDTO); 

        Task<TipoInfraccionDTO> InsertarInfraccion(TipoInfraccionDTO infraccion);

        Task<ConductorDTO> RegistrarInfraccion(RegistroInfraccionDTO registroInfraccionDTO);
        Task<HistorialInfraccionesDniDTO> GetHistorialInfraccionesDni(string dni);
        Task<IReadOnlyList<InfraccionHabitualDTO>> InfraccionesHabituales();
        Task<IReadOnlyList<ConductorNuInfraccionesDTO>> TopNConductores(int n);
         
    }
}