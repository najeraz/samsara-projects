
namespace Samsara.Base.Service.Interfaces
{
    public interface IGenericService<T, TId, Tpmt> : IGenericReadOnlyService<T, TId, Tpmt>
    {
        #region Methods

        /// <summary>
        /// Saves an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Save(T entity);

        /// <summary>
        /// Saves or updates an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void SaveOrUpdate(T entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Delete(T entity);

        /// <summary>
        /// Refresh an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Refresh(T entity);

        #endregion Methods
    }
}
