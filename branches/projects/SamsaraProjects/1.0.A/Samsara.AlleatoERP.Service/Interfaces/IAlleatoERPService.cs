
using System;
using System.Data;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Service.Interfaces
{
    public interface IAlleatoERPService
    {
        #region Methods

        /// <summary>
        /// Get server datetime
        /// </summary>
        /// <returns>Server datetime</returns>
        DateTime GetServerDateTime();

        /// <summary>
        /// Get datatable by parameters from custom query
        /// </summary>
        /// <param name="queryName">Query name</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="absoluteColumnNames">If True set property name and property primary key as 
        /// name of column only if the property is an Entity
        /// otherwise only names the column as primary key from the Entity</param>
        /// <returns></returns>
        DataTable CustomSearchByParameters(string queryName, BaseParameters parameters, bool absoluteColumnNames);

        #endregion Methods
    }
}
