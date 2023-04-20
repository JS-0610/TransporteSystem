using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TranporteSistem.Common;
using TranporteSistem.Features.ViajeDetalle.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.ViajeDetalle.Services
{
    public class ViajeDetalleServices : ControllerBase, IViajeDetalleServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ViajeDetalleServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ViajeDetalleResponseDto>>> ObtenerViajeDetalles(int id)
        {
            try
            {
                var ListadoViajeDetalles = await (from vd in _context.ViajeDetalle
                                           where vd.Viaje_Id == id
                                           join sc in _context.SucursalColaborador on vd.SucursalColaborador_Id equals sc.SucursalColaborador_Id
                                           join c in _context.Colaborador on sc.Colaborador_Id equals c.Colaborador_Id
                                           join v in _context.Viaje on vd.Viaje_Id equals v.Viaje_Id
                                           join t in _context.Transportista on v.Transportista_Id equals t.Transportista_Id
                                           select new ViajeDetalleResponseDto
                                           {
                                               ViajeDetalle_Id = vd.ViajeDetalle_Id,
                                               NombreColaborador = c.PrimerNombre + " " + c.PrimerApellido,
                                               DistanciaRecorrida = sc.Distancia,
                                               Pago = t.Tarifa * sc.Distancia
                                           }).ToListAsync();
                if (ListadoViajeDetalles.IsNullOrEmpty())
                {
                    return new List<ViajeDetalleResponseDto>();
                }
                return ListadoViajeDetalles;
            }
            catch (Exception)
            {
                return NotFound(Messages.MSE020);
            }
        }
    }
}
