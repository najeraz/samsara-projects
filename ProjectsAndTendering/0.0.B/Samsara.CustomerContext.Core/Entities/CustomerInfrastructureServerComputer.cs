
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureServerComputer : GenericEntity
    {
        private ISet<DBMS> dBMSs;

        public CustomerInfrastructureServerComputer()
        {
            CustomerInfrastructureServerComputerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureServerComputerId
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

        public virtual string ServerModel
        {
            get;
            set;
        }

        public virtual OperativeSystem OperativeSystem
        {
            get;
            set;
        }

        public virtual ISet<DBMS> DBMSs
        {
            get
            {
                if (this.dBMSs == null)
                    this.dBMSs = new HashedSet<DBMS>();

                return this.dBMSs;
            }
            set
            {
                this.dBMSs = value;
            }
        }
    }
}