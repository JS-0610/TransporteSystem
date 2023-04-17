using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.DTO.Sucursal;
using TranporteSistem.Models;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;

        public SucursalController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> Get()
        {
            return await _context.Sucursal.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(SucursalRequestDto sucursalRequest)
        {
            var sucursal = _mapper.Map<Sucursal>(sucursalRequest);
            _context.Add(sucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(SucursalRequestDto sucursalRequest, int id)
        {
            var existe = await _context.Sucursal.AnyAsync(x => x.Sucursal_Id == id);
            if (!existe)
            {
                return NotFound("Sucursal no encontrada");
            }
            var sucursal = _mapper.Map<Sucursal>(sucursalRequest);
            sucursal.Sucursal_Id = id;
            _context.Update(sucursal);
            await _context.SaveChangesAsync();
            return Ok();

        }
        
    }
}
