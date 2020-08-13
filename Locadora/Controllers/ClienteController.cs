using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _serviceCliente;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper, ClienteService serviceCliente)
        {
            _mapper = mapper;
            _serviceCliente = serviceCliente;

        }
    }
}
