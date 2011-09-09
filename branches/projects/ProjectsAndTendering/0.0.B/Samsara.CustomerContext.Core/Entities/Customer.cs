
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.CustomerContext.Core.Entities
{
    public class Customer : GenericEntity
    {
        private ISet<CustomerPersonalComputer> customerPersonalComputers;
        private ISet<CustomerServerComputer> customerServerComputers;
        private ISet<CustomerUPS> customerUPSs;
        private ISet<CustomerPrinter> customerPrinters;
        private ISet<CustomerTelephony> customerTelephonies;
        private ISet<CustomerCCTV> customerCCTVs;

        public Customer()
        {
            CustomerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerId
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

        public virtual CustomerNetwork CustomerNetwork
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

        public virtual ISet<CustomerPersonalComputer> CustomerPersonalComputers
        {
            get
            {
                if (this.customerPersonalComputers == null)
                    this.customerPersonalComputers = new HashedSet<CustomerPersonalComputer>();

                return this.customerPersonalComputers;
            }
            set
            {
                this.customerPersonalComputers = value;
            }
        }

        public virtual ISet<CustomerServerComputer> CustomerServerComputers
        {
            get
            {
                if (this.customerServerComputers == null)
                    this.customerServerComputers = new HashedSet<CustomerServerComputer>();

                return this.customerServerComputers;
            }
            set
            {
                this.customerServerComputers = value;
            }
        }

        public virtual ISet<CustomerUPS> CustomerUPSs
        {
            get
            {
                if (this.customerUPSs == null)
                    this.customerUPSs = new HashedSet<CustomerUPS>();

                return this.customerUPSs;
            }
            set
            {
                this.customerUPSs = value;
            }
        }

        public virtual ISet<CustomerPrinter> CustomerPrinters
        {
            get
            {
                if (this.customerPrinters == null)
                    this.customerPrinters = new HashedSet<CustomerPrinter>();

                return this.customerPrinters;
            }
            set
            {
                this.customerPrinters = value;
            }
        }

        public virtual ISet<CustomerTelephony> CustomerTelephonies
        {
            get
            {
                if (this.customerTelephonies == null)
                    this.customerTelephonies = new HashedSet<CustomerTelephony>();

                return this.customerTelephonies;
            }
            set
            {
                this.customerTelephonies = value;
            }
        }

        public virtual ISet<CustomerCCTV> CustomerCCTVs
        {
            get
            {
                if (this.customerCCTVs == null)
                    this.customerCCTVs = new HashedSet<CustomerCCTV>();

                return this.customerCCTVs;
            }
            set
            {
                this.customerCCTVs = value;
            }
        }
    }
}