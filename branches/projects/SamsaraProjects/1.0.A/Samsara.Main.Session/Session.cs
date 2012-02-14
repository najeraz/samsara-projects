
using System.Security.Principal;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Service.Impl;
using Samsara.Main.Core.Parameters;

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
                return user;
            }
        }

        public static bool Login(string username, string password)
        {
            UserParameters pmtUser = new UserParameters();
            Assert.IsNotNull(srvUser);

            pmtUser.Username = username;
            pmtUser.Password = password;
            user = srvUser.GetByParameters(pmtUser);

            return user != null;
        }
    }
}
