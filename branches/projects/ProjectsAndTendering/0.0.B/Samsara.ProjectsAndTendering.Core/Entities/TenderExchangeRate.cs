
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.Operation.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderExchangeRate : GenericEntity
    {
        public TenderExchangeRate()
        {
            TenderExchangeRateId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderExchangeRateId
        {
            get;
            set;
        }

        public virtual Tender Tender
        {
            get;
            set;
        }

        public virtual ExchangeRate ExchangeRate
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