using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Linq;

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

        //Cadsatrar um cliente json
        //{
        //  "Nome":"teste",
        //  "CPF":"47468444455",
        //  "dataNascimento":"1965-08-25"         
        //}

    //GET: api/cliente 
    [HttpGet]
        public ActionResult<Cliente> GetAll()
        {
            try
            {
                var cliente = _serviceCliente.BuscarTodosCliente().ToList();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente/1        
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var cliente = _serviceCliente.BuscarPeloId(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/cliente
        [HttpPost]        
        public ActionResult<Cliente> Post([FromBody] Cliente cliente)
        {
            try
            {
                //var cliente = JsonConvert.DeserializeObject<Cliente>(obj.ToString());

                if (cliente.CPF == null)
                {
                    return NotFound("Não é possivel salvar um cliente com o CPF vazio !");
                }

                //Removendo os espações antes e depois da string
                cliente.CPF = cliente.CPF.Trim();

                //Esta subistituindo o ('.') por espaço e o ('-') tambem por espaço
                cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");


                var retorno = _serviceCliente.SalvarCliente(cliente);

                if (retorno == null)
                {
                    return BadRequest("Erro ao Salvar");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/cliente
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Cliente cliente, int id)
        {
            try
            {
                
                //Removendo os espações antes e depois da string
                cliente.CPF = cliente.CPF.Trim();

                //Esta subistituindo o ('.') por espaço e o ('-') tambem por espaço
                cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");

                var result = _serviceCliente.AlterarCliente(cliente, id);

                if (result == null)
                    return BadRequest("Cliente não encontrado!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/cliente/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _serviceCliente.ExcluirCliente(id);

                return Ok("Usúario deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
