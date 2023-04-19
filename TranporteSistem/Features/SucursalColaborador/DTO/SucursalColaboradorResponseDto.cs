using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.SucursalColaborador.DTO
{
    public class SucursalColaboradorResponseDto
    {
        
        public int SucursalColaborador_Id { get; set; }
        
        public string NombreColaborador { get; set; }

        public string NombreSucursal { get; set; }

        public double Distancia { get; set; }
    }
}
