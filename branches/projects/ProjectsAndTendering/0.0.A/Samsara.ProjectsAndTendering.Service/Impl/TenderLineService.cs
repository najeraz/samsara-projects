﻿
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class TenderLineService : BaseService, ITenderLineService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public ITenderLineDao TenderLineDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, TenderLine> LoadTenderLines()
        {
            return this.TenderLineDao.LoadTenderLines();
        }

        public TenderLine LoadTenderLine(int TenderLineId)
        {
            return this.TenderLineDao.GetById(TenderLineId);
        }

        public void SaveOrUpdateTenderLine(TenderLine asesor)
        {
            if (asesor.TenderLineId > 0)
            {
                this.TenderLineDao.Save(asesor);
            }
            else
            {
                this.TenderLineDao.Update(asesor);
            }
        }

        public void DeleteTenderLine(TenderLine asesor)
        {
            this.TenderLineDao.Delete(asesor);
        }

        #endregion Methods
    }
}