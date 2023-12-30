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




        // GET ALL 
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        // GET BY ID
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<TEntity>(id);
        }
        
        // DELETE BY ID

        public virtual async Task DeleteAsync(int id)
        {

            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                // Lancer une exception si l'entité n'est pas trouvée
                throw new KeyNotFoundException($"Entité avec l'ID '{id}' non trouvée.");
            }
            

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        // INSERT
        public async Task InsertAsync(TEntity entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

        }

        // UPDATE 
        public async Task<bool?> SaveAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            // Vérifier si l'entité existe déjà
            var existingEntity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (existingEntity != null)
            {
                // Mettre à jour l'entité existante
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                // Ajouter la nouvelle entité
                await _dbContext.Set<TEntity>().AddAsync(entity);
            }

            // Enregistrer les changements dans la base de données
            var result = await _dbContext.SaveChangesAsync();
            return result > 0; // Retourner true si des modifications ont été enregistrées

        }

        public Task<IList<TEntity>> SearchForAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
