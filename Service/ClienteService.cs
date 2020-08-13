using Domain.Models;
using Repository.EntityRepository;
using Service.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ClienteService
    {
        private readonly ClienteRepository _repositoryCliente;

        public ClienteService(ClienteRepository repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public IEnumerable<Cliente> BuscarTodosCliente()
        {
            try
            {
                var todosCliente = _repositoryCliente.GetAll();
                return todosCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    var cliente = _repositoryCliente.GetById(id);
                    return cliente;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente SalvarCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Não é possivel salvar um Cliente vazio");

                //Validando cpf , chando a classe ValidaCPF para fazer a validação
                bool valido = ValidarCPF.IsCpf(cliente.CPF);

                if (valido == true)
                {
                    var cpf = _repositoryCliente.Get(x => x.CPF == cliente.CPF).FirstOrDefault();

                    if (cpf != null)
                    {
                        throw new Exception("Não é possivel salvar o Cliente com um CPF duplicato!");
                    }
                    else
                    {
                        _repositoryCliente.Save(cliente);
                        return cliente;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente AlterarCliente(Cliente c, int id)
        {
            try
            {
                if (c == null)
                {
                    throw new Exception("Não é possivel alterar o Cliente vazio");
                }
                else if (id != 0)
                {
                    //mantendo o Cliente na memoria, sem necessidade de buscar no banco
                    var guardarCliente = _repositoryCliente.GetById(id);                    

                    //Verificando se exixte algum Cliente com cpf igual no sistema
                   if (c.CPF != guardarCliente.CPF)
                    {
                        var cpf = _repositoryCliente.Get(x => x.CPF == c.CPF).FirstOrDefault();
                        if (cpf != null)
                        {
                            throw new Exception("Não e possivel alterar o cliente com o CPF Duplicado");
                        }
                    }
                    else
                    {
                        c.Id = id;
                        /*    repository.UpdateCliente(c);*/
                        _repositoryCliente.Update(c);
                        return c;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirCliente(int id)
        {
            try
            {
                if (id > 0)
                {
                    var cliente = _repositoryCliente.GetById(id);

                    if (cliente != null)
                    {
                        _repositoryCliente.Delete(x => x.Id == id);
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
