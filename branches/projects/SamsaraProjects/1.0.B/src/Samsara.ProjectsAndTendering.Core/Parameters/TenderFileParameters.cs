
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class TenderFileParameters : BaseParameters
    {
        public Nullable<int> TenderId
        {
            get;
            set;
        }

        public Nullable<int> TenderFileId
        {
            get;
            set;
        }
    }
}
