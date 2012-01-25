
using System;
using System.Data;
using Samsara.AlleatoERP.Dao.Impl;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Service.Impl
{
    public class AlleatoERPService : IAlleatoERPService
    {
        #region Properties

        protected AlleatoERPDao Dao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public virtual DateTime GetServerDateTime()
        {
            return this.Dao.GetServerDateTime();
        }

        public DataTable CustomSearchByParameters(string queryName, GenericParameters parameters, bool absoluteColumnNames)
        {
            return this.Dao.CustomSearchByParameters(queryName, parameters, absoluteColumnNames);
        }

        #endregion Methods
    }
}
