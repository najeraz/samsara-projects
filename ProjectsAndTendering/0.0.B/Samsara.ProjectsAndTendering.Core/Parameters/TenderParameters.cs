
using System;
using Samsara.Base.Core.Parameters;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class TenderParameters : GenericParameters
    {
        public int? AsesorId
        {
            get;
            set;
        }

        public int? OpportunityId
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

        public int? EndUserId
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
