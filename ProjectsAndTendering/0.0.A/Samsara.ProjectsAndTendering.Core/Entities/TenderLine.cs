


namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLine : GenericEntity
    {
        public TenderLine()
        {
            TenderLineId = -1;
        }

        public virtual int TenderLineId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual decimal Quantity
        {
            get;
            set;
        }

        public virtual decimal Cost
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