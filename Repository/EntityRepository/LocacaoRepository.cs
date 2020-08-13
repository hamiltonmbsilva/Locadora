using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.EntityRepository
{
    public class LocacaoRepository : Repository<Locacao>
    {
        public LocacaoRepository(BaseContext context) : base(context)
        {
        }

        public Locacao GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        
        public IQueryable<Locacao> BuscarTodosAtrasados()
        {
            return GetAll()
                .Include(x => x.Cliente)
                .Include(x => x.Filme)
                .Where(x => x.DataDevolucao < DateTime.Now);
                
        } 
        
        public IQueryable<Locacao> BuscarTodosNaoAlugados()
        {
            

            return GetAll()                
                .Include(x => x.Filme)
                .Where(x => x.FilmeId != x.Filme.Id);
                
        }
    }
}
