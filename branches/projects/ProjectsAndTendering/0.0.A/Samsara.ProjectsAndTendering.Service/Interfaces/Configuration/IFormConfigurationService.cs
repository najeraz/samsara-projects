using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IFormConfigurationService
    {
        Dictionary<int, FormConfiguration> LoadFormConfigurations();
        FormConfiguration LoadFormConfiguration(int FormConfigurationId);
        void SaveOrUpdateFormConfiguration(FormConfiguration asesor);
        void DeleteFormConfiguration(FormConfiguration asesor);
    }
}
