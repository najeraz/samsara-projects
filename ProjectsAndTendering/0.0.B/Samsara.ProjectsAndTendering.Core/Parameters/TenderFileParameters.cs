
using Samsara.BaseCore.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class TenderFileParameters : GenericParameters
    {
        public int? TenderId
        {
            get;
            set;
        }

        public int? TenderFileId
        {
            get;
            set;
        }
    }
}
