using Microsoft.AspNetCore.Mvc;
using System.Net;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Interfaces
{
    public interface IColaboradorServices
    {
        public Task<ActionResult<List<Colaborador>>> ObtenerColaboradores();
        public Task<ActionResult> AgregarColaborador(ColaboradorRequestDto colaboradorRequest);
        public Task<ActionResult> ActualizarColaborador(Colaborador colaborador);
    }
}
