
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.BaseService.Impl
{
    public class GenericService<T, TId, TDao> : IGenericService<T, TId> where TDao : IGenericDao<T, TId>
    {
        protected TDao Dao
        {
            get;
            set;
        }

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

        public T GetByParameters(GenericParameters parameters)
        {
            return Dao.GetByParameters(parameters);
        }

        public DataTable SearchByParameters(GenericParameters parameters)
        {
            return this.Dao.SearchByParameters(parameters);
        }

        public IList<T> GetListByParameters(GenericParameters parameters)
        {
            return this.Dao.GetListByParameters(parameters);
        }
    }
}
