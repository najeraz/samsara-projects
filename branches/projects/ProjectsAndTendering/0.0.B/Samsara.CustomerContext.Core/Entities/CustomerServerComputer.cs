
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerServerComputer : GenericEntity
    {
        public CustomerServerComputer()
        {
            CustomerServerComputerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerServerComputerId
        {
            get;
            set;
        }

        public virtual Customer Customer
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

        public virtual string Utilization
        {
            get;
            set;
        }

        public virtual string Scalability
        {
            get;
            set;
        }

        public virtual ComputerBrand ComputerBrand
        {
            get;
            set;
        }

        public virtual ServerModel ServerModel
        {
            get;
            set;
        }

        public virtual OperativeSystem OperativeSystem
        {
            get;
            set;
        }

        public virtual DBMS DBMS
        {
            get;
            set;
        }
    }
}