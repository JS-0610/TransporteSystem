using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Common;
using TranporteSistem.Features.ViajeDetalle.DTO;
using TranporteSistem.Interfaces;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeDetalleController : ControllerBase
    {
        public readonly IViajeDetalleServices _services;

        public ViajeDetalleController(IViajeDetalleServices services)
        {
            _services = services;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ViajeDetalleResponseDto>>> Get(int id)
        {
            try
            {
                return await _services.ObtenerViajeDetalles(id);
            }
            catch (Exception)
            {
                return NotFound(Messages.MSE001);
            }
        }
    }
}
