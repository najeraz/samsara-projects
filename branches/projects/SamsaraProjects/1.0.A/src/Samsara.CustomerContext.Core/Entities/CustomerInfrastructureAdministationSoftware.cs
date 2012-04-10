
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureAdministationSoftware : BaseEntity
    {
        public CustomerInfrastructureAdministationSoftware()
        {
            CustomerInfrastructureAdministationSoftwareId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureAdministationSoftwareId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Modules
        {
            get;
            set;
        }

        public virtual DBMS DBMS
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer
        {
            get;
            set;
        }

        public virtual int NumberOfUsers
        {
            get;
            set;
        }
    }
}