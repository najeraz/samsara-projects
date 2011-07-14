using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface IAsesorService
    {
        Dictionary<int, Asesor> LoadAsesors();
        Asesor LoadAsesor(int AsesorId);
        void SaveOrUpdateAsesor(Asesor asesor);
        void DeleteAsesor(Asesor asesor);
    }
}
