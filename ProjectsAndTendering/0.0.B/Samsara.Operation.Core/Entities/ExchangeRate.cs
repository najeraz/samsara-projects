
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Operation.Core.Entities
{
    public class ExchangeRate : GenericEntity
    {
        public ExchangeRate()
        {
            ExchangeRateId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int ExchangeRateId
        {
            get;
            set;
        }

        public virtual Currency SourceCurrency
        {
            get;
            set;
        }

        public virtual Currency DestinyCurrency
        {
            get;
            set;
        }

        public virtual decimal Rate
        {
            get;
            set;
        }
    }
}