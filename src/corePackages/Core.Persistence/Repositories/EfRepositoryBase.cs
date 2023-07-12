﻿using System.Linq.Expressions;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity,TEntityId ,TContext> : IAsyncRepository<TEntity,TEntityId>, IRepository<TEntity,TEntityId>
    where TEntity : Entity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ICollection<TEntity> AddRange(ICollection<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public TEntity Delete(TEntity entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity)
    {
        throw new NotImplementedException();
    }
}