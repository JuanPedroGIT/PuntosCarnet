using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InfraccionesController : BaseApiController
    {
        private readonly IApiService _apiService;
        public InfraccionesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        public async Task<ActionResult<TipoInfraccionDTO>> insertarInfracciones(TipoInfraccionDTO tipoInfraccion)
        {
                var infra = await _apiService.InsertarInfraccion(tipoInfraccion);
                if(infra == null) return BadRequest();

                return Ok(infra);
        }

        [HttpGet("{Dni}")]
        public async Task<ActionResult<HistorialInfraccionesDniDTO>> HistorialInfracciones(string Dni)
        {   
            return Ok(await _apiService.GetHistorialInfraccionesDni(Dni));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InfraccionHabitualDTO>>> GetTop5Infracciones(){
            return Ok(await _apiService.InfraccionesHabituales());
        }

    }
}