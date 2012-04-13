
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
            get
            {
                return this.Dao;
            }
            set
            {
                this.Dao = value as IGenericDao;
            }
        }

        #endregion Properties

        #region Methods

        public virtual DateTime GetServerDateTime()
        {
            return this.Dao.GetServerDateTime();
        }

        public T GetById<T>(object id)
        {
            return this.Dao.GetById<T>(id);
        }

        public T LoadById<T>(object id)
        {
            return this.Dao.LoadById<T>(id);
        }

        public T GetByParameters<T>(object parameters)
        {
            return this.Dao.GetByParameters<T>(parameters);
        }

        public IList<T> GetAll<T>()
        {
            return this.Dao.GetAll<T>();
        }

        public DataTable SearchByParameters<T>(object parameters)
        {
            return this.Dao.SearchByParameters<T>(parameters);
        }

        public IList<T> GetListByParameters<T>(object parameters)
        {
            return this.Dao.GetListByParameters<T>(parameters);
        }

        public DataTable SearchByParameters(string queryName, object parameters, bool absoluteColumnNames)
        {
            return this.Dao.SearchByParameters(queryName, parameters, absoluteColumnNames);
        }

        public DataTable SearchByParameters(string queryName, object parameters)
        {
            return this.Dao.SearchByParameters(queryName, parameters);
        }

        #endregion Methods
    }
}
