using Domain.Models;
using Repository.Context;

namespace Repository.EntityRepository
{
    public class LocacaoRepository : Repository<Locacao>
    {
        public LocacaoRepository(BaseContext context) : base(context)
        {
        }
    }
}
