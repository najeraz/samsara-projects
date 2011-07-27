﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class SearchDependenciesParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public int BidderId
        {
            get;
            set;
        }
    }
}
