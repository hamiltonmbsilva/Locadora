using Domain.Models;
using Repository.Context;

namespace Repository.EntityRepository
{
    public class FilmeRepository : Repository<Filme>
    {
        public FilmeRepository(BaseContext context) : base(context)
        {
        }
    }
}
