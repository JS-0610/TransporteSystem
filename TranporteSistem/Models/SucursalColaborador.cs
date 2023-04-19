using System.ComponentModel.DataAnnotations;

namespace TranporteSistem.Models
{
    public class SucursalColaborador
    {
        [Key]
        public int SucursalColaborador_Id { get; set; }
        public int Colaborador_Id { get; set; }

        public int Sucursal_Id { get; set; }
        public double Distancia { get; set; }

        public Boolean Estado { get; set; } = true;

    }
}
