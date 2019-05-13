using System.Linq;

namespace ORM
{
    public interface IEntitySet<TEntity> : IQueryable<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Adds a new entity to the set.
        /// </summary>
        /// <param name="entity">An entity to add.</param>
        /// <returns>Added entity.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Removes the existed entity from the set.
        /// </summary>
        /// <param name="entity">An entity to remove.</param>
        /// <returns>Removed entity.</returns>
        TEntity Remove(TEntity entity);
    }
}
