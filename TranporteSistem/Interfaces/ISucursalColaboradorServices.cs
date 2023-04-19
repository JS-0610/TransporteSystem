using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.SucursalColaborador.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Interfaces
{
    public interface ISucursalColaboradorServices
    {
        public Task<ActionResult<List<SucursalColaboradorResponseDto>>> ObtenerSucursalesColaboradores();
        public Task<ActionResult<List<SucursalColaboradorResponseDto>>> ObtenerColaboradorUnicaSucursal(int id);

        public Task<ActionResult> AgregarSucursalColaborador(SucursalColaboradorRequestDto request);
        public Task<ActionResult> ActualizarSucursalColaborador(SucursalColaboradorRequestPutDto request);
        public Task<ActionResult> EliminarSucursalColaborador(SucursalColaboradorRequestDeleteDto request);

    }
}
