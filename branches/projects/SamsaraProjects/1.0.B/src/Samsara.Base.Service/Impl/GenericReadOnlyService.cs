
using System;
using System.Collections.Generic;
using System.Data;
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Interfaces;

namespace Samsara.Base.Service.Impl
{
    public class GenericReadOnlyService : IGenericReadOnlyService
    {
        #region Properties

        protected IGenericDao Dao
        {
            get;
            set;
        }

        protected IGenericReadOnlyDao ReadOnlyDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public virtual DateTime GetServerDateTime()
        {
            return this.ReadOnlyDao.GetServerDateTime();
        }

        public T GetById<T>(object id)
        {
            return this.ReadOnlyDao.GetById<T>(id);
        }

        public T LoadById<T>(object id)
        {
            return this.ReadOnlyDao.LoadById<T>(id);
        }

        public T GetByParameters<T>(object parameters)
        {
            return this.ReadOnlyDao.GetByParameters<T>(parameters);
        }

        public IList<T> GetAll<T>()
        {
            return this.ReadOnlyDao.GetAll<T>();
        }

        public DataTable SearchByParameters<T>(object parameters)
        {
            return this.ReadOnlyDao.SearchByParameters<T>(parameters);
        }

        public IList<T> GetListByParameters<T>(object parameters)
        {
            return this.ReadOnlyDao.GetListByParameters<T>(parameters);
        }

        public DataTable SearchByParameters(string queryName, object parameters, bool absoluteColumnNames)
        {
            return this.ReadOnlyDao.SearchByParameters(queryName, parameters, absoluteColumnNames);
        }

        public DataTable SearchByParameters(string queryName, object parameters)
        {
            return this.ReadOnlyDao.SearchByParameters(queryName, parameters);
        }

        #endregion Methods
    }
}
