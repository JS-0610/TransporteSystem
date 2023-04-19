using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class Viaje
    {
        [Key]
        public int Viaje_Id { get; set; }
        public int Transportista_Id { get; set; }
        public int Sucursal_Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0;
    }
}
