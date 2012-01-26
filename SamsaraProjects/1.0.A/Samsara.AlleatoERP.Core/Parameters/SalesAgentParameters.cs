
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class SalesAgentParameters : GenericParameters
    {
        public SalesAgentParameters()
        {
        }

        public int? SalesAgentId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}