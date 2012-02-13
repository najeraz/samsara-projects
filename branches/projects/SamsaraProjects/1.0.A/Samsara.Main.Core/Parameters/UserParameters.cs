
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class UserParameters : GenericParameters
    {
        public UserParameters()
        {
        }

        public int? UserId
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

    }
}