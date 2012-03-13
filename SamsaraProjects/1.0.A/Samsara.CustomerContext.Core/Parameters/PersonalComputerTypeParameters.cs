
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class PersonalComputerTypeParameters : BaseParameters
    {
        public PersonalComputerTypeParameters()
        {
        }

        public Nullable<int> PersonalComputerTypeId
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