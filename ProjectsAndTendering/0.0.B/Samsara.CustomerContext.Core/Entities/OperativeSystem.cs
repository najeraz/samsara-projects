﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class OperativeSystem : GenericEntity
    {
        public OperativeSystem()
        {
            OperativeSystemId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int OperativeSystemId
        {
            get;
            set;
        }

        public virtual OperativeSystemType OperativeSystemType
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual bool IsLegit
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