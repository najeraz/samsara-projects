﻿
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CommutatorTypeParameters : GenericParameters
    {
        public CommutatorTypeParameters()
        {
        }

        public Nullable<int> CommutatorTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}