
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Operation.Core.Entities
{
    public class Currency : GenericEntity
    {
        public Currency()
        {
            CurrencyId = -1;
        }

        [PrimaryKey]
        public virtual int CurrencyId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual bool IsDefault
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