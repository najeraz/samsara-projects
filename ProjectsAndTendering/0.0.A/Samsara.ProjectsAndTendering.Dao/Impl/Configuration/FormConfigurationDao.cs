
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public class FormConfigurationDao : GenericDao<FormConfiguration, int>, IFormConfigurationDao
    {
        #region Methods

        public Dictionary<int, FormConfiguration> LoadFormConfigurations()
        {
            return this.GetAll().ToDictionary(x => x.FormConfigurationId, x => x);
        }

        public FormConfiguration SearchFormConfigurations(string formName)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("SearchFormConfigurations");

            dnq.SetString("FormName", formName);

            return this.GetList(dnq).SingleOrDefault();
        }

        #endregion Methods
    }
}