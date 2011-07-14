﻿
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using System.Collections.Generic;
using System.Linq;
using uNhAddIns.NH.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class TenderLineDao : GenericDao<TenderLine, int>, ITenderLineDao
    {
        #region Methods

        public Dictionary<int, TenderLine> LoadTenderLines()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadTenderLines");

            return this.GetList(dnq).ToDictionary(x => x.TenderLineId, x => x);
        }

        #endregion Methods
    }
}