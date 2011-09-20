
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureSecuritySoftware : GenericEntity
    {
        public CustomerInfrastructureSecuritySoftware()
        {
            CustomerInfrastructureSecuritySoftwareId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureSecuritySoftwareId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual SecuritySoftwareBrand SecuritySoftwareBrand
        {
            get;
            set;
        }

        public virtual SecuritySoftwareType SecuritySoftwareType
        {
            get;
            set;
        }

        public virtual bool ConsoleInstalled
        {
            get;
            set;
        }

        public virtual int NumberOfClients
        {
            get;
            set;
        }
    }
}