
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public class FormConfigurationDao : GenericDao<FormConfiguration, int>, IFormConfigurationDao
    {
        #region Methods

        public Dictionary<int, FormConfiguration> LoadFormConfigurations()
        {
            return this.GetAll().ToDictionary(x => x.FormConfigurationId, x => x);
        }

        public FormConfiguration SearchFormConfigurationByName(string formName)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("SearchFormConfigurationByName");

            dnq.SetString("FormName", formName);

            return this.GetList(dnq).SingleOrDefault();
        }

        #endregion Methods
    }
}