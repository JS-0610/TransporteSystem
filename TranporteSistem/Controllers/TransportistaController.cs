using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranporteSistem.DTO.Transportista;
using TranporteSistem.Models;

namespace TranporteSistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;

        public TransportistaController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transportista>>> Get()
        {
            return await _context.Transportista.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(TransportistaRequestDto transportistaRequest)
        {
            var transportista = _mapper.Map<Transportista>(transportistaRequest);
            _context.Transportista.Add(transportista);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(TransportistaRequestDto transportistaRequest, int id)
        {
            var existe = await _context.Transportista.AnyAsync(x => x.Transportista_Id == id);
            if (!existe)
            {
                return NotFound("Transportista no encontrado");
            }
            var transportista = _mapper.Map<Transportista>(transportistaRequest);
            _context.Update(transportista);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
