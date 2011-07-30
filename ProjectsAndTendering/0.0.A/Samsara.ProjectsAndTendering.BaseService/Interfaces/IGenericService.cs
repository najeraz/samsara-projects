using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.BaseService.Interfaces
{
    public interface IGenericService<T, TId>
    {
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

        /// <summary>
        /// Get entity  by Id
        /// </summary>
        /// <param name="id">The Id</param>
        /// <returns>The entity</returns>
        T GetById(TId id);

        /// <summary>
        /// Get entity by parameters
        /// </summary>
        /// <param name="parameters">The parameters</param>
        /// <returns>The entity</returns>
        T GetByParameters(GenericParameters parameters);

        //DataTable Search(GenericParameters parameters);

        //Dictionary<int, T> LoadEntities();
    }
}
