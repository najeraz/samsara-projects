
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class SalesAgent : GenericEntity
    {
        public SalesAgent()
        {
            SalesAgentId = -1;
        }

        [PrimaryKey]
        public virtual int SalesAgentId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}