﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductFamily : BaseEntity
    {
        public ProductFamily()
        {
            ProductFamilyId = -1;
        }

        [PrimaryKey]
        public virtual int ProductFamilyId
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
    }
}