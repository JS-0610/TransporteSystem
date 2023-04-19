using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Sucursal.DTO
{
    public class SucursalRequestDeleteDto
    {
        [Key]
        [Required]
        public int Sucursal_Id { get; set; }
    }
}
