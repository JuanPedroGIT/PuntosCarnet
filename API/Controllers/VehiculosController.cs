using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Errors;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VehiculosController : BaseApiController
    {
        private readonly IVehiculosRepository _vehiculosR;
        private readonly IApiService _apiService;
        public VehiculosController(IVehiculosRepository vehiculosR, IApiService apiService)
        {
            _apiService = apiService;
            _vehiculosR = vehiculosR;
        }

        [HttpGet]
        public async Task<ActionResult<Vehiculo>> GetVehiculos()
        {
            return Ok(await _vehiculosR.GetVehiculosAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ConductorVehiculosDTO>> InsertarVehiculo(VehiculoDTO vehiculo){
                
                ConductorVehiculosDTO v; 
                try
                {
                 v = await _apiService.InsertarVehiculo(vehiculo);
                    
                }
                catch (ApiException e)
                {
                      return BadRequest(new  ApiErrorRespuesta(e.Mensaje));                      
                }

                return Ok(v);
        }

    }
}