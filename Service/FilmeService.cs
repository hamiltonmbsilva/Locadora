using Repository.EntityRepository;

namespace Service
{
    public class FilmeService
    {
        private readonly FilmeRepository _repositoryFilme;

        public FilmeService(FilmeRepository repositoryFilme)
        {
            _repositoryFilme = repositoryFilme;
        }
    }
}
