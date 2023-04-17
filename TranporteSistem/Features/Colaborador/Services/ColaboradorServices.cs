using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.Colaborador.Services
{
    public class ColaboradorServices : ControllerBase, IColaboradorServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ColaboradorServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<Models.Colaborador>>> ObtenerColaboradores()
        {
            try
            {
                var ListaColaboradores = await _context.Colaborador.ToListAsync();
                if (ListaColaboradores == null)
                {
                    return NotFound("No se ha encontrado ningun colaborador");
                }else
                {
                    return ListaColaboradores;
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AgregarColaborador(ColaboradorRequestDto colaboradorRequest)
        {
            var colaborador = _mapper.Map<Models.Colaborador>(colaboradorRequest);
            _context.Add(colaborador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarColaborador(Models.Colaborador colaborador)
        {
            var existe = await _context.Colaborador.AnyAsync(x => x.Colaborador_Id == colaborador.Colaborador_Id);
            if (!existe)
            {
                return NotFound("Colaborador no encontrado");
            }
            _context.Update(colaborador);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
