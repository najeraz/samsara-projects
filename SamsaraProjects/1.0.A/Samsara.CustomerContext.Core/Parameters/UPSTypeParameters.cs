
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class UPSTypeParameters : GenericParameters
    {
        public UPSTypeParameters()
        {
        }
        
        public Nullable<int> UPSTypeId
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