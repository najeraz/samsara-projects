
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class UserPermissionParameters : GenericParameters
    {
        public UserPermissionParameters()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public Nullable<int> FormId
        {
            get;
            set;
        }

        public Nullable<int> UserId
        {
            get;
            set;
        }

    }
}