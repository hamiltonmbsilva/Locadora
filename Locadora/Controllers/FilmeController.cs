using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller.Controllers
{
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _serviceFilme;
        private readonly IMapper _mapper;

        public FilmeController(IMapper mapper, FilmeService serviceFilme)
        {
            _mapper = mapper;
            _serviceFilme = serviceFilme;

        }
    }
}
