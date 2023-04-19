using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.Viaje.DTO;

namespace TranporteSistem.Interfaces
{
    public interface IViajeServices
    {
        public Task<ActionResult<List<ViajeResponseDto>>> ObtenerViajes(ViajeRequestGetDto request);

        public Task<ActionResult> AgregarViaje(ViajeRequestDto request);
    }
}
