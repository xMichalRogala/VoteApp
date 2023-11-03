using VoteApp.Backend.Commons.Entities;

namespace VoteApp.Backend.Core.Data.Abstract
{
    public interface IReadGenericRepository<out T> where T : EntityBase
    {
        IQueryable<T> Get();

        IQueryable<T> GetById(int id);
    }
}
