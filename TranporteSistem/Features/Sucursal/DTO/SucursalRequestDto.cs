using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Sucursal.DTO
{
    public class SucursalRequestDto
    {
        [Required]
        [MaxLength(20,ErrorMessage = "El nombre no puede contener más de 20 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage = "La dirección no puede contener más de 50 caracteres")]
        public string Direccion { get; set; }

    }
}
