﻿using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface IDependencyService
    {
        Dictionary<int, Dependency> LoadDependencies();
        Dependency LoadDependency(int DependencyId);
        void SaveOrUpdateDependency(Dependency asesor);
        void DeleteDependency(Dependency asesor);
    }
}
