﻿
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class UserParameters : BaseParameters
    {
        public UserParameters()
        {
        }

        public Nullable<int> UserId
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

    }
}