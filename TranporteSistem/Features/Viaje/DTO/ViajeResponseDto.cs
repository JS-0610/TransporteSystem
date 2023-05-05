namespace TranporteSistem.Features.Viaje.DTO
{
    public class ViajeResponseDto
    {
        public int Viaje_Id { get; set; }
        public string NombreTransportista { get; set; }

        public DateTime Fecha { get; set; }
        public double TarifaTransportista { get; set; }
        public double DistanciaRecorrida { get; set; }
        public double PagoTransportista { get; set; }

    }
}
