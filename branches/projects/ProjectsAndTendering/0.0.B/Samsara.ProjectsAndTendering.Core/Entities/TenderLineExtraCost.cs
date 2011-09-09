
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLineExtraCost : GenericEntity
    {
        public TenderLineExtraCost()
        {
            this.TenderLineExtraCostId = -1;
        }

        public virtual int TenderLineExtraCostId
        {
            get;
            set;
        }

        public virtual TenderLine TenderLine
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual decimal Amount
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