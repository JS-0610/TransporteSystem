using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.ViajeDetalle.DTO;

namespace TranporteSistem.Interfaces
{
    public interface IViajeDetalleServices
    {
        public Task<ActionResult<List<ViajeDetalleResponseDto>>> ObtenerViajeDetalles(int id);
      
    }
}
