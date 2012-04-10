
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Configuration.Core.Parameters
{
    public class FormConfigurationUserPermissionParameters : BaseParameters
    {
        public FormConfigurationUserPermissionParameters()
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