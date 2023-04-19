using AutoMapper;
using TranporteSistem.Features.Colaborador.DTO;
using TranporteSistem.Features.Sucursal.DTO;
using TranporteSistem.Features.SucursalColaborador.DTO;
using TranporteSistem.Features.Transportista.Dto;
using TranporteSistem.Features.Viaje.DTO;
using TranporteSistem.Models;

namespace TranporteSistem.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Colaborador, ColaboradorRequestDto>().ReverseMap(); //Mapea desde Colaborador hacia ColaboradorRequestDto y viceversa
            CreateMap<Colaborador, ColaboradorRequestPutDto>().ReverseMap(); 
            CreateMap<Colaborador, ColaboradorResponseNombreIdDto>().ReverseMap(); 
            
            CreateMap<Sucursal, SucursalRequestDto>().ReverseMap(); 
            CreateMap<Sucursal, SucursalRequestPutDto>().ReverseMap(); 
            CreateMap<Sucursal, SucursalResponseNombreIdDto>().ReverseMap(); 
            
            CreateMap<Transportista, TransportistaRequestDto>().ReverseMap(); 
            CreateMap<Transportista, TransportistaRequestPutDto>().ReverseMap(); 
            CreateMap<Transportista, TransportistaResponseNombreIdDto>().ReverseMap(); 

            CreateMap<SucursalColaborador, SucursalColaboradorRequestDto>().ReverseMap(); 
            CreateMap<SucursalColaborador, SucursalColaboradorRequestPutDto>().ReverseMap(); 
            CreateMap<SucursalColaborador, SucursalColaboradorRequestDeleteDto>().ReverseMap();
            
            CreateMap<Viaje, ViajeRequestDto>().ForMember(x=>x.ViajesDetalle,opt => opt.Ignore()).ReverseMap(); 
            
        }
    }
}
