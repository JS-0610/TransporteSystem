using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Models;
using TranporteSistem.Features.Colaborador.Services;
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
                return await _services.ObtenerColaboradores();
            }
            catch (Exception)
            {
                return NotFound("Colaborador no encontrado");
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
                return NotFound("Colaborador no encontrado");
            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ColaboradorRequestDto colaboradorRequest, int id)
        {
            
            return Ok();
        }
    }
}
