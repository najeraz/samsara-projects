using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IAsesorService : IGenericService<Asesor, int>
    {
        DataTable SearchAsesors(AsesorParameters pmtAsesor);
        Dictionary<int, Asesor> LoadAsesors();
    }
}
