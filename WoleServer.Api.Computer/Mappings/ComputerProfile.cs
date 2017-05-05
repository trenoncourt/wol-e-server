using AutoMapper;
using WoleServer.Api.Computer.Dtos;

namespace WoleServer.Api.Computer.Mappings
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<Domain.Models.Computer, GetComputersResult>().ReverseMap();
            CreateMap<Domain.Models.Computer, PostComputerRequest>().ReverseMap();
        }
    }
}