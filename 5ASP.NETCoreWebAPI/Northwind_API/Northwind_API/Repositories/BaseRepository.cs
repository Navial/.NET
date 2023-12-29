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

        public void Insert(TEntity entity)
        {

            _dbContext.Set<TEntity>().Add(entity);

            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();

        }

        public IList<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public bool Save(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            TEntity ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            SaveChanges();
            return false;
        }

        protected void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);
            }
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
            throw new NotImplementedException();
        }

        Task<TEntity?> IRepository<TEntity>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
