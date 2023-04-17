using AutoMapper;
using TranporteSistem.DTO.Sucursal;
using TranporteSistem.DTO.Transportista;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Colaborador, ColaboradorRequestDto>().ReverseMap(); //Mapea desde Colaborador hacia ColaboradorRequestDto y viceversa
            CreateMap<Sucursal, SucursalRequestDto>().ReverseMap(); //Mapea desde Colaborador hacia ColaboradorRequestDto y viceversa
            CreateMap<Transportista, TransportistaRequestDto>().ReverseMap(); //Mapea desde Colaborador hacia ColaboradorRequestDto y viceversa
            
        }
    }
}
