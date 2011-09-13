
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class WifiBrandParameters : GenericParameters
    {
        public WifiBrandParameters()
        {
        }

        public int? WifiBrandId
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