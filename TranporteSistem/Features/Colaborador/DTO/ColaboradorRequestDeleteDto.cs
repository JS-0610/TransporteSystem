using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Colaborador.DTO
{
    public class ColaboradorRequestDeleteDto
    {
        [Key]
        [Required]
        public int Colaborador_Id { get; set; }

    }
}
