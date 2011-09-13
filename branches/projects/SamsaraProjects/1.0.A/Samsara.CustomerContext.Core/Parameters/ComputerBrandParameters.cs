
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class ComputerBrandParameters : GenericParameters
    {
        public ComputerBrandParameters()
        {
        }

        public int? ComputerBrandId
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