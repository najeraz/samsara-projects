
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class UserGroupParameters : GenericParameters
    {
        public UserGroupParameters()
        {
        }

        public int? UserGroupId
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