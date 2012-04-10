
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class LoginAttemptParameters : BaseParameters
    {
        public Nullable<int> LoginAttemptId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }
}