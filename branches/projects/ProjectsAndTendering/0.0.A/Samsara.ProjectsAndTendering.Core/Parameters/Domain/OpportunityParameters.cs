
using System;
using Samsara.ProjectsAndTendering.Core.Enums;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class OpportunityParameters : GenericParameters
    {
        public int? AsesorId
        {
            get;
            set;
        }

        public int? OrganizationId
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

        public int? OpportunityStatusId
        {
            get;
            set;
        }

        public int? OpportunityTypeId
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

        public bool? OnlyNotRelatedToTenders
        {
            get;
            set;
        }
    }
}
