


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Beneficiary : GenericEntity
    {
        public Beneficiary()
        {
            BeneficiaryId = -1;
        }

        public virtual int BeneficiaryId
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