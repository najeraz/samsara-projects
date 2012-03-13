
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class StaffParameters : BaseParameters
    {
        public StaffParameters()
        {
        }

        public Nullable<int> StaffId
        {
            get;
            set;
        }

        public string Names
        {
            get;
            set;
        }
    }
}