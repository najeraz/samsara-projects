
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class OperativeSystemParameters : GenericParameters
    {
        public OperativeSystemParameters()
        {
        }

        public Nullable<int> OperativeSystemId
        {
            get;
            set;
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

        public bool? IsLegit
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