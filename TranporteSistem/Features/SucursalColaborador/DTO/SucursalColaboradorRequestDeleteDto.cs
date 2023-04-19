using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.SucursalColaborador.DTO
{
    public class SucursalColaboradorRequestDeleteDto
    {
        [Key]
        [Required]
        public int SucursalColaborador_Id { get; set; }
    }
}
