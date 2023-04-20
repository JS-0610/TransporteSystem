using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Common;
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

                return NotFound(Messages.MSE006);
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

                return NotFound(Messages.MSE006);
            }
        }

        public async Task<ActionResult> AgregarSucursal(SucursalRequestDto sucursalRequest)
        {
            try
            {
                var existeNombreDuplicado = await _context.Sucursal.AnyAsync(x => x.Nombre == sucursalRequest.Nombre && x.Estado == true);
                if (existeNombreDuplicado)
                {
                    return BadRequest(Messages.MSI003);
                }
                var sucursal = _mapper.Map<Models.Sucursal>(sucursalRequest);
                await _context.AddAsync(sucursal);
                await _context.SaveChangesAsync();
                return Ok(Messages.MSC004);
            }
            catch (Exception)
            {
                return NotFound(Messages.MSE007);
            }
        }
        public async Task<ActionResult> ActualizarSucursal(SucursalRequestPutDto sucursalRequest)
        {
            try
            {
                
                var existe = await _context.Sucursal.AnyAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id && x.Estado==true);
                if (!existe)
                {
                    return NotFound(Messages.MSI004);
                }
                var sucursal = _mapper.Map<Models.Sucursal>(sucursalRequest);
                var AntiguoRegistro = await _context.Sucursal.FirstOrDefaultAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id);
                AntiguoRegistro.Estado = false;
                _context.Update(AntiguoRegistro);
                sucursal.Sucursal_Id = 0;
                await _context.AddAsync(sucursal);
                await _context.SaveChangesAsync();
                return Ok(Messages.MSC005);
            }
            catch (Exception)
            {
                return NotFound(Messages.MSE008);
            }
        }

        public async Task<ActionResult> EliminarSucursal(SucursalRequestDeleteDto sucursalRequest)
        {
            try
            {
                var sucursal = await _context.Sucursal.FirstOrDefaultAsync(x => x.Sucursal_Id == sucursalRequest.Sucursal_Id);
                if(sucursal == null)
                {
                    return NotFound(Messages.MSI004);
                }

                sucursal.Estado = false;
                _context.Update(sucursal);
                await _context.SaveChangesAsync();
                return Ok(Messages.MSC006);
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE009);
            }
            

        }
    }
}
