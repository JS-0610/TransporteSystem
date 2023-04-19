using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.Sucursal.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Interfaces
{
    public interface ISucursalServices
    {
        public Task<ActionResult<List<Sucursal>>> ObtenerSucursales();
        public Task<ActionResult<List<SucursalResponseNombreIdDto>>> ObtenerNombreSucursales();
        public Task<ActionResult> AgregarSucursal(SucursalRequestDto sucursalRequest);
        public Task<ActionResult> ActualizarSucursal(SucursalRequestPutDto sucursalRequest);

        public Task<ActionResult> EliminarSucursal(SucursalRequestDeleteDto sucursalRequest);
    }
}
