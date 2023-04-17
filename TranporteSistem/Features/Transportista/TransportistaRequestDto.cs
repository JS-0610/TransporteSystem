namespace TranporteSistem.DTO.Transportista
{
    public class TransportistaRequestDto
    {
        public string PrimerNombre { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public double Tarifa { get; set; }
    }
}
