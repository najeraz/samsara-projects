
using System.Collections.Generic;
using System.Linq;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.Base.Dao.Impl;

namespace Samsara.AlleatoERP.Dao.Impl
{
    public class StaffDao : GenericReadOnlyDao<Staff, int, StaffParameters>, IStaffDao
    {
        public override IList<Staff> GetListByParameters(StaffParameters parameters)
        {
            IList<Staff> lstResult = new List<Staff>();

            foreach (Staff staff in base.GetListByParameters(parameters))
            {
                staff.Names = staff.Names.Trim();
                staff.Lastname = staff.Lastname.Trim();
                lstResult.Add(staff);
            }

            return lstResult;
        }
    }
}