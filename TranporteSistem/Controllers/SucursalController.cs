using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Common;
using TranporteSistem.Features.Sucursal.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalServices _services;

        public SucursalController(ISucursalServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> Get()
        {
            try
            {
                return await _services.ObtenerSucursales();
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }

        [HttpGet("nombres")]
        public async Task<ActionResult<List<SucursalResponseNombreIdDto>>> GetNombres()
        {
            try
            {
                return await _services.ObtenerNombreSucursales();
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(SucursalRequestDto sucursalRequest)
        {
            try
            {
                return await _services.AgregarSucursal(sucursalRequest);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(SucursalRequestPutDto sucursalRequest)
        {
            try
            {
                return await _services.ActualizarSucursal(sucursalRequest);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(SucursalRequestDeleteDto sucursalRequest)
        {
            try
            {
                return await _services.EliminarSucursal(sucursalRequest);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE001);
            }

        }

    }
}
