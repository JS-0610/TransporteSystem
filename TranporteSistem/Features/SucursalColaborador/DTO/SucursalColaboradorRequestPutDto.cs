using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.SucursalColaborador.DTO
{
    public class SucursalColaboradorRequestPutDto
    {
        [Key]
        [Required]
        public int SucursalColaborador_Id { get; set; }

        [Required]
        [Range(1, 45, ErrorMessage = "La distancia no puede ser 0 o negativa y no debe superar los 45 Km")]
        public double Distancia { get; set; }
    }
}
