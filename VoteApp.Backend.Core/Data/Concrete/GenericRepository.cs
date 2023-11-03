﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VoteApp.Backend.Commons.Entities;
using VoteApp.Backend.Core.Data.Abstract;

namespace VoteApp.Backend.Core.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly VoteAppDbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(VoteAppDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
            _entities = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> FindByIdAsync(int id, CancellationToken ct)
        {
            return await _entities.FindAsync(new object[] { id }, ct);
        }

        public async Task<TEntity> RefreshAsync(TEntity entity, CancellationToken ct)
        {
            await _dbContext.Entry(entity).ReloadAsync(ct);
            return entity;
        }

        public async Task<IList<TEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _entities.ToListAsync(ct);
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _entities;
        }

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
        {
            return await _entities.SingleOrDefaultAsync(predicate, ct);
        }

        public async Task<IList<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
        {
            return await _entities.Where(predicate).ToListAsync(ct);
        }

        public IQueryable<TEntity> WhereAsQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            await _entities.AddAsync(entity, ct);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct)
        {
            await _entities.AddRangeAsync(entities, ct);
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            return _entities.Update(entity).Entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            return entities;
        }

        public async Task<bool> RemoveByIdAsync(int id, CancellationToken ct)
        {
            var entity = await FindByIdAsync(id, ct);
            if (entity == null)
            {
                return false;
            }

            _entities.Remove(entity);
            return true;
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
        {
            var entitiesForRemove = _entities.Where(predicate);

            _entities.RemoveRange(entitiesForRemove);
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<bool> ExistsByIdAsync(int id, CancellationToken ct)
        {
            return await _entities.AnyAsync(s => s.Id == id, ct);
        }

        public async Task RunInTransactionAsync(Func<Task> action, CancellationToken ct)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
            try
            {
                await action();

                await transaction.CommitAsync(ct);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }

        public async Task<T> RunInTransactionAsync<T>(Func<Task<T>> action, CancellationToken ct)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
            try
            {
                var result = await action();

                await transaction.CommitAsync(ct);

                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }
    }
}
