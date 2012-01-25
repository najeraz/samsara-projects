
using Samsara.Base.Core.Parameters;
using System;

namespace Samsara.Dashboard.Core.Parameters
{
    public class HorizontalIntegrationReportParameters : GenericParameters
    {
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

        public string Agents
        {
            get;
            set;
        }
    }
}
