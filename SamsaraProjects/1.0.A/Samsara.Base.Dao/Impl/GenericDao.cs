
using Samsara.Base.Dao.Interfaces;

namespace Samsara.Base.Dao.Impl
{
    public class GenericDao<T, TId, Tpmt> : GenericReadOnlyDao<T, TId, Tpmt>, IGenericDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual void SaveOrUpdate(T entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(T entity)
        {
            HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            HibernateTemplate.Delete(entity);
        }
        
        #endregion Public

        #endregion Methods
    }
}