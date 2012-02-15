
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class User : GenericEntity
    {

        public User()
        {
            UserId = -1;
        }

        [PrimaryKey]
        public virtual int UserId
        {
            get;
            set;
        }

        public virtual string Username
        {
            get;
            set;
        }

        public virtual string Password
        {
            set;
            protected internal get;
        }

        public virtual Staff Staff
        {
            get;
            set;
        }

    }
}