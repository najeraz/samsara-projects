
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class DBMS : GenericEntity
    {
        public DBMS()
        {
            DBMSId = -1;
        }

        [PrimaryKey]
        public virtual int DBMSId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}