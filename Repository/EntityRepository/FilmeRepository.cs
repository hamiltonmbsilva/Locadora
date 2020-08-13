using Domain.Models;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.EntityRepository
{
    public class FilmeRepository : Repository<Filme>
    {
        public FilmeRepository(BaseContext context) : base(context)
        {
        }

        public Filme GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Filme> GetByIdNaoAlugados()
        {
            return GetAll()
                .Where(x => x.Locacaos.Count == 0);
               
        }
    }
}
