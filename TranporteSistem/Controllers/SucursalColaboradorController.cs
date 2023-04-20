using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Common;
using TranporteSistem.Features.SucursalColaborador.DTO;
using TranporteSistem.Features.SucursalColaborador.Services;
using TranporteSistem.Interfaces;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalColaboradorController : ControllerBase
    {
        private readonly ISucursalColaboradorServices _services;

        public SucursalColaboradorController(ISucursalColaboradorServices servicios)
        {
            _services = servicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<SucursalColaboradorResponseDto>>> Get()
        {
            try
            {
                return await _services.ObtenerSucursalesColaboradores();
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<SucursalColaboradorResponseDto>>> Get(int id)
        {
            try
            {
                return await _services.ObtenerColaboradorUnicaSucursal(id);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(SucursalColaboradorRequestDto request)
        {
            try
            {
                return await _services.AgregarSucursalColaborador(request);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(SucursalColaboradorRequestPutDto request)
        {
            try
            {
                return await _services.ActualizarSucursalColaborador(request);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(SucursalColaboradorRequestDeleteDto request)
        {
            try
            {
                return await _services.EliminarSucursalColaborador(request);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }
    }
}
