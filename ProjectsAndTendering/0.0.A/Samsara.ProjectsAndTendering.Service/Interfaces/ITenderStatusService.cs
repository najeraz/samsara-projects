﻿
using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface ITenderStatusService
    {
        Dictionary<int, TenderStatus> LoadTenderStatuses();
        TenderStatus LoadTenderStatus(int TenderStatusId);
        void SaveOrUpdateTenderStatus(TenderStatus asesor);
        void DeleteTenderStatus(TenderStatus asesor);
    }
}
