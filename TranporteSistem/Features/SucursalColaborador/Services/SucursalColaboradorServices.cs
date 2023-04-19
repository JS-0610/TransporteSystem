using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.Features.SucursalColaborador.DTO;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem.Features.SucursalColaborador.Services
{
    public class SucursalColaboradorServices : ControllerBase, ISucursalColaboradorServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SucursalColaboradorServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<SucursalColaboradorResponseDto>>> ObtenerSucursalesColaboradores()
        {
            try
            {
                var ListadoSucursalColaborador = await (from sc in _context.SucursalColaborador
                                                 where sc.Estado == true
                                                 join c in _context.Colaborador on sc.Colaborador_Id equals c.Colaborador_Id
                                                 join s in _context.Sucursal on sc.Sucursal_Id equals s.Sucursal_Id
                                                 select new SucursalColaboradorResponseDto
                                                 {
                                                     SucursalColaborador_Id = sc.SucursalColaborador_Id,
                                                     NombreColaborador = c.PrimerNombre +" "+c.PrimerApellido,
                                                     NombreSucursal = s.Nombre,
                                                     Distancia = sc.Distancia
                                                 }).ToListAsync();
                if(ListadoSucursalColaborador.Count <= 0)
                {
                    return new List<SucursalColaboradorResponseDto>();
                }
                return ListadoSucursalColaborador;
            }
            catch (Exception)
            {

                return NotFound("Error al obtener los colaboradores por sucursales");
            }
        }
        public async Task<ActionResult<List<SucursalColaboradorResponseDto>>> ObtenerColaboradorUnicaSucursal(int id)
        {
            try
            {
                var ListadoSucursalColaborador = await (from sc in _context.SucursalColaborador
                                                 where sc.Estado == true && sc.Sucursal_Id == id
                                                 join c in _context.Colaborador on sc.Colaborador_Id equals c.Colaborador_Id
                                                 join s in _context.Sucursal on sc.Sucursal_Id equals s.Sucursal_Id
                                                 select new SucursalColaboradorResponseDto
                                                 {
                                                     SucursalColaborador_Id = sc.SucursalColaborador_Id,
                                                     NombreColaborador = c.PrimerNombre +" "+c.PrimerApellido,
                                                     NombreSucursal = s.Nombre,
                                                     Distancia = sc.Distancia
                                                 }).ToListAsync();
                if(ListadoSucursalColaborador.Count <= 0)
                {
                    return new List<SucursalColaboradorResponseDto>();
                }
                return ListadoSucursalColaborador;
            }
            catch (Exception)
            {

                return NotFound("Error al obtener los colaboradores por sucursales");
            }
        }

        public async Task<ActionResult> AgregarSucursalColaborador(SucursalColaboradorRequestDto request)
        {
            try
            {
                var existeDuplicado = await _context.SucursalColaborador.AnyAsync(x => x.Colaborador_Id == request.Colaborador_Id && x.Sucursal_Id == request.Sucursal_Id && x.Estado == true);
                if (existeDuplicado)
                {
                    return BadRequest("Este colaborador ya está agregado a esta sucursal");
                }
                var SucursalColaborador = _mapper.Map<Models.SucursalColaborador>(request);
                await _context.AddAsync(SucursalColaborador); 
                await _context.SaveChangesAsync();
                return Ok("Sucursal asginada a colaborador de forma exitosa");
            }
            catch (Exception)
            {
                return NotFound("Error al agregar sucursal al colaborador");
            }
        }

        public async Task<ActionResult> ActualizarSucursalColaborador(SucursalColaboradorRequestPutDto request)
        {
            try
            {
                var existeSucursalColaborador = await _context.SucursalColaborador.AnyAsync(x => x.SucursalColaborador_Id == request.SucursalColaborador_Id && x.Estado == true);
                if (!existeSucursalColaborador)
                {
                    return NotFound("No se ha encontrado a este colaborador en esta sucursal");
                }
                var AntiguoRegistro = await _context.SucursalColaborador.FirstOrDefaultAsync(x => x.SucursalColaborador_Id == request.SucursalColaborador_Id);
                var SucursalColaborador = _mapper.Map<Models.SucursalColaborador>(request);
                
                AntiguoRegistro.Estado = false;
                _context.Update(AntiguoRegistro);

                SucursalColaborador.SucursalColaborador_Id = 0;
                SucursalColaborador.Sucursal_Id = AntiguoRegistro.Sucursal_Id;
                SucursalColaborador.Colaborador_Id = AntiguoRegistro.Colaborador_Id;
                SucursalColaborador.Distancia = request.Distancia;
                await _context.AddAsync(SucursalColaborador);

                await _context.SaveChangesAsync();
                return Ok("Distancia entre colaborador y sucursal actualizada");
            }
            catch (Exception)
            {
                return NotFound("Error al actualizar la distancia");
            }
        }


        public async Task<ActionResult> EliminarSucursalColaborador(SucursalColaboradorRequestDeleteDto request)
        {
            try
            {
                var SucursalColaborador = await _context.SucursalColaborador.FirstOrDefaultAsync(x => x.SucursalColaborador_Id == request.SucursalColaborador_Id && x.Estado == true);
                if (SucursalColaborador is null)
                {
                    return NotFound("No se ha encontrado a este colaborador en esta sucursal");
                }
                SucursalColaborador.Estado = false;
                _context.Update(SucursalColaborador);
                await _context.SaveChangesAsync();
                return Ok("Colaborador removido de la sucursal");
            }
            catch (Exception)
            {   
                return NotFound("Error al remover el colaborador de la sucursal");
            }
        }


    }
}
