
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class StaffParameters : GenericParameters
    {
        public StaffParameters()
        {
        }

        public int? StaffId
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