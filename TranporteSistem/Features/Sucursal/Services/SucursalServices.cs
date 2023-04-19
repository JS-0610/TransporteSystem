using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.Sucursal.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.Sucursal.Services
{
    public class SucursalServices : ControllerBase, ISucursalServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SucursalServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<Models.Sucursal>>> ObtenerSucursales()
        {
            try
            {
                var ListadoSucursales = await _context.Sucursal.Where(x => x.Estado ==true).ToListAsync();
                if(ListadoSucursales.Count <= 0 || ListadoSucursales == null)
                {
                    return new List<Models.Sucursal>();
                }
                return ListadoSucursales;
            }
            catch (Exception)
            {

                return NotFound("Error al obtener las sucursales");
            }
        }

        public async Task<ActionResult<List<SucursalResponseNombreIdDto>>> ObtenerNombreSucursales()
        {
            try
            {
                var ListadoSucursales = await _context.Sucursal.Where(x => x.Estado == true).ToListAsync();
                var ListadoNombreIdSucursales = _mapper.Map<List<Models.Sucursal>, List<SucursalResponseNombreIdDto>>(ListadoSucursales);
                if(ListadoNombreIdSucursales.Count <= 0 || ListadoNombreIdSucursales == null)
                {
                    return new List<SucursalResponseNombreIdDto>();
                }
                return ListadoNombreIdSucursales;
            }
            catch (Exception)
            {

                return NotFound("Error al obtener los nombres de las sucursales");
            }
        }

        public async Task<ActionResult> AgregarSucursal(SucursalRequestDto sucursalRequest)
        {
            try
            {
                var existeNombreDuplicado = await _context.Sucursal.AnyAsync(x => x.Nombre == sucursalRequest.Nombre && x.Estado == true);
                if (existeNombreDuplicado)
                {
                    return BadRequest("La sucursal ya existe");
                }
                var sucursal = _mapper.Map<Models.Sucursal>(sucursalRequest);
                await _context.AddAsync(sucursal);
                await _context.SaveChangesAsync();
                return Ok("Sucursal agregada de forma exitosa");
            }
            catch (Exception)
            {
                return NotFound("Error al agregar la sucursal");
            }
        }
        public async Task<ActionResult> ActualizarSucursal(SucursalRequestPutDto sucursalRequest)
        {
            try
            {
                
                var existe = await _context.Sucursal.AnyAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id && x.Estado==true);
                if (!existe)
                {
                    return NotFound("Sucursal no Encontrada");
                }
                var sucursal = _mapper.Map<Models.Sucursal>(sucursalRequest);
                var AntiguoRegistro = await _context.Sucursal.FirstOrDefaultAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id);
                AntiguoRegistro.Estado = false;
                _context.Update(AntiguoRegistro);
                sucursal.Sucursal_Id = 0;
                await _context.AddAsync(sucursal);
                await _context.SaveChangesAsync();
                return Ok($"Sucursal {sucursal.Nombre} ha sido actualizada");
            }
            catch (Exception)
            {
                return NotFound("Error al actualizar la sucursal");
            }
        }

        public async Task<ActionResult> EliminarSucursal(SucursalRequestDeleteDto sucursalRequest)
        {
            try
            {
                var sucursal = await _context.Sucursal.FirstOrDefaultAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id);
                if(sucursal == null)
                {
                    return NotFound("Sucursal no encontrada");
                }

                sucursal.Estado = false;
                _context.Update(sucursal);
                await _context.SaveChangesAsync();
                return Ok($"La sucursal {sucursal.Nombre} ha sido eliminada");
            }
            catch (Exception)
            {

                return NotFound("Error al actualizar la sucursal");
            }
            

        }
    }
}
