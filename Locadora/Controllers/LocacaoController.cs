using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly LocacaoService _serviceLocacao;
        private readonly IMapper _mapper;

        public LocacaoController(IMapper mapper, LocacaoService serviceLocacao)
        {
            _mapper = mapper;
            _serviceLocacao = serviceLocacao;

        }
    }
}
