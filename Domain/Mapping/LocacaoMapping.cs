using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class LocacaoMapping : Profile
    {
        public LocacaoMapping()
        {
            CreateMap<LocacaoDTO, Locacao>().ReverseMap();
        }
    }
}
