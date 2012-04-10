
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class LoginAttempt : BaseEntity
    {
        public LoginAttempt()
        {
            LoginAttemptId = -1;
        }

        [PrimaryKey]
        public virtual int LoginAttemptId
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public virtual bool Successful
        {
            get;
            set;
        }

        public virtual string Username
        {
            get;
            set;
        }

        public virtual string DomainUser
        {
            get;
            set;
        }

        public virtual string MacAddresses
        {
            get;
            set;
        }
    }
}