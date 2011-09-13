﻿
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class DBMSParameters : GenericParameters
    {
        public DBMSParameters()
        {
        }

        public int? DBMSId
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