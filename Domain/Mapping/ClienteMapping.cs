using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
        }
    }
}
