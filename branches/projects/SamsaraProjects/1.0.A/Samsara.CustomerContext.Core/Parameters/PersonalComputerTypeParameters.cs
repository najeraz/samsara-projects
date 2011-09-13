
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class PersonalComputerTypeParameters : GenericParameters
    {
        public PersonalComputerTypeParameters()
        {
        }

        public int? PersonalComputerTypeId
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