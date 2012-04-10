
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePersonalComputerParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructurePersonalComputerId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public string ManufacturerReferenceNumber
        {
            get;
            set;
        }

        public string CPU
        {
            get;
            set;
        }

        public string RAM
        {
            get;
            set;
        }

        public string StorageSystem
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public Nullable<int> PersonalComputerTypeId
        {
            get;
            set;
        }

        public Nullable<int> ComputerBrandId
        {
            get;
            set;
        }

        public Nullable<int> OperativeSystemId
        {
            get;
            set;
        }
    }
}