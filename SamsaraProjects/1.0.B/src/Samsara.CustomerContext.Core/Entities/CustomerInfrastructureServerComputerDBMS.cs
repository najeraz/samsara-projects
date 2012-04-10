
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureServerComputerDBMS : BaseEntity
    {
        public CustomerInfrastructureServerComputerDBMS()
        {
            CustomerInfrastructureServerComputerDBMSId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureServerComputerDBMSId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer
        {
            get;
            set;
        }

        public virtual DBMS DBMS
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}