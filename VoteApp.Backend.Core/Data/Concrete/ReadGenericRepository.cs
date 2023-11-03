using Microsoft.EntityFrameworkCore;
using VoteApp.Backend.Commons.Entities;
using VoteApp.Backend.Core.Data.Abstract;

namespace VoteApp.Backend.Core.Data.Concrete
{
    public class ReadGenericRepository<T> : IReadGenericRepository<T> where T : EntityBase
    {
        protected VoteAppDbContext DbContext;

        public ReadGenericRepository(VoteAppDbContext context)
        {
            this.DbContext = context;
        }

        public IQueryable<T> Get()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetById(int id)
        {
            return this.Get().Where(x => x.Id == id).AsNoTracking();
        }
    }
}
