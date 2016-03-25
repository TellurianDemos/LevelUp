using Levelup.DAL.Abstract;
using Levelup.DAL.Context;
using Levelup.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dataContext;

        public GenericRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        protected DbSet<TEntity> Dbset
        {
            get { return _dataContext.Set<TEntity>(); }
        }

        /// <summary>
        /// Asynchronously adds an entity to context.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents a boolean value of success of add operation.</returns>
        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously updates an entity if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents a boolean value of success of update operation.</returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var olditem = await _dataContext.Set<TEntity>().FindAsync(entity.Id);
            if (olditem == null)
                throw new KeyNotFoundException("No entity with particular id found!");
            _dataContext.Entry<TEntity>(olditem).CurrentValues.SetValues(entity);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously deletes an entity if it exists.
        /// </summary>
        /// <param name="id">The id of entity.</param>
        /// <returns>A task that represents a boolean value of success of delete operation.</returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("No entity with particular id found!");
            _dataContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
            _dataContext.Set<TEntity>().Remove(entity);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously retrieves entities if they exist.
        /// </summary>
        /// <param name="exps">Optional array of expression for including.</param>
        /// <returns>A task that represents a boolean value of success of retrieve operation.</returns>
        public virtual async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] exps)
        {
            IQueryable<TEntity> query = _dataContext.Set<TEntity>();

            if (exps == null)
            {
                if (query == null || !query.Any())
                    throw new ApplicationException("No item found!");
            }
            else
            {
                foreach (var item in exps)
                    query = query.Include(item);
            }

            return await Task.FromResult(query);
        }
        
        /// <summary>
        /// Asynchronously retrieves entities if they exist by delegate.
        /// </summary>
        /// <param name="lambda">Delegate for selecting.</param>
        /// <param name="exps">Optional array of expression for including.</param>
        /// <returns>A task that represents a boolean value of success of retrieve operation.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetByAsync(Func<TEntity, bool> lambda, params Expression<Func<TEntity, object>>[] exps)
        {
            var entities = _dataContext.Set<TEntity>().Where(lambda).AsEnumerable<TEntity>();
            if (entities == null) throw new ApplicationException("No entities found!");
            return await Task.FromResult(entities);
        }

        /// <summary>
        /// Asynchronously retrieves entity if it exists.
        /// </summary>
        /// <param name="keys">The values of primary key for the entity to be found.</param>
        /// <returns>A task that represents a boolean value of success of find operation.</returns>
        public virtual async Task<TEntity> GetByIdAsync(params object[] keys)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(keys);
            if (entity == null) throw new KeyNotFoundException("No entity with particular key(s) found!");
            return await Task.FromResult(entity);
        }

        /// <summary>
        /// Asynchronously saves changes in context.
        /// </summary>
        /// <returns>A task that represents a boolean value of success of save operation.</returns>
        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                await _dataContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
