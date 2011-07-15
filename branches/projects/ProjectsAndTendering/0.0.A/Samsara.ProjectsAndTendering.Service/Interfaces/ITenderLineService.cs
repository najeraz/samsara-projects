using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface ITenderLineService
    {
        Dictionary<int, TenderLine> LoadTenderLines();
        TenderLine LoadTenderLine(int TenderLineId);
        void SaveOrUpdateTenderLine(TenderLine asesor);
        void DeleteTenderLine(TenderLine asesor);
    }
}
