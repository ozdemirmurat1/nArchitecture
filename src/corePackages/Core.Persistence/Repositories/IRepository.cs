﻿using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IRepository<T,TEntityId> : IQuery<T> where T : Entity<TEntityId>
{
    T? Get(Expression<Func<T,bool>> predicate,
           Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null,
           bool withDeleted=false,
           bool enableTracking=true);

    IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10,
                         bool withDeleted=false,
                         bool enableTracking = true);

    IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                                  Expression<Func<T,bool>>? predicate=null,
                                  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                  int index = 0, int size = 10,bool withDeleted=false ,bool enableTracking = true);

    bool Any(Expression<Func<T, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true);
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}