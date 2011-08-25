
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderService : GenericService<Tender, int, ITenderDao, TenderParameters>, ITenderService
    {
        public override void Save(Tender entity)
        {
            base.Save(entity);
            this.SaveTenderFiles(entity);
        }

        public override void SaveOrUpdate(Tender entity)
        {
            base.SaveOrUpdate(entity);
            this.SaveTenderFiles(entity);
        }
        
        private void SaveTenderFiles(Tender entity)
        {
            TenderFileParameters pmtTenderFile = new TenderFileParameters();
            ITenderFileService srvTenderFile = SamsaraAppContext.Resolve<ITenderFileService>();
            Assert.IsNotNull(srvTenderFile);

            foreach (TenderFile tenderFile in entity.TenderFiles)
            {
                if (tenderFile.File != null)
                {
                    tenderFile.TenderFileId = -1;
                    srvTenderFile.SaveOrUpdate(tenderFile);
                }
            }

            pmtTenderFile.TenderId = entity.TenderId;
            IEnumerable<int> tenderFileIds = srvTenderFile.SearchByParameters(pmtTenderFile)
                .AsEnumerable().Select(x => Convert.ToInt32(x[0]));

            foreach (int tenderFileId in tenderFileIds.Where(x => !entity.TenderFiles
                .Select(y => y.TenderFileId).Contains(x)))
            {
                TenderFile tenderFile = new TenderFile();

                tenderFile.TenderFileId = tenderFileId;
                srvTenderFile.Delete(tenderFile);
            }
        }
    }
}