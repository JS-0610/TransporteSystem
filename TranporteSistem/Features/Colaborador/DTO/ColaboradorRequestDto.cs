namespace TranporteSistem.Features.Colaborador.DTO
{
    public class ColaboradorRequestDto
    {
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }

        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
