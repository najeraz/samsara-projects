
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Impl.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Configuration
{
    public class FormConfigurationService : BaseService, IFormConfigurationService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IFormConfigurationDao FormConfigurationDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, FormConfiguration> LoadFormConfigurations()
        {
            return this.FormConfigurationDao.LoadFormConfigurations();
        }

        public FormConfiguration LoadFormConfiguration(int FormConfigurationId)
        {
            return this.FormConfigurationDao.GetById(FormConfigurationId);
        }

        public void SaveOrUpdateFormConfiguration(FormConfiguration entity)
        {
            if (entity.FormConfigurationId > 0)
            {
                this.FormConfigurationDao.Save(entity);
            }
            else
            {
                this.FormConfigurationDao.Update(entity);
            }
        }

        public void DeleteFormConfiguration(FormConfiguration entity)
        {
            this.FormConfigurationDao.Delete(entity);
        }

        public FormConfiguration SearchFormConfigurationByName(string formName)
        {
            return this.FormConfigurationDao.SearchFormConfigurationByName(formName);
        }

        #endregion Methods
    }
}