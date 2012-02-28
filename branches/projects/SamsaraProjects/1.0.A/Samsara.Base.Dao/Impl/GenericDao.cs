
using System;
using System.ComponentModel;
using Samsara.Base.Core.Entities;
using Samsara.Base.Dao.Interfaces;
using Samsara.Support.Util;
using Samsara.Base.Core.Interfaces;
using Samsara.Base.Core.Context;
using NUnit.Framework;

namespace Samsara.Base.Dao.Impl
{
    public class GenericDao<T, TId, Tpmt> : GenericReadOnlyDao<T, TId, Tpmt>, IGenericDao<T, TId, Tpmt>
    {
        #region Methods

        #region Public

        public virtual void SaveOrUpdate(T entity)
        {
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public virtual void Save(T entity)
        {
            this.ProcessAuditProperties(entity);

            this.HibernateTemplate.Save(entity);
        }

        public void Refresh(T entity)
        {
            this.HibernateTemplate.Refresh(entity);
        }

        public virtual void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity.GetType().IsSubclassOf(typeof(GenericEntity)))
            {
                (entity as GenericEntity).Deleted = true;
                (entity as GenericEntity).Activated = false;

                this.ProcessAuditProperties(entity);
                
                this.HibernateTemplate.Update(entity);
            }
            else
            {
                this.HibernateTemplate.Delete(entity);
            }
        }
        
        #endregion Public

        #region Private

        private void ProcessAuditProperties(object entity)
        {
            Type entityType = entity.GetType();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            int primaryKeyValue = Convert.ToInt32(EntitiesUtil.GetPrimaryKeyPropertyValue(entityType, entity));

            if (entity.GetType().IsSubclassOf(typeof(GenericEntity)))
            {
                ISession session = SamsaraAppContext.Resolve<ISession>();
                Assert.IsNotNull(session);

                if (primaryKeyValue <= 0)
                {
                    if ((entity as GenericEntity).Activated == null)
                    {
                        (entity as GenericEntity).Activated = true;
                    }
                    if ((entity as GenericEntity).Deleted == null)
                    {
                        (entity as GenericEntity).Deleted = false;
                    }
                    (entity as GenericEntity).CreatedBy = session.UserId;
                    (entity as GenericEntity).UpdatedOn = this.GetServerDateTime();
                }
                else
                {
                    (entity as GenericEntity).UpdatedBy = session.UserId;
                    (entity as GenericEntity).CreatedOn = this.GetServerDateTime();
                }
            }

            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                object value = entity.GetType().GetProperty(propertyDescriptor.Name).GetValue(entity, null);

                if (value.GetType().IsSubclassOf(typeof(GenericEntity)))
                {
                    this.ProcessAuditProperties(value);
                }
            }
        }

        #endregion Private

        #endregion Methods
    }
}