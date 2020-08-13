using Domain.Models;
using Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FilmeService
    {
        private readonly FilmeRepository _repositoryFilme;

        public FilmeService(FilmeRepository repositoryFilme)
        {
            _repositoryFilme = repositoryFilme;
        }

        public IEnumerable<Filme> BuscarTodosFilmes()
        {
            try
            {
                var todosCliente = _repositoryFilme.GetAll();
                return todosCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Filme BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    var cliente = _repositoryFilme.GetById(id);
                    return cliente;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Filme> BuscarPeloIdNaoAlugados()
        {
            try
            {               
                
               return _repositoryFilme.GetByIdNaoAlugados().ToList();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Filme SalvarFilme(Filme filme)
        {
            try
            {
                if (filme == null)
                    throw new Exception("Não é possivel salvar um Cliente vazio");

                _repositoryFilme.Save(filme);

                 return filme;                 
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Filme AlterarFilme(Filme c, int id)
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
                    
                    _repositoryFilme.Update(c);
                   
                    return c;                   
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirFilme(int id)
        {
            try
            {
                if (id > 0)
                {
                    var cliente = _repositoryFilme.GetById(id);

                    if (cliente != null)
                    {
                        _repositoryFilme.Delete(x => x.Id == id);
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
