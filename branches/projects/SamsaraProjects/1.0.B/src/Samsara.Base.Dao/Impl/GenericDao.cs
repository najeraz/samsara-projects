
using Samsara.Base.Core.Entities;
using Samsara.Base.Dao.Interfaces;
using Samsara.Framework.Util;

namespace Samsara.Base.Dao.Impl
{
    public class GenericDao : GenericReadOnlyDao, IGenericDao
    {
        #region Methods

        #region Public

        public virtual void SaveOrUpdate(object entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime(), null, this.Session);
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(object entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime(), null, this.Session);
            this.HibernateTemplate.Save(entity);
        }

        public void Refresh(object entity)
        {
            this.HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(object entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime(), null, this.Session);
            this.HibernateTemplate.Update(entity);
        }

        public virtual void Delete(object entity)
        {
            if (entity.GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                (entity as BaseEntity).Deleted = true;
                (entity as BaseEntity).Activated = false;

                EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime(), null, this.Session);
                this.HibernateTemplate.Update(entity);
            }
            else
            {
                this.HibernateTemplate.Delete(entity);
            }
        }

        #endregion Public

        #endregion Methods
    }
}