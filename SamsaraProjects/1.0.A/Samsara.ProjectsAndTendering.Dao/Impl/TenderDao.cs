
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Base.Dao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class TenderDao : GenericDao<Tender, int, TenderParameters>, ITenderDao
    {
        #region Methods

        #region Public

        public override void Save(Tender entity)
        {
            base.Save(entity);
            this.SaveTenderFiles(entity);
        }

        public override void SaveOrUpdate(Tender entity)
        {
            base.SaveOrUpdate(entity);

            if (entity.Deleted)
                this.DeleteTenderFiles(entity);
            else
                this.SaveTenderFiles(entity);
        }

        public override void Update(Tender entity)
        {
            base.Update(entity);

            if (entity.Deleted)
                this.DeleteTenderFiles(entity);
            else
                this.SaveTenderFiles(entity);
        }

        #endregion Public
        
        #region Private

        private void DeleteTenderFiles(Tender entity)
        {
            //ITenderFileDao daoTenderFile = SamsaraAppContext.Resolve<ITenderFileDao>();
            //Assert.IsNotNull(daoTenderFile);
            
            //TenderFileParameters pmtTenderFile = new TenderFileParameters();
            //pmtTenderFile.TenderId = entity.TenderId;

            //foreach (TenderFile tenderFile in daoTenderFile.GetListByParameters(pmtTenderFile))
            //{
            //    daoTenderFile.Delete(tenderFile);
            //}
        }

        private void SaveTenderFiles(Tender entity)
        {
            TenderFileParameters pmtTenderFile = new TenderFileParameters();
            ITenderFileDao daoTenderFile = SamsaraAppContext.Resolve<ITenderFileDao>();
            Assert.IsNotNull(daoTenderFile);

            foreach (TenderFile tenderFile in entity.TenderFiles)
            {
                if (tenderFile.File != null)
                {
                    tenderFile.TenderFileId = -1;
                    daoTenderFile.SaveOrUpdate(tenderFile);
                }
            }

            pmtTenderFile.TenderId = entity.TenderId;
            IEnumerable<int> tenderFileIds = daoTenderFile.SearchByParameters(pmtTenderFile)
                .AsEnumerable().Select(x => Convert.ToInt32(x[0]));

            foreach (int tenderFileId in tenderFileIds.Where(x => !entity.TenderFiles
                .Select(y => y.TenderFileId).Contains(x)))
            {
                TenderFile tenderFile = new TenderFile();

                tenderFile.TenderFileId = tenderFileId;
                daoTenderFile.Delete(tenderFile);
            }
        }

        #endregion Private

        #endregion Methods
    }
}