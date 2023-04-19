using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Colaborador.DTO
{
    public class ColaboradorRequestPutDto
    {
        [Key]
        [Required]
        public int Colaborador_Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El primer nombre debe ser maximo 10 letras")]
        public string PrimerNombre { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El primer apellido debe ser maximo 10 letras")]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "El DNI ser maximo 13 numeros")]
        public string Dni { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "La direccion debe ser maximo 50 Letras")]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "El Telefono ser maximo 14 numeros")]
        public string Telefono { get; set; }
    }
}
