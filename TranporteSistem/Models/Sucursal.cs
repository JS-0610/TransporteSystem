using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class Sucursal
    {
        [Key]
        public int Sucursal_Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Boolean Estado { get; set; } = true;

    }
}
