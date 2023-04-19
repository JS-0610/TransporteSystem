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
                var ListaColaboradores = await _context.Colaborador.Where(x => x.Estado == true).ToListAsync();
                if (ListaColaboradores == null || ListaColaboradores.Count <= 0)
                { 
                    return new List<Models.Colaborador>();
                }
                else
                {
                    return ListaColaboradores;
                }
            }
            catch (Exception)
            {
                return NotFound("Error de conexión");
            }
        }        
        public async Task<ActionResult<List<ColaboradorResponseNombreIdDto>>> ObtenerNombreColaboradores()
        {
            try
            {
                var ListaColaboradores = await _context.Colaborador.Where(x => x.Estado == true).ToListAsync();
                var ListaNombreIdColaboradores = _mapper.Map<List<Models.Colaborador>, List<ColaboradorResponseNombreIdDto>>(ListaColaboradores);
                if (ListaNombreIdColaboradores is null || ListaNombreIdColaboradores.Count <=0)
                { 
                    return new List<ColaboradorResponseNombreIdDto>();
                }
                else
                {
                    return ListaNombreIdColaboradores;
                }
            }
            catch (Exception)
            {
                return NotFound("Error de conexión");
            }
        }
        public async Task<ActionResult> AgregarColaborador(ColaboradorRequestDto colaboradorRequest)
        {
            try
            {
                var existeNombreDuplicado = await _context.Colaborador.AnyAsync(x => x.PrimerNombre == colaboradorRequest.PrimerNombre && x.PrimerApellido == colaboradorRequest.PrimerApellido && x.Estado == true);
                if (existeNombreDuplicado)
                {
                    return BadRequest("El colaborador ya existe");
                }
                var colaborador = _mapper.Map<Models.Colaborador>(colaboradorRequest);
                await _context.AddAsync(colaborador);
                await _context.SaveChangesAsync();
                return Ok("Colaborador agregado de forma exitosa");
            }
            catch (Exception)
            {

                return BadRequest("Ocurrió un error al agregar colaborador");
            }
            
        }
        public async Task<ActionResult> ActualizarColaborador(ColaboradorRequestPutDto colaboradorRequest)
        {
            try
            {
                var existe = await _context.Colaborador.AnyAsync(x => x.Colaborador_Id == colaboradorRequest.Colaborador_Id && x.Estado == true);
                if (!existe)
                {
                    return NotFound("Colaborador no encontrado");
                }
                var colaborador = _mapper.Map<Models.Colaborador>(colaboradorRequest);
                var AntiguoRegistro = await _context.Colaborador.FirstOrDefaultAsync(x => x.Colaborador_Id == colaboradorRequest.Colaborador_Id);
                AntiguoRegistro.Estado = false;
                _context.Update(AntiguoRegistro);
                colaborador.Colaborador_Id = 0;
                await _context.AddAsync(colaborador);
                await _context.SaveChangesAsync();
                return Ok($"Colaborador {colaborador.PrimerNombre} {colaborador.PrimerApellido} ha sido actualizado");
            }
            catch (Exception)
            {
                return NotFound("Ocurrió un error al actualizar el colaborador");
            }
        }
        public async Task<ActionResult> EliminarColaborador(ColaboradorRequestDeleteDto colaboradorRequest)
        {
            try
            {
                var colaborador = await _context.Colaborador.FirstOrDefaultAsync(x => x.Colaborador_Id == colaboradorRequest.Colaborador_Id);
                if (colaborador == null)
                {
                    return NotFound("Colaborador no encontrado");
                }
                colaborador.Estado = false;
                _context.Update(colaborador);
                await _context.SaveChangesAsync();
                return Ok($"Colaborador {colaborador.PrimerNombre} {colaborador.PrimerApellido} ha sido eliminado");
            }
            catch (Exception)
            {
                return NotFound("Ocurrió un error al actualizar el colaborador");
            }
        }
    }
}
