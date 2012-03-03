
using System;
using System.Diagnostics;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Base.Core.Interfaces;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.Main.Session
{
    public class Session : ISession
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

        public Nullable<int> UserId
        {
            get
            {
                return user == null ? null : (Nullable<int>)(user.UserId);
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

        public static void Logout()
        {
            user = null;
        }

        private void LoadSession(string username, string password)
        {
            UserParameters pmtUser = new UserParameters();
            IUserService srvUser = SamsaraAppContext.Resolve<IUserService>();
            Assert.IsNotNull(srvUser);

            pmtUser.Username = username.ToLower();
            pmtUser.Password = CryptoUtil.PasswordHash(username, password);
            user = srvUser.GetByParameters(pmtUser);
        }
    }
}
