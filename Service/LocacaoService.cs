using Domain.Models;
using Repository.EntityRepository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class LocacaoService
    {
        private readonly LocacaoRepository _repositoryLocacao;

        public LocacaoService(LocacaoRepository repositoryLocacao)
        {
            _repositoryLocacao = repositoryLocacao;
        }

        public IEnumerable<Locacao> BuscarTodosLocacao()
        {
            try
            {
                var todosLocacao = _repositoryLocacao.GetAll();
                return todosLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Locacao> BuscarTodosAtrasados()
        {
            try
            {
                var todosLocacao = _repositoryLocacao.BuscarTodosAtrasados();
                return todosLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IEnumerable<Locacao> BuscarTodosNaoAlugados()
        {
            try
            {
                var todosLocacao = _repositoryLocacao.BuscarTodosNaoAlugados();
                return todosLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Locacao> BuscarPorData(DateTime dataAtual, DateTime dataAno)
        {
            try
            {
                var todosLocacao = _repositoryLocacao.BuscarPorData(dataAtual, dataAno);
                return todosLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IEnumerable<Locacao> BuscarPorDatatres(DateTime dataAtual, DateTime dataAno)
        {
            try
            {
                var todosLocacao = _repositoryLocacao.BuscarPorDatatres(dataAtual, dataAno);
                return todosLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Locacao BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    var locacao = _repositoryLocacao.GetById(id);
                    return locacao;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Locacao SalvarLocacao(Locacao locacao)
        {
            try
            {
                if (locacao == null)
                    throw new Exception("Não é possivel salvar um Cliente vazio");

                _repositoryLocacao.Save(locacao);

                return locacao;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Locacao AlterarLocacao(Locacao c, int id)
        {
            try
            {
                if (c == null)
                {
                    throw new Exception("Não é possivel alterar o Cliente vazio");
                }
                else if (id != 0)
                {
                    c.Id = id;

                    _repositoryLocacao.Update(c);

                    return c;
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirLocacao(int id)
        {
            try
            {
                if (id > 0)
                {
                    var locacao = _repositoryLocacao.GetById(id);

                    if (locacao != null)
                    {
                        _repositoryLocacao.Delete(x => x.Id == id);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
