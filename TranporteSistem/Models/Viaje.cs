using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class Viaje
    {
        [Key]
        public int Viaje_Id { get; set; }
        public int Transportista_Id { get; set; }
        public int Sucursal_Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public Sucursal Sucursal { get; set; }
        public Transportista Transportista { get; set; }
    }
}
