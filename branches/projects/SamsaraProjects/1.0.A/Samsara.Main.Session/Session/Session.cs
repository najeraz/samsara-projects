
using System.Security.Principal;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Service.Impl;

namespace Samsara.Main.Session.Session
{
    public static class Session
    {
        private static UserService srvUser = SamsaraAppContext.Resolve<UserService>();
        private static User user;

        public static string GetWindowsIdentityName()
        {
            return WindowsIdentity.GetCurrent().Name;
        }

        public static User User
        {
            get
            {
                if (user == null)
                {
                    user = new User();
                }

                return user;
            }
        }

        static Session()
        {
            Assert.IsNotNull(srvUser);
        }
    }
}
