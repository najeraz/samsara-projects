
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLineWholesaler : GenericEntity
    {
        public TenderLineWholesaler()
        {
            this.TenderLineWholesalerId = -1;
        }

        public virtual int TenderLineWholesalerId
        {
            get;
            set;
        }

        public virtual TenderLine TenderLine
        {
            get;
            set;
        }

        public virtual Wholesaler Wholesaler
        {
            get;
            set;
        }

        public virtual decimal? Price
        {
            get;
            set;
        }

        public virtual Currency Currency
        {
            get;
            set;
        }
    }
}