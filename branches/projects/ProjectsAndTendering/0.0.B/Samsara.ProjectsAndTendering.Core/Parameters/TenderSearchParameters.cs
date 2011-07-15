using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class TenderSearchParameters
    {
        public int? AsesorId
        {
            get;
            set;
        }

        public int? BidderId
        {
            get;
            set;
        }

        public int? DependencyId
        {
            get;
            set;
        }

        public int? TenderStatusId
        {
            get;
            set;
        }

        public DateTypeSearchEnum? DateTypeSearchId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime? MinDate
        {
            get;
            set;
        }

        public DateTime? MaxDate
        {
            get;
            set;
        }
    }
}
