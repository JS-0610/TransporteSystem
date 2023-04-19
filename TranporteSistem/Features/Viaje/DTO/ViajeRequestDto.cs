using System.ComponentModel.DataAnnotations;
using TranporteSistem.Features.ViajeDetalle.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Features.Viaje.DTO
{
    public class ViajeRequestDto
    {
        public int Transportista_Id { get; set; }
        public int Sucursal_Id { get; set; }
        public List<ViajeDetalleRequestDto> ViajesDetalle { get; set; }
    }
}
