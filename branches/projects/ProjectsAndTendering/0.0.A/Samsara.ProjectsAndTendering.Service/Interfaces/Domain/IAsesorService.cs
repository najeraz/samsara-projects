using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IAsesorService
    {
        Dictionary<int, Asesor> LoadAsesors();
        Asesor LoadAsesor(int AsesorId);
        void SaveOrUpdateAsesor(Asesor entity);
        void DeleteAsesor(Asesor entity);
    }
}
