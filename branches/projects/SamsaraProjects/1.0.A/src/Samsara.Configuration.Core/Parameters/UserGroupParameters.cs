
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Configuration.Core.Parameters
{
    public class UserGroupParameters : BaseParameters
    {
        public UserGroupParameters()
        {
        }

        public Nullable<int> UserGroupId
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