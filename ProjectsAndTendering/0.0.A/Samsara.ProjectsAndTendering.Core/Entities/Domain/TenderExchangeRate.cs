﻿
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
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