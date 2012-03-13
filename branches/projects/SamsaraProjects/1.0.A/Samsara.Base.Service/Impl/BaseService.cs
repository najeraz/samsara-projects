
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Interfaces;

namespace Samsara.Base.Service.Impl
{
    public class BaseService<T, TId, TDao, Tpmt> : BaseReadOnlyService<T, TId, TDao, Tpmt>, 
        IGenericService<T, TId, Tpmt> where TDao : IBaseDao<T, TId, Tpmt>
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
