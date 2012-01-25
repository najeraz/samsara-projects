
using System;
using Samsara.Base.Core.Parameters;

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
