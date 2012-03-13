
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class OperativeSystemTypeParameters : BaseParameters
    {
        public OperativeSystemTypeParameters()
        {
        }

        public Nullable<int> OperativeSystemTypeId
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