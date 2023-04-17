using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class ViajeDetalle
    {
        [Key]
        public int ViajeDetalle_Id { get; set; }
        public int Viaje_Id { get; set; }
        public int SucursalColaborador_Id { get; set; }

        public Viaje Viaje { get; set; }
        public SucursalColaborador SucursalColaborador { get; set; }
    }
}
