
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class BeneficiaryDao : GenericDao<Beneficiary, int>, IBeneficiaryDao
    {
        #region Methods

        public Dictionary<int, Beneficiary> LoadBeneficiaries()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadBeneficiaries");

            return this.GetList(dnq).ToDictionary(x => x.BeneficiaryId, x => x);
        }

        #endregion Methods
    }
}