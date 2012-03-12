
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class BidderParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public Nullable<int> BidderTypeId
        {
            get;
            set;
        }

        public Nullable<int> BidderId
        {
            get;
            set;
        }
    }
}
