using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Viaje.DTO
{
    public class ViajeRequestGetDto
    {
        [Required]
        public int Transportista_id { get; set; }
        [Required(ErrorMessage ="La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de final es requerida")]
        public DateTime FechaFinal { get; set; }
    }
}
