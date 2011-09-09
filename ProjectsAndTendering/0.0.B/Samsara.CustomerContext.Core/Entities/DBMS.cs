
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

        [PrimaryKeyAttribute]
        public virtual int DBMSId
        {
            get;
            set;
        }
    }
}