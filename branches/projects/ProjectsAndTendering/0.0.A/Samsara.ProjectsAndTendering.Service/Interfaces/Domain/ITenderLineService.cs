using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderLineService
    {
        Dictionary<int, TenderLine> LoadTenderLines();
        TenderLine LoadTenderLine(int TenderLineId);
        void SaveOrUpdateTenderLine(TenderLine entity);
        void DeleteTenderLine(TenderLine entity);
    }
}
