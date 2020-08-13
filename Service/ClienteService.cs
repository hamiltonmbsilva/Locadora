using Repository.EntityRepository;

namespace Service
{
    public class ClienteService
    {
        private readonly ClienteRepository _repositoryCliente;

        public ClienteService(ClienteRepository _repositoryCliente)
        {
            _repositoryCliente = _repositoryCliente;
        }
    }
}
