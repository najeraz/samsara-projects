
using System;

namespace Samsara.Base.Core.Parameters
{
    public class BaseParameters
    {

        public Nullable<int> CreatedBy
        {
            get;
            set;
        }

        public Nullable<int> UpdatedBy
        {
            get;
            set;
        }

        public Nullable<DateTime> CreatedOn
        {
            get;
            set;
        }

        public Nullable<DateTime> UpdatedOn
        {
            get;
            set;
        }

    }
}
