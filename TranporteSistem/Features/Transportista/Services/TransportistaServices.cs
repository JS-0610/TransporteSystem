using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.Transportista.Dto;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.Transportista.Services
{
    public class TransportistaServices : ControllerBase, ITransportistaServices
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;

        public TransportistaServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<Models.Transportista>>> ObtenerTransportistas()
        {
            try
            {
                var ListadoTransportista = await _context.Transportista.Where(x => x.Estado == true).ToListAsync();
                if (ListadoTransportista == null || ListadoTransportista.Count <= 0)
                { 
                    return new List<Models.Transportista>();
                }
                return ListadoTransportista;
            }
            catch (Exception)
            {
                return NotFound("Error al obtener transportistas");
            }
        }

        public async Task<ActionResult<List<TransportistaResponseNombreIdDto>>> ObtenerNombreTransportista()
        {
            try
            {
                var ListadoTransportista = await _context.Transportista.Where(x => x.Estado == true).ToListAsync();
                var ListadoNombreTransportista = _mapper.Map<List<Models.Transportista>, List<TransportistaResponseNombreIdDto>>(ListadoTransportista);
                if (ListadoTransportista == null || ListadoTransportista.Count <= 0)
                { 
                    return new List<TransportistaResponseNombreIdDto>();
                }
                return ListadoNombreTransportista;
            }
            catch (Exception)
            {
                return NotFound("Error al obtener transportistas");
            }
        }

        public async Task<ActionResult> AgregarTransportista(TransportistaRequestDto transportistaRequest)
        {
            try
            {
                var existeNombreDuplicado = await _context.Transportista.AnyAsync(x => x.PrimerNombre == transportistaRequest.PrimerNombre && x.Estado == true);
                if (existeNombreDuplicado)
                {
                    return BadRequest("El transportista ya existe");
                }
                var transportista = _mapper.Map<Models.Transportista>(transportistaRequest);
                await _context.AddAsync(transportista);
                await _context.SaveChangesAsync();
                return Ok("Transportista agregado de forma exitosa");
            }
            catch (Exception)
            {

                return NotFound("Error al agregar transportistas");
            }
        }

        public async Task<ActionResult> ActualizarTransportista(TransportistaRequestPutDto transportistaRequest)
        {
            try
            {
                var existe = await _context.Transportista.AnyAsync(x => x.Transportista_Id == transportistaRequest.Transportista_Id && x.Estado==true);
                if (!existe)
                {
                    return NotFound("Transportista no encontrado");
                }
                var transportista = _mapper.Map<Models.Transportista>(transportistaRequest);
                var AntiguoRegistro = await _context.Transportista.FirstOrDefaultAsync(x => x.Transportista_Id == transportistaRequest.Transportista_Id);
                AntiguoRegistro.Estado = false;
                _context.Update(AntiguoRegistro);
                transportista.Transportista_Id = 0;
                await _context.AddAsync(transportista);
                await _context.SaveChangesAsync();
                return Ok($"Transportista {transportista.PrimerNombre} ha sido actualizado");
            }
            catch (Exception)
            {
                return NotFound("Error al actualizar transportistas");
            }
        }
        public async Task<ActionResult> EliminarTransportista(TransportistaRequestDeleteDto transportistaRequest)
        {
            try
            {
                var transportista = await _context.Transportista.FirstOrDefaultAsync(x => x.Transportista_Id == transportistaRequest.Transportista_Id);
                if(transportista == null)
                {
                    return NotFound("Transportista no encontrado");
                }
                transportista.Estado = false;
                _context.Update(transportista);
                await _context.SaveChangesAsync();
                return Ok($"Transportista {transportista.PrimerNombre} eliminado correctamente");
            }
            catch (Exception)
            {
                return NotFound("Error al eliminar transportistas");
            }
        }
    }
}
