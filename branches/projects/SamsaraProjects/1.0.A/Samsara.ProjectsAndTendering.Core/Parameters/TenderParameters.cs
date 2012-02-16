
using System;
using Samsara.Base.Core.Parameters;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class TenderParameters : GenericParameters
    {
        public Nullable<int> AsesorId
        {
            get;
            set;
        }

        public Nullable<int> OpportunityId
        {
            get;
            set;
        }

        public Nullable<int> BidderId
        {
            get;
            set;
        }

        public Nullable<int> DependencyId
        {
            get;
            set;
        }

        public Nullable<int> EndUserId
        {
            get;
            set;
        }

        public Nullable<int> TenderStatusId
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

        public Nullable<DateTime> MinDate
        {
            get;
            set;
        }

        public Nullable<DateTime> MaxDate
        {
            get;
            set;
        }
    }
}
