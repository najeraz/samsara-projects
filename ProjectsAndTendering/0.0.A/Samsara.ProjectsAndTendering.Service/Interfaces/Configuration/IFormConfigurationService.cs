using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IFormConfigurationService
    {
        Dictionary<int, FormConfiguration> LoadFormConfigurations();
        FormConfiguration LoadFormConfiguration(int FormConfigurationId);
        void SaveOrUpdateFormConfiguration(FormConfiguration formConfiguration);
        void DeleteFormConfiguration(FormConfiguration formConfiguration);
        FormConfiguration SearchFormConfigurationByName(string formName);
    }
}
