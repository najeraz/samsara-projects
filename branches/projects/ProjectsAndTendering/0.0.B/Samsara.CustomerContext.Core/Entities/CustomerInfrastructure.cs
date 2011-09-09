
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructure : GenericEntity
    {
        private ISet<CustomerInfrastructurePersonalComputer> customerInfrastructurePersonalComputers;
        private ISet<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers;
        private ISet<CustomerInfrastructureUPS> customerInfrastructureUPSs;
        private ISet<CustomerInfrastructurePrinter> customerInfrastructurePrinters;
        private ISet<CustomerInfrastructureTelephony> customerTelephonies;
        private ISet<CustomerInfrastructureCCTV> customerInfrastructureCCTVs;

        public CustomerInfrastructure()
        {
            CustomerInfrastructureId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string BusinessType
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual string GroundedOutlet
        {
            get;
            set;
        }

        public virtual string TrainingAndCourses
        {
            get;
            set;
        }

        public virtual ISet<CustomerInfrastructurePersonalComputer> customerInfrastructurePersonalComputers
        {
            get
            {
                if (this.customerInfrastructurePersonalComputers == null)
                    this.customerInfrastructurePersonalComputers = new HashedSet<CustomerInfrastructurePersonalComputer>();

                return this.customerInfrastructurePersonalComputers;
            }
            set
            {
                this.customerInfrastructurePersonalComputers = value;
            }
        }

        public virtual ISet<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
        {
            get
            {
                if (this.customerInfrastructureServerComputers == null)
                    this.customerInfrastructureServerComputers = new HashedSet<CustomerInfrastructureServerComputer>();

                return this.customerInfrastructureServerComputers;
            }
            set
            {
                this.customerInfrastructureServerComputers = value;
            }
        }

        public virtual ISet<CustomerInfrastructureUPS> customerInfrastructureUPSs
        {
            get
            {
                if (this.customerInfrastructureUPSs == null)
                    this.customerInfrastructureUPSs = new HashedSet<CustomerInfrastructureUPS>();

                return this.customerInfrastructureUPSs;
            }
            set
            {
                this.customerInfrastructureUPSs = value;
            }
        }

        public virtual ISet<CustomerInfrastructurePrinter> customerInfrastructurePrinters
        {
            get
            {
                if (this.customerInfrastructurePrinters == null)
                    this.customerInfrastructurePrinters = new HashedSet<CustomerInfrastructurePrinter>();

                return this.customerInfrastructurePrinters;
            }
            set
            {
                this.customerInfrastructurePrinters = value;
            }
        }

        public virtual ISet<CustomerInfrastructureTelephony> customerTelephonies
        {
            get
            {
                if (this.customerTelephonies == null)
                    this.customerTelephonies = new HashedSet<CustomerInfrastructureTelephony>();

                return this.customerTelephonies;
            }
            set
            {
                this.customerTelephonies = value;
            }
        }

        public virtual ISet<CustomerInfrastructureCCTV> customerInfrastructureCCTVs
        {
            get
            {
                if (this.customerInfrastructureCCTVs == null)
                    this.customerInfrastructureCCTVs = new HashedSet<CustomerInfrastructureCCTV>();

                return this.customerInfrastructureCCTVs;
            }
            set
            {
                this.customerInfrastructureCCTVs = value;
            }
        }
    }
}