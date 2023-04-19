using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Transportista.Dto
{
    public class TransportistaRequestPutDto
    {
        [Key]
        [Required]
        public int Transportista_Id { get; set; }

        [Required]
        [MaxLength(10,ErrorMessage ="El nombre del transportista no debe superar las 10 letras")]
        public string PrimerNombre { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "El telefono no debe superar los 14 digitos")]
        public string Telefono { get; set; }

        [Required]
        public double Tarifa { get; set; }

    }
}
