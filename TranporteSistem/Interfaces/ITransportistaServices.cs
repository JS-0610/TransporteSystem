using Microsoft.AspNetCore.Mvc;
using TranporteSistem.Features.Transportista.Dto;
using TranporteSistem.Models;

namespace TranporteSistem.Interfaces
{
    public interface ITransportistaServices
    {
        public Task<ActionResult<List<Transportista>>> ObtenerTransportistas();
        public Task<ActionResult<List<TransportistaResponseNombreIdDto>>> ObtenerNombreTransportista();
        public Task<ActionResult> AgregarTransportista(TransportistaRequestDto transportistaRequest);
        public Task<ActionResult> ActualizarTransportista(TransportistaRequestPutDto transportistaRequest);
        public Task<ActionResult> EliminarTransportista(TransportistaRequestDeleteDto transportistaRequest);

    }
}
