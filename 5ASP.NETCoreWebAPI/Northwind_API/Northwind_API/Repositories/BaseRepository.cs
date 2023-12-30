using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using System.Linq.Expressions;
using Northwind_API.Repositories;

namespace Repository
{

    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly NorthwindContext _dbContext;
        public BaseRepository(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }


        ///// ASYNC

        Task IRepository<TEntity>.InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<TEntity>.DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<IList<TEntity>> IRepository<TEntity>.SearchForAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<bool?> IRepository<TEntity>.SaveAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<IList<TEntity>> IRepository<TEntity>.GetAllAsync()
        {
            var results = _dbContext.Set<TEntity>().ToList();
            return Task.FromResult((IList<TEntity>)results);
        }

        Task<TEntity?> IRepository<TEntity>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public static implicit operator BaseRepository<TEntity>(BaseRepository<Employee> v)
        {
            throw new NotImplementedException();
        }
    }
}
