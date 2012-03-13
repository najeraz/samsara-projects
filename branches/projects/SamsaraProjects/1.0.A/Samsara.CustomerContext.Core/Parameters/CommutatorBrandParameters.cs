﻿
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CommutatorBrandParameters : BaseParameters
    {
        public CommutatorBrandParameters()
        {
        }

        public Nullable<int> CommutatorBrandId
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