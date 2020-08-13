using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class FilmeMapping : Profile
    {
        public FilmeMapping()
        {
            CreateMap<FIlmeDTO, Filme>().ReverseMap();
        }
    }
}
