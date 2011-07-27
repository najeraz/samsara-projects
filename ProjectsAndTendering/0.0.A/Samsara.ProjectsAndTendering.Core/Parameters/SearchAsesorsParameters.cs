using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class SearchAsesorsParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public bool? ShowApprovers
        {
            get;
            set;
        }

        public bool? ShowAll
        {
            get;
            set;
        }
    }
}
