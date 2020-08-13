using Repository.EntityRepository;

namespace Service
{
    public class LocacaoService
    {
        private readonly LocacaoRepository _repositoryLocacao;

        public LocacaoService(LocacaoRepository repositoryLocacao)
        {
            _repositoryLocacao = repositoryLocacao;
        }
    }
}
