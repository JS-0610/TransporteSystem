using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class Colaborador
    {
        [Key]
        public int Colaborador_Id { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set;}

        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
