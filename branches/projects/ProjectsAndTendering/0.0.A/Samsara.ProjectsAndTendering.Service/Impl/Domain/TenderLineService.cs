
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderLineService : GenericService<TenderLine, int, ITenderLineDao>, ITenderLineService
    {
        #region Methods

        public Dictionary<int, TenderLine> LoadTenderLines()
        {
            return this.Dao.LoadTenderLines();
        }

        #endregion Methods
    }
}