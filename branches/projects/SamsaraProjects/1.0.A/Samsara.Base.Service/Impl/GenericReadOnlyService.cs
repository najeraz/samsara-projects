﻿
using System;
using System.Collections.Generic;
using System.Data;
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Interfaces;

namespace Samsara.Base.Service.Impl
{
    public class GenericReadOnlyService<T, TId, TDao, Tpmt> : IGenericReadOnlyService<T, TId, Tpmt> where TDao : IGenericReadOnlyDao<T, TId, Tpmt>
    {
        #region Properties

        protected TDao Dao
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

        public T GetById(TId id)
        {
            return Dao.GetById(id);
        }

        public T GetByParameters(Tpmt parameters)
        {
            return Dao.GetByParameters(parameters);
        }

        public DataTable SearchByParameters(Tpmt parameters)
        {
            return this.Dao.SearchByParameters(parameters);
        }

        public IList<T> GetListByParameters(Tpmt parameters)
        {
            return this.Dao.GetListByParameters(parameters);
        }

        public DataTable CustomSearchByParameters(string queryName, Tpmt parameters, bool absoluteColumnNames)
        {
            return this.Dao.CustomSearchByParameters(queryName, parameters, absoluteColumnNames);
        }

        #endregion Methods
    }
}
