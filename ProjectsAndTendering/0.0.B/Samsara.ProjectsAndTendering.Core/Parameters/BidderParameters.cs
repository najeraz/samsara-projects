
using Samsara.BaseCore.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class BidderParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public int? BidderTypeId
        {
            get;
            set;
        }
    }
}
