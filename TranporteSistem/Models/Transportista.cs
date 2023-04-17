using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class Transportista
    {
        [Key]
        public int Transportista_Id { get; set; }

        public string PrimerNombre { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public double Tarifa { get; set; }

    }
}
