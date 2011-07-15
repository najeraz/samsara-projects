
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
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

        public void SaveOrUpdateFormConfiguration(FormConfiguration asesor)
        {
            if (asesor.FormConfigurationId > 0)
            {
                this.FormConfigurationDao.Save(asesor);
            }
            else
            {
                this.FormConfigurationDao.Update(asesor);
            }
        }

        public void DeleteFormConfiguration(FormConfiguration asesor)
        {
            this.FormConfigurationDao.Delete(asesor);
        }

        #endregion Methods
    }
}