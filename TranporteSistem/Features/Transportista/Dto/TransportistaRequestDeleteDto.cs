using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Transportista.Dto
{
    public class TransportistaRequestDeleteDto
    {
        [Key]
        [Required]
        public int Transportista_Id { get; set; }
    }
}
