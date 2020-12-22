using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Errors;
using API.Interfaces;
using API.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ConductoresController : BaseApiController
    {
        private readonly IApiService _apiservice;
        public ConductoresController(IApiService apiservice)
        {
            _apiservice = apiservice;
        }


        [HttpPost]
        public async Task<ActionResult<Conductor>> InsertarConductor(ConductorDTO conductorDTO)
        {
            Conductor conductor;
            try
            {
            conductor = await _apiservice.InsertarConductor(conductorDTO);
            }
            catch (ApiException e)
            {
               return BadRequest(new ApiErrorRespuesta(e.Mensaje));
            }
            return Ok(conductor);
        }

        [HttpGet("{n}")]
        public async Task<ActionResult<IReadOnlyList<ConductorNuInfraccionesDTO>>> GetTopNInfracciones(int n)
        {
            return Ok(await _apiservice.TopNConductores(n));
        }

    }
}