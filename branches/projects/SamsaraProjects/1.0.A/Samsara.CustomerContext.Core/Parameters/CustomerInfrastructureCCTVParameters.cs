
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureCCTVParameters : BaseParameters
    {
        public CustomerInfrastructureCCTVParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureCCTVId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> CCTVTypeId
        {
            get;
            set;
        }

        public Nullable<int> CCTVBrandId
        {
            get;
            set;
        }

        public string Utilization
        {
            get;
            set;
        }
    }
}