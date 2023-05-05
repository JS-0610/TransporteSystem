using Microsoft.AspNetCore.Mvc;
using System.Net;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Interfaces
{
    public interface IColaboradorServices
    {
        public Task<ActionResult<List<Colaborador>>> ObtenerColaboradores();
        public Task<ActionResult<List<ColaboradorResponseNombreIdDto>>> ObtenerNombreColaboradores();
        public Task<ActionResult> AgregarColaborador(ColaboradorRequestDto colaboradorRequest);
        public Task<ActionResult> ActualizarColaborador(ColaboradorRequestPutDto colaborador);

        public Task<ActionResult> EliminarColaborador(ColaboradorRequestDeleteDto request);
    }
}
