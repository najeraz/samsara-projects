
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

        #endregion Properties

        #region Methods

        public virtual DateTime GetServerDateTime()
        {
            return this.Dao.GetServerDateTime();
        }

        public T GetById<T>(object id)
        {
            return Dao.GetById<T>(id);
        }

        public T GetByParameters<T>(object parameters)
        {
            return Dao.GetByParameters<T>(parameters);
        }

        public IList<T> GetAll<T>()
        {
            return Dao.GetAll<T>();
        }

        public DataTable SearchByParameters<T>(object parameters)
        {
            return this.Dao.SearchByParameters<T>(parameters);
        }

        public IList<T> GetListByParameters<T>(object parameters)
        {
            return this.Dao.GetListByParameters<T>(parameters);
        }

        public DataTable CustomSearchByParameters<T>(string queryName, object parameters, bool absoluteColumnNames)
        {
            return this.Dao.CustomSearchByParameters<T>(queryName, parameters, absoluteColumnNames);
        }

        #endregion Methods
    }
}
