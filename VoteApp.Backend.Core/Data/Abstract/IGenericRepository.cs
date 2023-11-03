using System.Linq.Expressions;
using VoteApp.Backend.Commons.Entities;

namespace VoteApp.Backend.Core.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity?> FindByIdAsync(int id, CancellationToken ct);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);

        Task<IList<TEntity>> GetAllAsync(CancellationToken ct);

        IQueryable<TEntity> GetAllAsQueryable();

        Task<IList<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);

        IQueryable<TEntity> WhereAsQueryable(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken ct);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        Task<bool> RemoveByIdAsync(int id, CancellationToken ct);

        void Remove(TEntity entity);

        void RemoveWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);

        Task SaveChangesAsync(CancellationToken ct);

        Task<bool> ExistsByIdAsync(int id, CancellationToken ct);

        Task RunInTransactionAsync(Func<Task> action, CancellationToken ct);

        Task<T> RunInTransactionAsync<T>(Func<Task<T>> action, CancellationToken ct);

        Task<TEntity> RefreshAsync(TEntity entity, CancellationToken ct);
    }
}
