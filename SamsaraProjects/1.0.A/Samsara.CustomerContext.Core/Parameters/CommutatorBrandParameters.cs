
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CommutatorBrandParameters : GenericParameters
    {
        public CommutatorBrandParameters()
        {
        }

        public int? CommutatorBrandId
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