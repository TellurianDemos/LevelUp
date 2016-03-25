using Levelup.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.DAL.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents a boolean value of success of add operation.</returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// Updates an entity if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents a boolean value of success of update operation.</returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity if it exists.
        /// </summary>
        /// <param name="id">The id of entity.</param>
        /// <returns>A task that represents a boolean value of success of delete operation.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieves entity if it exists.
        /// </summary>
        /// <param name="keys">The values of primary key for the entity to be found.</param>
        /// <returns>A task that represents a boolean value of success of find operation.</returns>
        Task<TEntity> GetByIdAsync(params object[] keys);

        /// <summary>
        /// Retrieves entities if they exist.
        /// </summary>
        /// <param name="exp">Optional array of expression for including.</param>
        /// <returns>A task that represents a boolean value of success of retrieve operation.</returns>
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] exp);

        /// <summary>
        /// Retrieves entities if they exist by delegate.
        /// </summary>
        /// <param name="lambda">Delegate for selecting.</param>
        /// <param name="exps">Optional array of expression for including.</param>
        /// <returns>A task that represents a boolean value of success of retrieve operation.</returns>
        Task<IEnumerable<TEntity>> GetByAsync(Func<TEntity, bool> lambda, params Expression<Func<TEntity, object>>[] exps);

        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <returns>A task that represents a boolean value of success of save operation.</returns>
        Task<bool> SaveAsync();
    }
}
