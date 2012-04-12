
using System;
using System.Collections.Generic;
using System.Data;

namespace Samsara.Base.Service.Interfaces
{
    public interface IBaseReadOnlyService<T, TId, Tpmt>
    {
        #region Methods

        /// <summary>
        /// Get server datetime
        /// </summary>
        /// <returns>Server datetime</returns>
        DateTime GetServerDateTime();

        /// <summary>
        /// Load entity by Id
        /// </summary>
        /// <param name="id">The Id</param>
        /// <returns>The entity</returns>
        T LoadById(TId id);

        /// <summary>
        /// Get entity by Id
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
        /// Returns an all entities on a list
        /// </summary>
        /// <returns>List of entities</returns>
        IList<T> GetAll();

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
        DataTable SearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames);

        /// <summary>
        /// Get datatable by parameters from custom query
        /// </summary>
        /// <param name="queryName">Query name</param>
        /// <param name="parameters">Parameters</param>
        /// otherwise only names the column as primary key from the Entity</param>
        /// <returns></returns>
        DataTable SearchByParameters(string queryName, Tpmt parameters);

        #endregion Methods
    }
}
