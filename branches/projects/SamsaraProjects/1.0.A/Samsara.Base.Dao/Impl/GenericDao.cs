
using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Context;
using Samsara.Base.Core.Entities;
using Samsara.Base.Core.Interfaces;
using Samsara.Base.Dao.Interfaces;
using Samsara.Support.Util;
using System.Collections.Generic;

namespace Samsara.Base.Dao.Impl
{
    public class GenericDao<T, TId, Tpmt> : GenericReadOnlyDao<T, TId, Tpmt>, IGenericDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual void SaveOrUpdate(T entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());

            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(T entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());

            this.HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            this.HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(T entity)
        {
            EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
            this.HibernateTemplate.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity.GetType().IsSubclassOf(typeof(GenericEntity)))
            {
                (entity as GenericEntity).Deleted = true;
                (entity as GenericEntity).Activated = false;

                EntitiesUtil.ProcessAuditProperties(entity, this.GetServerDateTime());
                
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