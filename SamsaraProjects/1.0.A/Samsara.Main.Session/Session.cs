
using System.Diagnostics;
using System.Security.Principal;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Service.Impl;
using Samsara.Main.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.Main.Session
{
    public class Session
    {
        private static Session session;
        private static User user;

        public static User User
        {
            get
            {
                return user;
            }
        }

        private static Session Instance
        {
            [DebuggerStepThrough]
            get
            {
                return session = session ?? new Session();
            }
        }

        public static bool Login(string username, string password)
        {
            Instance.LoadSession(username, password);

            return user != null;
        }

        private void LoadSession(string username, string password)
        {
            UserParameters pmtUser = new UserParameters();
            IUserService srvUser = SamsaraAppContext.Resolve<IUserService>();
            Assert.IsNotNull(srvUser);

            pmtUser.Username = username;
            pmtUser.Password = CryptoUtil.PasswordHash(username, password);
            user = srvUser.GetByParameters(pmtUser);
        }
    }
}
