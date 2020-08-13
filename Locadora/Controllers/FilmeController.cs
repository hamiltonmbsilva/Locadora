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
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _serviceFilme;
        private readonly IMapper _mapper;

        public FilmeController(IMapper mapper, FilmeService serviceFilme)
        {
            _mapper = mapper;
            _serviceFilme = serviceFilme;

        }

        //GET: api/cliente 
        [HttpGet]
        public ActionResult<Filme> GetAll()
        {
            try
            {
                var cliente = _serviceFilme.BuscarTodosCliente().ToList();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente/1        
        [HttpGet("{id}")]
        public ActionResult<Filme> GetById(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var cliente = _serviceFilme.BuscarPeloId(id);

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
        public ActionResult<Filme> Post([FromBody] Filme filme)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var retorno = _serviceFilme.SalvarFilme(filme);

                if (retorno == null)
                {
                    return BadRequest("Erro ao Salvar");
                }

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/cliente
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Filme filme, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _serviceFilme.AlterarFilme(filme, id);

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
                _serviceFilme.ExcluirFilme(id);

                return Ok("Usúario deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
