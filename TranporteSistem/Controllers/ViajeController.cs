using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.Viaje.DTO;
using TranporteSistem.Interfaces;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeServices _services;

        public ViajeController(IViajeServices servicio)
        {
            _services = servicio;
        }

        [HttpGet("{Transportista_id:int}/{FechaInicio:DateTime}/{FechaFinal:DateTime}")]
        public async Task<ActionResult<List<ViajeResponseDto>>> Get([FromRoute]ViajeRequestGetDto request)
        {
            try
            {
                return await _services.ObtenerViajes(request);
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ViajeRequestDto request)
        {
            try
            {
                return await _services.AgregarViaje(request);
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }
    }
}
