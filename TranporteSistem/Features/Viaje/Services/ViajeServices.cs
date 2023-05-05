using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TranporteSistem.Common;
using TranporteSistem.Features.Viaje.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.Viaje.Services
{
    public class ViajeServices : ControllerBase, IViajeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ViajeServices(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult> AgregarViaje(ViajeRequestDto request)
        {
            try
            {
                var existeDuplicado = await _context.Viaje.AnyAsync(x=>x.Transportista_Id == request.Transportista_Id && x.Sucursal_Id == request.Sucursal_Id && x.Fecha == DateTime.Now);
                if(existeDuplicado)
                {
                    return BadRequest(Messages.MSI009);
                }
                var ViajeMaestro = _mapper.Map<Models.Viaje>(request);
                await _context.AddAsync(ViajeMaestro);
                await _context.SaveChangesAsync();
               
                var TarifaTransportista = await (from t in _context.Transportista
                                     where t.Transportista_Id == request.Transportista_Id
                                     select t.Tarifa).FirstOrDefaultAsync();
                
                double PagoTotalViaje = 0;
                
                foreach (var DetalleDeViaje in request.ViajesDetalle)
                {
                    var ViajeDetalle = new Models.ViajeDetalle();
                    ViajeDetalle.Viaje_Id = ViajeMaestro.Viaje_Id;
                    ViajeDetalle.SucursalColaborador_Id = DetalleDeViaje.SucursalColaborador_Id;

                    var DistanciaRecorrida = await (from sc in _context.SucursalColaborador
                                             where sc.SucursalColaborador_Id == DetalleDeViaje.SucursalColaborador_Id
                                             select sc.Distancia).FirstOrDefaultAsync();

                    await _context.AddAsync(ViajeDetalle);
                    await _context.SaveChangesAsync();

                    PagoTotalViaje += TarifaTransportista * DistanciaRecorrida;
                }

                ViajeMaestro.Total = PagoTotalViaje;
                _context.Update(ViajeMaestro);
                await _context.SaveChangesAsync();
                return Ok(Messages.MSC013);
            }
            catch (Exception)
            {
                return NotFound(Messages.MSE018);
            }
        }

        public async Task<ActionResult<List<ViajeResponseDto>>> ObtenerViajes(ViajeRequestGetDto request)
        {
            try
            {
                var ListadoViajes =await (from v in _context.Viaje
                                    where v.Transportista_Id == request.Transportista_id && v.Fecha >= request.FechaInicio && v.Fecha <= request.FechaFinal
                                    join t in _context.Transportista on v.Transportista_Id equals t.Transportista_Id
                                    select new ViajeResponseDto
                                    {
                                        Viaje_Id = v.Viaje_Id,
                                        NombreTransportista = t.PrimerNombre,
                                        Fecha = v.Fecha,
                                        PagoTransportista = v.Total,
                                        TarifaTransportista = t.Tarifa,
                                        DistanciaRecorrida = v.Total / t.Tarifa
                                    }).ToListAsync();
                if (ListadoViajes.IsNullOrEmpty())
                {
                    return new List<ViajeResponseDto>();
                }
                return ListadoViajes;
            }
            catch (Exception)
            {

                return NotFound(Messages.MSE019);
            }
        }
    }
}
