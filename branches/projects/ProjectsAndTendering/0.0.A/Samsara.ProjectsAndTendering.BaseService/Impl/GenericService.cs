
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;

namespace Samsara.ProjectsAndTendering.BaseService.Impl
{
    public class GenericService<T, TId, TDao, Tpmt> : IGenericService<T, TId, Tpmt> where TDao : IGenericDao<T, TId, Tpmt>
    {
        #region Properties

        protected TDao Dao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public virtual void Save(T entity)
        {
            this.Dao.Save(entity);
        }

        public virtual void SaveOrUpdate(T entity)
        {
            this.Dao.SaveOrUpdate(entity);
        }

        public virtual void Update(T entity)
        {
            this.Dao.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.Dao.Delete(entity);
        }

        public virtual void Refresh(T entity)
        {
            this.Dao.Refresh(entity);
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
