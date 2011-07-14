﻿using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using System.Data;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface ITenderDao : IGenericDao<Tender,int>
    {
        Dictionary<int, Tender> LoadTenders();
        DataTable SearchTenders(TenderSearchParameters pmtTenderSearch);
    }
}
