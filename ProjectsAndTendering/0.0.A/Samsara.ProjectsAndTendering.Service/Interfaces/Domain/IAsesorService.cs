using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IAsesorService
    {
        DataTable SearchAsesors(AsesorParameters pmtAsesor);
        Dictionary<int, Asesor> LoadAsesors();
        Asesor LoadAsesor(int AsesorId);
        void SaveOrUpdateAsesor(Asesor entity);
        void DeleteAsesor(Asesor entity);
    }
}
