﻿
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Interfaces;

namespace Samsara.Base.Service.Impl
{
    public class GenericService<T, TId, TDao, Tpmt> : GenericReadOnlyService<T, TId, TDao, Tpmt>, 
        IGenericService<T, TId, Tpmt> where TDao : IGenericDao<T, TId, Tpmt>
    {
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

        #endregion Methods
    }
}
