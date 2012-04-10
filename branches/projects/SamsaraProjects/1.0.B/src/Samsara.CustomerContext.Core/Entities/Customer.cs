﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CustomerId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerId
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

        public virtual BusinessType BusinessType
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