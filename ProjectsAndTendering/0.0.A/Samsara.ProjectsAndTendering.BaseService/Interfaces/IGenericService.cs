using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;

namespace Samsara.ProjectsAndTendering.BaseService.Interfaces
{
    public interface IGenericService<T, TId, Tpmt>
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
        T GetByParameters(Tpmt parameters);

        /// <summary>
        /// Get datatable by parameters
        /// </summary>
        /// <param name="parameters">The parameters</param>
        /// <returns>DataTable</returns>
        DataTable SearchByParameters(Tpmt parameters);

        /// <summary>
        /// Returns an entity list searching by parameters
        /// </summary>
        /// <param name="parameters">The parameters</param>
        /// <returns>List of entities</returns>
        IList<T> GetListByParameters(Tpmt parameters);

        /// <summary>
        /// Get datatable by parameters from custom query
        /// </summary>
        /// <param name="queryName">Query name</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="absoluteColumnNames">If True set property name and property primary key as 
        /// name of column only if the property is an Entity
        /// otherwise only names the column as primary key from the Entity</param>
        /// <returns></returns>
        DataTable CustomSearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames);

        #endregion Methods
    }
}
