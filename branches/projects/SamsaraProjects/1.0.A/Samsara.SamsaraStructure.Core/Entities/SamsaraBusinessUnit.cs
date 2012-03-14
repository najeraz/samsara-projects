
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.SamsaraStructure.Core.Entities
{
    public class SamsaraBusinessUnit : BaseEntity
    {

        public SamsaraBusinessUnit()
        {
            SamsaraBusinessUnitId = -1;
        }

        [PrimaryKey]
        public virtual int SamsaraBusinessUnitId
        {
            get;
            set;
        }

        public virtual string Name
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