using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class SearchTenderLinesParameters : GenericParameters
    {
        public int? TenderId
        {
            get;
            set;
        }
    }
}
