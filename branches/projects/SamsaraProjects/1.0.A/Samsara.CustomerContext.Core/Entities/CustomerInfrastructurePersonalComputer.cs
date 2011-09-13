
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePersonalComputer : GenericEntity
    {
        public CustomerInfrastructurePersonalComputer()
        {
            CustomerInfrastructurePersonalComputerId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructurePersonalComputerId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual string SerialNumber
        {
            get;
            set;
        }

        public virtual string ManufacturerReferenceNumber
        {
            get;
            set;
        }

        public virtual string CPU
        {
            get;
            set;
        }

        public virtual string RAM
        {
            get;
            set;
        }

        public virtual string StorageSystem
        {
            get;
            set;
        }

        public virtual string Model
        {
            get;
            set;
        }

        public virtual PersonalComputerType PersonalComputerType
        {
            get;
            set;
        }

        public virtual ComputerBrand ComputerBrand
        {
            get;
            set;
        }

        public virtual OperativeSystem OperativeSystem
        {
            get;
            set;
        }
    }
}