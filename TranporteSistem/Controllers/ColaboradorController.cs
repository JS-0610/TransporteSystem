using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Models;
using TranporteSistem.Interfaces;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorServices _services;
        public ColaboradorController(IColaboradorServices colaboradorServices)
        {
            _services = colaboradorServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Colaborador>>> Get()
        {
            try
            {
                var ListadoColaboradores = await _services.ObtenerColaboradores();
                return ListadoColaboradores;
            }
            catch (Exception)
            {
                return NotFound("Error en la Conexión");
            }
        }

        [HttpGet("nombres")]
        public async Task<ActionResult<List<ColaboradorResponseNombreIdDto>>> GetNombres()
        {
            try
            {
                return await _services.ObtenerNombreColaboradores(); ;
            }
            catch (Exception)
            {
                return NotFound("Error en la Conexión");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ColaboradorRequestDto colaboradorRequest)
        {

            try
            {
                return await _services.AgregarColaborador(colaboradorRequest);
            }
            catch (Exception)
            {
                return NotFound("Error de Conexión");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(ColaboradorRequestPutDto colaboradorRequest)
        {
            try
            {
                return await _services.ActualizarColaborador(colaboradorRequest);
            }
            catch (Exception)
            {
                return NotFound("Erro de Conexión");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ColaboradorRequestDeleteDto colaboradorRequest)
        {
            try
            {
                return await _services.EliminarColaborador(colaboradorRequest);
            }
            catch (Exception)
            {
                return NotFound("Erro de Conexión");
            }
        }
    }
}
