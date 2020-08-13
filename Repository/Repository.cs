using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BaseContext ctx;

        protected Repository(BaseContext _ctx)
        {
            ctx = _ctx;
        }

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            var result = GetAll().Where(predicate).AsQueryable();
            return result;
        }

        public int GetNumberPages(int pageSize)
        {
            var count = ctx.Set<TEntity>().Count();

            var numberPages = count / pageSize;

            if (count % pageSize != 0)
            {
                numberPages += 1;
            }

            return numberPages;
        }

        public TEntity Find(params object[] key)
        {
            var find = ctx.Set<TEntity>().Find(key);
            Detached(find);
            return find;
        }

        public void Detached(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Detached;
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public virtual void Save(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public async Task SaveAsync(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            await ctx.SaveChangesAsync();
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
            .Where(predicate).ToList()
            .ForEach(del => ctx.Set<TEntity>().Remove(del));

            ctx.SaveChanges();
        }
    }
}
