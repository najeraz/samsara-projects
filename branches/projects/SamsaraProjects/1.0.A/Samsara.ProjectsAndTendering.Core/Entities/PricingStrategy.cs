
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class PricingStrategy : GenericEntity
    {
        public PricingStrategy()
        {
        }

        [PrimaryKey]
        public virtual int PricingStrategyId
        {
            get;
            set;
        }

        public virtual Wholesaler Wholesaler
        {
            get;
            set;
        }

        public virtual Manufacturer Manufacturer
        {
            get;
            set;
        }

        public virtual decimal SelectedPrice
        {
            get;
            set;
        }

        public virtual decimal ProfitMargin
        {
            get;
            set;
        }

        public virtual decimal UnitPriceBeforeTax
        {
            get;
            set;
        }

        public virtual decimal UnitProfit
        {
            get;
            set;
        }

        public virtual decimal TenderLineProfit
        {
            get;
            set;
        }

        public virtual decimal UnitPriceAfterTax
        {
            get;
            set;
        }

        public virtual decimal TotalPriceBeforeTax
        {
            get;
            set;
        }

        public virtual decimal TotalPriceAfterTax
        {
            get;
            set;
        }

        public virtual decimal OfferedPriceBeforeTax
        {
            get;
            set;
        }

        public virtual decimal OfferedPriceAfterTax
        {
            get;
            set;
        }
    }
}