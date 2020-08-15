using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly LocacaoService _serviceLocacao;
        private readonly FilmeService _serviceFilme;
        private readonly ClienteService _serviceCliente;
        private readonly IMapper _mapper;

        public LocacaoController(IMapper mapper, LocacaoService serviceLocacao, FilmeService serviceFilme, ClienteService serviceCliente)
        {
            _mapper = mapper;
            _serviceLocacao = serviceLocacao;
            _serviceFilme = serviceFilme;
            _serviceCliente = serviceCliente;
        }

        //GET: api/cliente 
        [HttpGet]
        public ActionResult<Locacao> GetAll()
        {
            try
            {
                var cliente = _serviceLocacao.BuscarTodosLocacao().ToList();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente/1        
        [HttpGet("{id}")]
        public ActionResult<Locacao> GetById(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var cliente = _serviceLocacao.BuscarPeloId(id);

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
        public ActionResult<Locacao> Post([FromBody] Locacao locacao)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                DateTime dia = DateTime.Now;

                var filme = _serviceFilme.BuscarPeloId(locacao.FilmeId);

                var tipo = filme.Tipo;
                
                if(tipo == Domain.Enum.EnumTipo.lancamento)
                {
                    locacao.DataDevolucao = dia.AddDays(2);
                }
                else if(tipo == Domain.Enum.EnumTipo.comun)
                {
                    locacao.DataDevolucao = dia.AddDays(3);
                }


                var retorno = _serviceLocacao.SalvarLocacao(locacao);

                if (retorno == null)
                {
                    return BadRequest("Erro ao Salvar");
                }

                return Ok(locacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/cliente
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Locacao locacao, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _serviceLocacao.AlterarLocacao(locacao, id);

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
                _serviceLocacao.ExcluirLocacao(id);

                return Ok("Usúario deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("atrasado")]
        public ActionResult<Locacao> GetAllAtraso()
        {
            try
            {
                var locacao = _serviceLocacao.BuscarTodosAtrasados().ToList();

                var clienteDTO = _mapper.Map<List<AtrasadoDTO>>(locacao);

                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("filmeNaoAlugados")]
        public ActionResult<Locacao> GetAllFilmesNaoAlugados()
        {
            try
            {            

                var filmes = _serviceFilme.BuscarPeloIdNaoAlugados().ToList();            

                var clienteDTO = _mapper.Map<List<FIlmeDTO>>(filmes);

                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("segundoCliente")]
        public ActionResult<Locacao> SegundoCliente()
        {
            try
            {
                var cliente = _serviceCliente.BuscarTodosCliente().ToList();

                var locacao = _serviceLocacao.BuscarTodosLocacao().ToList();
                locacao.OrderByDescending(x => x.Cliente.Locacaos.Count());
                locacao.GroupBy(x => x.ClientId);
                var segundoCliente = locacao[1];                


                var clienteDTO = _mapper.Map<SegundoDTO>(segundoCliente);

                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("cincoFilmes")]
        public ActionResult<Locacao> CincoFilmes()
        {
            try
            {
                int i;
                int quant = 0;

                IList<Locacao> segundoCliente = new List<Locacao>();

                var dataAno = DateTime.Now.AddYears(1);
                var dataAtual = DateTime.Now;

                var filmes = _serviceLocacao.BuscarPorData(dataAtual, dataAno).ToList();

                foreach(Locacao filme in filmes)
                {
                    for(i = 0; i < 5 ; i++)
                     {
                        segundoCliente.Add(filme);
                        break;
                    }
                    quant = quant + 1;

                    if (quant == 3)
                        break;
                }
               

                var locacaoDTO = _mapper.Map<List<FilmesNaoAlugadosDTO>>(segundoCliente);

                return Ok(locacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("tresFilmes")]
        public ActionResult<Locacao> TresFilmes()
        {
            try
            {
                int i;
                int quant = 0;

                IList<Locacao> segundoCliente = new List<Locacao>();

                var dataAno = DateTime.Now.AddDays(7);
                var dataAtual = DateTime.Now;

                var filmes = _serviceLocacao.BuscarPorDatatres(dataAtual, dataAno).ToList();

                foreach (Locacao filme in filmes)
                {
                    for (i = 0; i < 3; i++)
                    {
                        segundoCliente.Add(filme);
                        break;
                    }

                    quant = quant + 1;

                    if (quant == 3)
                        break;
                   
                }


                var locacaoDTO = _mapper.Map<List<FilmesNaoAlugadosDTO>>(segundoCliente);

                return Ok(locacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
