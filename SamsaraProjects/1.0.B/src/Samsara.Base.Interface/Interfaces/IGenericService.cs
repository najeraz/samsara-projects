
namespace Samsara.Base.Service.Interfaces
{
    public interface IGenericService : IGenericReadOnlyService
    {
        #region Methods

        /// <summary>
        /// Saves an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Save(object entity);

        /// <summary>
        /// Saves or updates an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void SaveOrUpdate(object entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Update(object entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Delete(object entity);

        /// <summary>
        /// Refresh an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Refresh(object entity);

        #endregion Methods
    }
}
