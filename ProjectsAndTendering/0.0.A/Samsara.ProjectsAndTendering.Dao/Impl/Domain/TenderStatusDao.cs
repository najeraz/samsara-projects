﻿
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class TenderStatusDao : GenericDao<TenderStatus, int>, ITenderStatusDao
    {
        #region Methods

        public Dictionary<int, TenderStatus> LoadTenderStatuses()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadTenderStatuses");

            return this.GetList(dnq).ToDictionary(x => x.TenderStatusId, x => x);
        }

        #endregion Methods
    }
}