using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Features.Colaborador.DTO
{
    public class ColaboradorResponseNombreIdDto
    {
        public int Colaborador_Id { get; set; }

        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
    }
}
