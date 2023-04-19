using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.Transportista.Dto;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController : ControllerBase
    {
        public readonly ITransportistaServices _services;

        public TransportistaController(ITransportistaServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transportista>>> Get()
        {
            try
            {
                return await _services.ObtenerTransportistas();
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }

        [HttpGet("Nombres")]
        public async Task<ActionResult<List<TransportistaResponseNombreIdDto>>> GetNombre()
        {
            try
            {
                return await _services.ObtenerNombreTransportista();
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(TransportistaRequestDto transportistaRequest)
        {
            try
            {
                return await _services.AgregarTransportista(transportistaRequest);
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(TransportistaRequestPutDto transportistaRequest)
        {
            try
            {
                return await _services.ActualizarTransportista(transportistaRequest);
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }        
        
        [HttpDelete]
        public async Task<ActionResult> Delete(TransportistaRequestDeleteDto transportistaRequest)
        {
            try
            {
                return await _services.EliminarTransportista(transportistaRequest);
            }
            catch (Exception)
            {
                return NotFound("Error en la conexión");
            }
        }
    }
}
