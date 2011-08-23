


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
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