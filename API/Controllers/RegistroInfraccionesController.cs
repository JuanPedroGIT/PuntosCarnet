using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RegistroInfraccionesController : BaseApiController
    {
        private readonly IApiService _apiService;
        public RegistroInfraccionesController( IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        public async Task<ActionResult<ConductorDTO>> RegistrarInfraccion(RegistroInfraccionDTO registroInfraccionDTO)
        {
            var res = await _apiService.RegistrarInfraccion(registroInfraccionDTO);
            if(res ==null ) return BadRequest();
            return Ok(res);
        }

    }
}