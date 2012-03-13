﻿
using Samsara.Base.Core.Entities;
using Samsara.Base.Dao.Interfaces;
using Samsara.Support.Util;

namespace Samsara.Base.Dao.Impl
{
    public class BaseDao<T, TId, Tpmt> : BaseReadOnlyDao<T, TId, Tpmt>, IBaseDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual void SaveOrUpdate(T entity)
        {
            this.CloseReadingSession();
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(T entity)
        {
            this.CloseReadingSession();
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
            this.HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            this.HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(T entity)
        {
            this.CloseReadingSession();
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
            this.HibernateTemplate.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.CloseReadingSession();
            if (entity.GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                (entity as BaseEntity).Deleted = true;
                (entity as BaseEntity).Activated = false;

                EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
                this.HibernateTemplate.Update(entity);
            }
            else
            {
                this.HibernateTemplate.Delete(entity);
            }
        }

        #endregion Public

        #region Private

        private void CloseReadingSession()
        {
            if (this.ReadingSession.IsOpen)
            {
                this.ReadingSession.Close();
            }
        }

        #endregion Private

        #endregion Methods
    }
}