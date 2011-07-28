﻿
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class EndUserService : BaseService, IEndUserService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IEndUserDao EndUserDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DataTable SearchEndUsers(EndUserParameters pmtEndUser)
        {
            return this.EndUserDao.SearchEndUsers(pmtEndUser);
        }

        public Dictionary<int, EndUser> LoadEndUsers(EndUserParameters pmtEndUser)
        {
            return this.EndUserDao.LoadEndUsers(pmtEndUser);
        }

        public EndUser LoadEndUser(int EndUserId)
        {
            return this.EndUserDao.GetById(EndUserId);
        }

        public void SaveOrUpdateEndUser(EndUser entity)
        {
            if (entity.EndUserId < 0)
            {
                this.EndUserDao.Save(entity);
            }
            else
            {
                this.EndUserDao.Update(entity);
            }
        }

        public void DeleteEndUser(EndUser entity)
        {
            this.EndUserDao.Delete(entity);
        }

        #endregion Methods
    }
}